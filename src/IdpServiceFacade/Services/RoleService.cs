namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using global::IdpServiceFacade;

using Grpc.Core;

using Shared.TryHelpers;

using Role = global::IdpServiceFacade.Role;

/// <summary>
///     Provides services for managing roles by interacting with external services
///     such as Auth0 and facilitates communication over gRPC for role-related operations.
/// </summary>
/// <param name="externalService">The external role service implementation.</param>
/// <param name="logger">The logger instance for this service.</param>
public class RoleService(
    IRoleService externalService,
    ILogger<RoleService> logger) : Role.RoleBase
{
    /// <summary>
    ///     Creates a role using the provided role name and description.
    /// </summary>
    /// <param name="request">The request containing role details such as name and description.</param>
    /// <param name="context">The server call context for the gRPC call.</param>
    /// <returns>Returns a <see cref="CreateRoleResponse" /> containing information about the outcome of the create operation.</returns>
    public override async Task<CreateRoleResponse> CreateRole(CreateRoleRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.RoleName), request.RoleName)]);

        OkError result = await externalService.CreateRole(request.RoleName, request.RoleDescription, context.CancellationToken).ConfigureAwait(false);

        string.IsNullOrEmpty(result.Error).IfFalse(() => logger.Error(new Exception(result.Error)));

        return new CreateRoleResponse
        {
            Ok = result.OK,
            Error = result.Error,
        };
    }
}
