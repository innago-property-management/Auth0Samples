# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Architecture

This is a .NET solution for Auth0 identity provider facade services with gRPC clients. The solution consists of:

- **IdpServiceFacade** - Main gRPC service that provides Auth0 user and organization management operations
- **IdpServiceFacadeClient** - .NET Standard 2.0 client library generated from protobuf definitions
- **Auth0Client** - Auth0 API client wrapper with user and organization operations
- **Abstractions** - Shared interfaces and abstractions
- **Runner** - CLI tool for testing/running commands against the service
- **UnitTests** - Test project

The service acts as a facade over Auth0's Management API, providing structured gRPC endpoints for user management, organization operations, role assignments, and metadata retrieval.

## Development Commands

### Building the solution
```bash
dotnet restore Auth0Samples.slnx
dotnet build Auth0Samples.slnx
```

### Running the main service
```bash
dotnet run --project src/IdpServiceFacade
```

### Running tests
```bash
dotnet test tests/UnitTests/UnitTests.csproj
```

### License checking
```bash
./check-licenses.sh
```

### Docker build
The service is containerized - see `Dockerfile` for multi-stage build targeting `src/IdpServiceFacade`

## Key Technologies

- **gRPC** - Primary service communication protocol
- **Protobuf** - Message definitions in `src/IdpServiceFacade/Protos/`
- **Auth0 Management API** - External identity provider
- **OpenTelemetry** - Observability and metrics
- **Serilog** - Structured logging

## Protocol Buffers

Proto definitions are located in `src/IdpServiceFacade/Protos/`:
- `user.proto` - User management operations (password reset, MFA, roles, metadata)
- `organization.proto` - Organization operations
- `role.proto` - Role definitions

The client library auto-generates from these proto files during build.

## Testing the gRPC Service

Use `grpcurl` for testing (see README in IdpServiceFacadeClient for examples):

```bash
# List services
grpcurl localhost:7122 list

# Get user metadata
grpcurl -d '{"email": "user@example.com"}' localhost:7122 user.User.GetUserMetadata
```

## Important Files

- `Auth0Samples.slnx` - Solution file
- `src/IdpServiceFacadeClient/IdpServiceFacadeClient.csproj` - Client library project with protobuf references
- `src/IdpServiceFacade/Services/UserService.cs` - Main gRPC service implementation
- `PublicAPI.Shipped.txt` / `PublicAPI.Unshipped.txt` - API surface tracking for client library