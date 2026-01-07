# Specification: OAuth2 Client Credentials Token Endpoint Enhancement

**Spec ID**: 001-oauth2-client-credentials
**Status**: Draft
**Created**: 2026-01-07
**RFC Reference**: [RFC 6749 Section 4.4](https://datatracker.ietf.org/doc/html/rfc6749#section-4.4)

## Problem Statement

Innago needs to support 3rd party machine-to-machine (M2M) client applications that authenticate using the OAuth2 Client Credentials Grant. These applications will:

1. Present their `client_id` and `client_secret`
2. Receive an access token with standard OAuth2 response fields
3. Use that token to access Innago APIs

The IdpServiceFacade must act as a facade to:
- **Hide the Auth0 implementation** from callers (enabling future provider swaps)
- **Enable metering and logging** of token operations
- **Provide standard OAuth2 responses** regardless of underlying provider

### Current State

The existing `AuthService.GetToken` endpoint:
- Accepts `clientId`, `clientSecret`, `audience`
- Returns only `accessToken` (discards `expires_in`, `token_type`, `scope`)
- Meets RFC 6749 requirements for the *request* but not the *response*

### Target State

Enhanced `GetToken` endpoint that:
- Returns full OAuth2 standard response: `access_token`, `token_type`, `expires_in`, `scope`
- Maintains backward compatibility for existing callers
- Provides structured logging for metering and auditing
- Abstracts Auth0-specific details from the response

---

## User Stories

### US-001: 3rd Party App Token Request

**As a** 3rd party M2M application developer,
**I want to** obtain an access token by presenting my client credentials,
**So that** I can authenticate API requests to Innago services.

**Acceptance Criteria**:
1. I can call the token endpoint with `client_id`, `client_secret`, and `audience`
2. On success, I receive:
   - `access_token` - The bearer token
   - `token_type` - Always "Bearer"
   - `expires_in` - Seconds until token expiration
   - `scope` - Granted scopes (space-separated)
3. On failure, I receive a clear error message without internal details
4. The response format follows OAuth2 conventions (not Auth0-specific)

### US-002: Token Refresh (Re-request)

**As a** 3rd party M2M application developer,
**I want to** request a new token when my current token expires,
**So that** I can maintain continuous access to APIs.

**Acceptance Criteria**:
1. I can call the same endpoint again with my credentials
2. I receive a fresh token with new `expires_in`
3. No refresh token is required (per Client Credentials grant specification)

**Note**: In Client Credentials Grant, there is no refresh token. The client simply requests a new access token using their credentials when needed.

### US-003: Operations Visibility

**As an** Innago platform operator,
**I want** token requests to be logged with structured metadata,
**So that** I can monitor usage, detect anomalies, and meter 3rd party access.

**Acceptance Criteria**:
1. Each token request logs: timestamp, client_id (NOT secret), audience, success/failure
2. Successful requests log: token_type, expires_in, granted scopes
3. Failed requests log: error category (invalid_client, invalid_grant, etc.)
4. Logs do NOT contain: client_secret, access_token values, or other secrets
5. Logs include correlation IDs for request tracing

---

## Functional Requirements

### FR-001: OAuth2 Standard Request

The endpoint MUST accept requests conforming to RFC 6749 Section 4.4:

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| client_id | string | Yes | The client identifier |
| client_secret | string | Yes | The client secret |
| audience | string | Yes | The API identifier (resource server) |

**Note**: `grant_type=client_credentials` is implicit in this endpoint.

### FR-002: OAuth2 Standard Response

On success, the endpoint MUST return:

| Field | Type | Description |
|-------|------|-------------|
| access_token | string | The access token issued |
| token_type | string | Token type, always "Bearer" |
| expires_in | int32 | Lifetime in seconds |
| scope | string | Granted scopes (space-separated) |

On failure, the endpoint MUST return:

| Field | Type | Description |
|-------|------|-------------|
| ok | bool | false |
| error | string | Error category (e.g., "invalid_client", "invalid_grant") |
| error_description | string | Human-readable error description (no secrets) |

### FR-003: Provider Abstraction

The response MUST NOT expose Auth0-specific fields or terminology:
- No `id_token` (Auth0-specific for some flows)
- No Auth0 error codes or URLs
- Standard OAuth2 error categories only

### FR-004: Backward Compatibility

Existing callers using only `accessToken` from the response MUST continue to work:
- The `accessToken` field (current) MAY be retained alongside `access_token` (standard)
- Alternatively, document migration path for existing callers

---

## Non-Functional Requirements

### NFR-001: Performance

- Token requests SHOULD complete within 2 seconds under normal conditions
- The facade SHOULD NOT add more than 50ms latency over direct Auth0 calls

### NFR-002: Security

- Client secrets MUST NOT appear in logs, traces, or error messages
- Access tokens MUST NOT appear in logs, traces, or error messages
- Error messages MUST NOT reveal whether client_id exists (timing-safe)

### NFR-003: Observability

- All token requests MUST be traced with OpenTelemetry
- Structured logs MUST include correlation IDs
- Metrics SHOULD be exposed for: request count, latency, error rate

### NFR-004: Availability

- The endpoint MUST handle Auth0 temporary unavailability gracefully
- Clear error messages for upstream failures

---

## Out of Scope (Future Work)

The following are explicitly **NOT** part of this specification:

1. **Client Registration** - Registering new 3rd party applications in Auth0
2. **Scope/Permission Management** - Defining and assigning scopes
3. **Token Introspection** - Validating tokens server-side
4. **Token Revocation** - Revoking issued tokens
5. **Rate Limiting** - Per-client request limits (may be handled at API gateway)

These may be addressed in future specifications.

---

## Open Questions

### Q1: gRPC vs REST for 3rd Party Access?

**Context**: OAuth2 clients typically expect REST endpoints (`/oauth/token`). Our service is gRPC-native.

**Options**:
1. Expose gRPC endpoint only - 3rd parties use gRPC clients
2. Add REST gateway (grpc-gateway) alongside gRPC
3. Separate REST service that calls gRPC internally

**Recommendation**: Start with gRPC only, add REST gateway if 3rd party friction is high.

**Status**: Needs decision

### Q2: Audience Validation

**Context**: Should we validate that the requested `audience` is one we support?

**Options**:
1. Pass through to Auth0 - Let Auth0 validate
2. Whitelist validation - Only allow known audiences
3. Hybrid - Whitelist for security, Auth0 for token issuance

**Recommendation**: Whitelist validation for security, fail fast on unknown audiences.

**Status**: Needs decision

### Q3: Error Response Format

**Context**: gRPC uses status codes + details. OAuth2 uses JSON error responses.

**Options**:
1. gRPC-native errors with error details
2. Always return OK status with error in response body (current pattern)
3. Hybrid based on client preferences

**Recommendation**: Keep current pattern (OK status with error in body) for consistency.

**Status**: Needs decision

---

## Clarifications

### Q1: gRPC vs REST - RESOLVED

**Decision**: gRPC only in this service

**Rationale**: The infrastructure stack (Istio Ambient + KGateway) will handle gRPC-JSON transcoding at the gateway layer. This keeps the service simple and focused on business logic, while infrastructure handles protocol translation for clients that prefer REST/JSON.

**Architecture**:
```
Client (REST/JSON) → KGateway (transcoding) → gRPC → IdpServiceFacade
Client (gRPC)      → KGateway              → gRPC → IdpServiceFacade
```

### Q2: Audience Validation - RESOLVED

**Decision**: Pass-through to Auth0 (Auth0 is source of truth for audience validation)

**Rationale**: Security layers handle caller authentication:
- **AWS WAF**: Validates x-api-key (primary), CIDR whitelist, or user-agent
- **Istio**: Exposes only specific token routes on designated domain
- **Auth0**: Validates audience parameter for token issuance

No additional audience validation needed in the service - defense in depth handled by infrastructure.

### Q3: Error Response Format - RESOLVED

**Decision**: Keep current pattern (OK status with error in response body)

**Rationale**: Consistent with existing service patterns. gRPC-JSON transcoding at the gateway can handle HTTP status code mapping if needed.

---

## Related Documents

- [RFC 6749 - OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749)
- [RFC 6749 Section 4.4 - Client Credentials Grant](https://datatracker.ietf.org/doc/html/rfc6749#section-4.4)
- [Auth0 Client Credentials Flow](https://auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow)
