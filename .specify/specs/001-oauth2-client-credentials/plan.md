# Implementation Plan: OAuth2 Client Credentials Enhancement

**Spec Reference**: 001-oauth2-client-credentials
**Status**: Draft
**Created**: 2026-01-07

## Summary

Enhance the existing `AuthService.GetToken` endpoint to return full OAuth2 standard response fields (`access_token`, `token_type`, `expires_in`, `scope`) while maintaining backward compatibility.

## Technology Stack

| Component | Technology | Rationale |
|-----------|------------|-----------|
| Service Layer | gRPC / Protobuf | Existing pattern, no change needed |
| Auth0 Integration | Auth0.AuthenticationApi SDK | Already in use, returns `AccessTokenResponse` with all needed fields |
| Logging | Serilog + LoggerMessage generator | Existing pattern |
| Tracing | OpenTelemetry | Existing pattern |
| Result Handling | Innago.Shared.TryHelpers | Existing pattern |

**No new dependencies required** - Auth0 SDK already provides all needed response fields.

## Architecture Changes

### Current Flow

```
gRPC Request (clientId, clientSecret, audience)
    ↓
AuthService.GetToken
    ↓
IAuthService.GetToken → Result<string>  ← Only returns accessToken
    ↓
Auth0Client.GetToken
    ↓
Auth0 SDK → AccessTokenResponse  ← Has all fields, but we discard most
    ↓
gRPC Response (ok, error, accessToken)
```

### Target Flow

```
gRPC Request (clientId, clientSecret, audience)
    ↓
AuthService.GetToken
    ↓
IAuthService.GetToken → Result<ClientCredentialsToken>  ← Rich return type
    ↓
Auth0Client.GetToken
    ↓
Auth0 SDK → AccessTokenResponse  ← Map all fields
    ↓
gRPC Response (ok, error, accessToken, tokenType, expiresIn, scope)
```

## Detailed Implementation

### Phase 1: Core Types

#### 1.1 Create TokenResponse Record (Abstractions)

**File**: `src/Abstractions/ClientCredentialsToken.cs` (new)

```csharp
namespace Abstractions;

/// <summary>
/// Represents an OAuth2 Client Credentials token response.
/// Provider-agnostic representation of RFC 6749 Section 4.4 response.
/// </summary>
public record ClientCredentialsToken
{
    /// <summary>
    /// The access token issued by the authorization server.
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// The type of token issued. Always "Bearer" for this flow.
    /// </summary>
    public required string TokenType { get; init; }

    /// <summary>
    /// The lifetime in seconds of the access token.
    /// </summary>
    public required int ExpiresIn { get; init; }

    /// <summary>
    /// The scope of the access token (space-separated).
    /// </summary>
    public string? Scope { get; init; }
}
```

#### 1.2 Add New Interface Method (IAuthService)

**File**: `src/Abstractions/IAuthService.cs`

```csharp
// Add alongside existing method for backward compatibility
Task<Result<ClientCredentialsToken>> GetClientCredentialsToken(
    string clientId,
    string clientSecret,
    string audience,
    CancellationToken cancellationToken = default);
```

### Phase 2: Auth0Client Implementation

#### 2.1 Implement New Method

**File**: `src/Auth0Client/Auth0Client.Auth.cs`

```csharp
public async Task<Result<ClientCredentialsToken>> GetClientCredentialsToken(
    string clientId,
    string clientSecret,
    string audience,
    CancellationToken cancellationToken = default)
{
    try
    {
        AccessTokenResponse response = await authClient.GetTokenAsync(
            new ClientCredentialsTokenRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Audience = audience
            },
            cancellationToken);

        if (string.IsNullOrEmpty(response.AccessToken))
        {
            return new Result<ClientCredentialsToken>(
                new InvalidOperationException("Auth0 returned empty access token"));
        }

        return new Result<ClientCredentialsToken>(new ClientCredentialsToken
        {
            AccessToken = response.AccessToken,
            TokenType = response.TokenType ?? "Bearer",
            ExpiresIn = (int)(response.ExpiresIn ?? 3600),
            Scope = response.Scope
        });
    }
    catch (ApiException apiEx)
    {
        return new Result<ClientCredentialsToken>(
            new InvalidOperationException($"Token request failed: {apiEx.Message}"));
    }
    catch (Exception ex)
    {
        return new Result<ClientCredentialsToken>(
            new InvalidOperationException("Unexpected error during token request", ex));
    }
}
```

### Phase 3: Proto Enhancement

#### 3.1 Update auth.proto

**File**: `src/IdpServiceFacade/Protos/auth.proto`

```protobuf
syntax = "proto3";

option csharp_namespace = "IdpServiceFacade";

package auth;

service Auth {
  rpc GetToken (GetTokenRequest) returns (GetTokenResponse);
}

message GetTokenRequest {
  string clientId = 1;
  string clientSecret = 2;
  string audience = 3;
}

message GetTokenResponse {
  bool ok = 1;
  optional string error = 2;
  optional string errorDescription = 3;  // NEW: Human-readable error

  // OAuth2 standard fields
  string accessToken = 4;                 // CHANGED: Was field 3
  string tokenType = 5;                   // NEW: Always "Bearer"
  int32 expiresIn = 6;                    // NEW: Seconds until expiration
  optional string scope = 7;              // NEW: Granted scopes
}
```

**Note**: Field number change (accessToken 3→4) breaks wire compatibility. Options:
1. **Option A**: Keep accessToken as field 3, add new fields after (recommended for backward compat)
2. **Option B**: Create new response message, deprecate old one
3. **Option C**: Major version bump with breaking change

**Recommendation**: Option A - minimal disruption

#### 3.2 Revised Proto (Backward Compatible)

```protobuf
message GetTokenResponse {
  bool ok = 1;
  optional string error = 2;
  string accessToken = 3;                 // KEEP at field 3 for compatibility

  // NEW OAuth2 standard fields
  string tokenType = 4;
  int32 expiresIn = 5;
  optional string scope = 6;
  optional string errorDescription = 7;
}
```

### Phase 4: Service Layer Update

#### 4.1 Update AuthService

**File**: `src/IdpServiceFacade/Services/AuthService.cs`

```csharp
public override async Task<GetTokenResponse> GetToken(
    GetTokenRequest request,
    ServerCallContext context)
{
    using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(
        ActivityKind.Client,
        tags: [
            new KeyValuePair<string, object?>("client_id", request.ClientId),
            new KeyValuePair<string, object?>("audience", request.Audience)
        ]);

    Result<ClientCredentialsToken> result = await externalService
        .GetClientCredentialsToken(
            request.ClientId,
            request.ClientSecret,
            request.Audience,
            context.CancellationToken)
        .ConfigureAwait(false);

    if (!result.HasSucceeded)
    {
        logger.TokenRequestFailed(request.ClientId, request.Audience);

        return new GetTokenResponse
        {
            Ok = false,
            Error = "invalid_grant",
            ErrorDescription = "Token request failed",
            AccessToken = string.Empty,
            TokenType = string.Empty,
            ExpiresIn = 0
        };
    }

    ClientCredentialsToken token = result;
    logger.TokenRequestSucceeded(request.ClientId, request.Audience, token.ExpiresIn);

    return new GetTokenResponse
    {
        Ok = true,
        AccessToken = token.AccessToken,
        TokenType = token.TokenType,
        ExpiresIn = token.ExpiresIn,
        Scope = token.Scope ?? string.Empty
    };
}
```

### Phase 5: Structured Logging

#### 5.1 Add LoggerMessages

**File**: `src/IdpServiceFacade/LoggerMessages.cs` (new or append)

```csharp
internal static partial class LoggerMessages
{
    [LoggerMessage(
        LogLevel.Information,
        EventId = 2001,
        EventName = nameof(TokenRequestSucceeded),
        Message = "Token request succeeded for client {ClientId}, audience {Audience}, expires in {ExpiresIn}s")]
    public static partial void TokenRequestSucceeded(
        this ILogger<AuthService> logger,
        string clientId,
        string audience,
        int expiresIn);

    [LoggerMessage(
        LogLevel.Warning,
        EventId = 2002,
        EventName = nameof(TokenRequestFailed),
        Message = "Token request failed for client {ClientId}, audience {Audience}")]
    public static partial void TokenRequestFailed(
        this ILogger<AuthService> logger,
        string clientId,
        string audience);
}
```

### Phase 6: PublicAPI Updates

#### 6.1 Update API Surface Tracking

**File**: `src/Abstractions/PublicAPI.Unshipped.txt`
```
Abstractions.ClientCredentialsToken
Abstractions.ClientCredentialsToken.AccessToken.get -> string!
Abstractions.ClientCredentialsToken.TokenType.get -> string!
Abstractions.ClientCredentialsToken.ExpiresIn.get -> int
Abstractions.ClientCredentialsToken.Scope.get -> string?
Abstractions.IAuthService.GetClientCredentialsToken(string!, string!, string!, System.Threading.CancellationToken) -> System.Threading.Tasks.Task<Innago.Shared.TryHelpers.Result<Abstractions.ClientCredentialsToken!>>!
```

---

## Task Breakdown

### Milestone 1: Core Infrastructure

| Task | Files | Depends On | Parallelizable |
|------|-------|------------|----------------|
| T1.1 Create ClientCredentialsToken record | Abstractions/ClientCredentialsToken.cs | - | Yes |
| T1.2 Add IAuthService method | Abstractions/IAuthService.cs | T1.1 | No |
| T1.3 Update PublicAPI.Unshipped.txt | Abstractions/PublicAPI.Unshipped.txt | T1.2 | No |

### Milestone 2: Auth0Client Implementation

| Task | Files | Depends On | Parallelizable |
|------|-------|------------|----------------|
| T2.1 Implement GetClientCredentialsToken | Auth0Client/Auth0Client.Auth.cs | T1.2 | No |
| T2.2 Update Auth0Client PublicAPI | Auth0Client/PublicAPI.Unshipped.txt | T2.1 | No |

### Milestone 3: Proto & Service Layer

| Task | Files | Depends On | Parallelizable |
|------|-------|------------|----------------|
| T3.1 Update auth.proto | IdpServiceFacade/Protos/auth.proto | - | Yes |
| T3.2 Create LoggerMessages | IdpServiceFacade/LoggerMessages.cs | - | Yes |
| T3.3 Update AuthService | IdpServiceFacade/Services/AuthService.cs | T2.1, T3.1, T3.2 | No |
| T3.4 Update IdpServiceFacade PublicAPI | IdpServiceFacade/PublicAPI.Unshipped.txt | T3.3 | No |

### Milestone 4: Validation

| Task | Files | Depends On | Parallelizable |
|------|-------|------------|----------------|
| T4.1 Build and verify compilation | - | T3.4 | No |
| T4.2 Add unit tests for new flow | UnitTests/*.cs | T4.1 | No |
| T4.3 Run existing tests (regression) | - | T4.1 | Yes |
| T4.4 Manual gRPC testing | - | T4.1 | Yes |

---

## Risk Assessment

| Risk | Impact | Mitigation |
|------|--------|------------|
| Proto field reorder breaks clients | High | Use Option A (keep accessToken at field 3) |
| Auth0 SDK behavior change | Medium | Pin SDK version, test with specific version |
| Existing callers break | Medium | Keep old method signature, add new one |
| Logging leaks secrets | High | LoggerMessage review, no secret parameters |

---

## Testing Strategy

### Unit Tests

1. **Success path**: Valid credentials → full token response
2. **Invalid client**: Bad client_id → error response
3. **Invalid secret**: Bad secret → error response
4. **Auth0 unavailable**: Timeout/error → graceful failure
5. **Response mapping**: All fields correctly mapped

### Integration Tests

1. **End-to-end gRPC call**: Client → Service → Auth0 → Response
2. **Backward compatibility**: Old clients still work

### Manual Testing

```bash
# Test with grpcurl
grpcurl -d '{
  "clientId": "test-client",
  "clientSecret": "test-secret",
  "audience": "https://api.innago.com"
}' localhost:7122 auth.Auth.GetToken
```

---

## Open Decisions Required

Before implementation, decisions needed on:

1. **Q1 (gRPC vs REST)**: Proceed with gRPC only for now?
2. **Q2 (Audience Validation)**: Add whitelist or pass-through?
3. **Q3 (Error Format)**: Keep current pattern (OK with error in body)?

---

## Coordination Notes

If using multi-agent implementation:

- **Agent A**: Abstractions layer (T1.1, T1.2, T1.3) - Can work independently
- **Agent B**: Proto updates (T3.1) - Can work in parallel with Agent A
- **Agent C**: Auth0Client (T2.1, T2.2) - Depends on Agent A completion
- **Agent D**: Service layer (T3.2, T3.3, T3.4) - Depends on A, B, C
- **Main**: Validation and testing (T4.x) - After all agents complete
