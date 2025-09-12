namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using global::IdpServiceFacade;

using Grpc.Core;

using Shared.TryHelpers;

/// <summary>
///     The OrganizationService class provides server-side implementations
///     for handling organization-related operations as defined in the gRPC service.
/// </summary>
public class OrganizationService(
    IOrganizationService externalService,
    ILogger<OrganizationService> logger) : Organization.OrganizationBase
{
    /// <summary>
    ///     Handles the creation of a new organization based on the provided request.
    ///     This method implements the gRPC OrganizationBase class's definition for the CreateOrganization operation.
    /// </summary>
    /// <param name="request">The request containing the details for creating a new organization.</param>
    /// <param name="context">The context of the server call, providing metadata and other information.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The result contains a CreateOrganizationReply object with the
    ///     operation result.
    /// </returns>
    public override async Task<CreateOrganizationReply> CreateOrganization(CreateOrganizationRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: new Dictionary<string, object?>
            {
                { nameof(request.Name), request.Name },
                { nameof(request.LegacyId), request.LegacyId },
            });

        return await (!string.IsNullOrWhiteSpace(request.Name)).Map(CreateOrg, MissingOrganizationName)!;

        async Task<CreateOrganizationReply>? CreateOrg()
        {
            OkError? result = await externalService.CreateOrganization(new OrganizationCreateInfo(request.Name, request.LegacyId), context.CancellationToken);

            (!string.IsNullOrEmpty(result.Error)).IfTrue(() => logger.CreateOrganizationError(result.Error));

            return new CreateOrganizationReply
            {
                Ok = result.OK,
                Error = result.Error ?? string.Empty,
            };
        }
    }

    private static Task<CreateOrganizationReply> MissingOrganizationName()
    {
        return Task.FromResult(new CreateOrganizationReply
        {
            Ok = false,
            Error = "Missing organization name",
        });
    }
}
