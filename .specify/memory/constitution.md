# Auth0Samples Project Constitution

## Purpose

This service acts as a **facade over Auth0's identity provider**, abstracting Auth0-specific implementation details from internal Innago services. The key goals are:

1. **Provider Abstraction** - Callers should not know they're talking to Auth0
2. **Future Flexibility** - Enable swapping identity providers without client changes
3. **Observability** - Central point for metering, logging, and auditing identity operations
4. **Simplified Interface** - Expose only the operations Innago needs, not the full Auth0 API

## Architecture Principles

### 1. Layered Facade Pattern

```
gRPC Service Layer (Services/*.cs)
    ↓ (protobuf contracts)
Abstraction Layer (Abstractions/*.cs)
    ↓ (interfaces)
Auth0Client Implementation (Auth0Client/*.cs)
    ↓ (Auth0 SDK)
Auth0 APIs
```

**Rationale**: Clear separation allows swapping the Auth0Client implementation without touching the gRPC layer.

### 2. Protocol Buffer Contracts

- All external communication uses gRPC with protobuf definitions
- Proto files in `src/IdpServiceFacade/Protos/`
- Client library auto-generates from proto during build
- Proto messages should be provider-agnostic (no Auth0-specific field names)

### 3. Result Pattern for Error Handling

- Use `Innago.Shared.TryHelpers.Result<T>` for operations that can fail
- Services return structured responses with `ok`, `error`, and data fields
- Never throw exceptions across gRPC boundaries

## Code Quality Standards

### Naming Conventions

- **Proto messages**: Use OAuth2/OIDC standard terminology (access_token, expires_in, token_type)
- **C# types**: PascalCase following .NET conventions
- **Interfaces**: Prefix with `I` (IAuthService, IUserService)

### Structured Logging

- Use `ILogger<T>` with LoggerMessage source generator pattern
- Never use Console.Write/WriteLine
- Include request identifiers for correlation
- Log at appropriate levels (Info for operations, Warning for recoverable errors, Error for failures)

### Testing

- Unit tests in `tests/UnitTests/`
- Test both success and failure paths
- Mock external Auth0 calls in unit tests

## Technology Constraints

### Current Stack

- .NET 9+ (verify current project target before adding dependencies)
- gRPC for service communication
- Auth0 SDK for identity provider integration
- OpenTelemetry for observability
- Serilog for structured logging

### Dependency Guidelines

- Prefer Auth0 official SDKs for identity operations
- Avoid adding dependencies for functionality achievable with existing stack
- Check dependency freshness (must be updated within 2 years)
- Verify framework compatibility before adding packages

## Security Principles

1. **Never log secrets** - Client secrets, tokens, and credentials must never appear in logs
2. **Validate inputs** - All external inputs must be validated before processing
3. **Fail securely** - Error messages should not leak implementation details
4. **Audit operations** - All authentication/authorization operations should be auditable

## Performance Expectations

- Token operations should complete within 2 seconds under normal conditions
- Service should handle concurrent requests without blocking
- Use async/await consistently throughout the codebase

## Development Practices

### Before Implementation

1. Review existing patterns in codebase
2. Ensure proto changes are backward compatible when possible
3. Update PublicAPI.Shipped.txt / PublicAPI.Unshipped.txt for client library changes

### After Implementation

1. Run `dotnet build Auth0Samples.slnx` to verify compilation
2. Run `dotnet test` to verify tests pass
3. Check license compliance with `./check-licenses.sh`
