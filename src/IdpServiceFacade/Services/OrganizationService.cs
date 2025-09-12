namespace Innago.Security.IdpServiceFacade.Services;

using global::IdpServiceFacade;

using Grpc.Core;

/// <summary>
///     The OrganizationService class provides server-side implementations
///     for handling organization-related operations as defined in the gRPC service.
/// </summary>
public class OrganizationService : Organization.OrganizationBase
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
    public override Task<CreateOrganizationReply> CreateOrganization(CreateOrganizationRequest request, ServerCallContext context)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return Task.FromException<CreateOrganizationReply>(new InvalidOperationException("missing username"));
        }

        return base.CreateOrganization(request, context);
    }
}
