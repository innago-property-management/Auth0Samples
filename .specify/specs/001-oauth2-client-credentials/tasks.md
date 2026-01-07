# Tasks: OAuth2 Client Credentials Enhancement

**Spec Reference**: 001-oauth2-client-credentials
**Generated**: 2026-01-07

## Prerequisites

- [ ] Decide on Q1: gRPC only or add REST gateway?
- [ ] Decide on Q2: Audience validation approach
- [ ] Decide on Q3: Error response format

---

## Implementation Tasks

### Milestone 1: Core Infrastructure (Abstractions Layer)

```
┌─────────────────────────────────────────────────────────────┐
│ Can be done in parallel with Milestone 3.1 (Proto updates)  │
└─────────────────────────────────────────────────────────────┘
```

- [ ] **T1.1** Create `ClientCredentialsToken` record
  - File: `src/Abstractions/ClientCredentialsToken.cs`
  - Properties: AccessToken, TokenType, ExpiresIn, Scope
  - Include XML documentation

- [ ] **T1.2** Add `GetClientCredentialsToken` to `IAuthService`
  - File: `src/Abstractions/IAuthService.cs`
  - Signature: `Task<Result<ClientCredentialsToken>> GetClientCredentialsToken(...)`
  - Keep existing `GetToken` for backward compatibility

- [ ] **T1.3** Update Abstractions PublicAPI tracking
  - File: `src/Abstractions/PublicAPI.Unshipped.txt`

### Milestone 2: Auth0Client Implementation

```
┌──────────────────────────────────────┐
│ Depends on: Milestone 1 (T1.1, T1.2) │
└──────────────────────────────────────┘
```

- [ ] **T2.1** Implement `GetClientCredentialsToken` in Auth0Client
  - File: `src/Auth0Client/Auth0Client.Auth.cs`
  - Map `AccessTokenResponse` → `ClientCredentialsToken`
  - Handle ApiException and general exceptions

- [ ] **T2.2** Update Auth0Client PublicAPI tracking
  - File: `src/Auth0Client/PublicAPI.Unshipped.txt`

### Milestone 3: Proto & Service Layer

```
┌─────────────────────────────────────────────────────────────┐
│ T3.1, T3.2 can run in parallel with Milestone 1            │
│ T3.3 depends on: T2.1, T3.1, T3.2                          │
└─────────────────────────────────────────────────────────────┘
```

- [ ] **T3.1** Update `auth.proto` with OAuth2 fields
  - File: `src/IdpServiceFacade/Protos/auth.proto`
  - Add: tokenType (4), expiresIn (5), scope (6), errorDescription (7)
  - Keep accessToken at field 3 for compatibility

- [ ] **T3.2** Create structured logging messages
  - File: `src/IdpServiceFacade/LoggerMessages.Auth.cs` (or append to existing)
  - TokenRequestSucceeded, TokenRequestFailed
  - Use LoggerMessage source generator pattern

- [ ] **T3.3** Update `AuthService` gRPC handler
  - File: `src/IdpServiceFacade/Services/AuthService.cs`
  - Call new `GetClientCredentialsToken` method
  - Map result to updated proto response
  - Add OpenTelemetry activity tags

- [ ] **T3.4** Update IdpServiceFacade PublicAPI tracking
  - File: `src/IdpServiceFacade/PublicAPI.Unshipped.txt`

### Milestone 4: Validation & Testing

```
┌──────────────────────────────────────────┐
│ Depends on: All previous milestones      │
└──────────────────────────────────────────┘
```

- [ ] **T4.1** Build and verify compilation
  - Command: `dotnet build Auth0Samples.slnx`
  - Verify no warnings related to changes

- [ ] **T4.2** Add unit tests for new token flow
  - File: `tests/UnitTests/AuthServiceTests.cs` (new or append)
  - Test cases: success, invalid_client, invalid_secret, timeout

- [ ] **T4.3** Run existing tests (regression check)
  - Command: `dotnet test tests/UnitTests/UnitTests.csproj`
  - Ensure no existing tests break

- [ ] **T4.4** Manual gRPC testing
  - Test with grpcurl against running service
  - Verify response contains all OAuth2 fields

---

## Parallel Execution Opportunities

```
Time →

Agent A (Abstractions)   ████████░░░░░░░░░░░░
Agent B (Proto)          ████░░░░░░░░░░░░░░░░
Agent C (Auth0Client)            ████████░░░░
Agent D (Service)                        ████████
Main (Validation)                                ████████

Legend:
████ = Active work
░░░░ = Waiting
```

**Parallel Group 1** (can start immediately):
- T1.1 Create ClientCredentialsToken
- T3.1 Update auth.proto
- T3.2 Create LoggerMessages

**Parallel Group 2** (after T1.2):
- T2.1 Implement Auth0Client method

**Sequential** (after all above):
- T3.3 Update AuthService
- T4.x Validation tasks

---

## Completion Checklist

- [ ] All tasks marked complete
- [ ] Build passes without warnings
- [ ] All tests pass
- [ ] Manual testing verified
- [ ] PublicAPI files updated
- [ ] No secrets in logs (verified)
- [ ] Backward compatibility confirmed
