namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using global::IdpServiceFacade;

using Grpc.Core;

using MorseCode.ITask;

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
                { nameof(request.LegacyUid), request.LegacyUid },
            });

        return await (!string.IsNullOrWhiteSpace(request.Name)).Map(CreateOrg, MissingOrganizationName)!;

        async Task<CreateOrganizationReply>? CreateOrg()
        {
            OkError? result = await externalService.CreateOrganization(new OrganizationCreateInfo(request.Name, request.LegacyId, request.LegacyUid), context.CancellationToken);

            (!string.IsNullOrEmpty(result.Error)).IfTrue(() => logger.CreateOrganizationError(result.Error));

            return new CreateOrganizationReply
            {
                Ok = result.OK,
                Error = result.Error ?? string.Empty,
            };
        }
    }

    /// <inheritdoc />
    public override async Task<ListOrganizationReply> ListOrganizations(EmptyRequest request, ServerCallContext context)
    {
        Result<IEnumerable<Org>?> result =
            await TryHelpers.TryAsync(() => externalService.ListOrganizations(context.CancellationToken).AsTask()!).ConfigureAwait(false);

        return result.Map(MapOrgs, ListOrgError)!;

        ListOrganizationReply? ListOrgError(Exception? exception)
        {
            logger.ListOrganizationsError(exception?.Message);

            ListOrganizationReply reply = new();

            reply.Organizations.AddRange([]);

            return reply;
        }

        static ListOrganizationReply MapOrgs(IEnumerable<Org>? orgs)
        {
            ListOrganizationReply reply = new();

            IEnumerable<GetOrganizationReply> organizationReplies = orgs?.Select(org => org.ToGetOrganizationReply()).ToList() ?? [];

            reply.Organizations.AddRange(organizationReplies);

            return reply;
        }
    }

    /// <summary>
    /// Invites a user to an organization based on the provided request.
    /// This method implements the gRPC OrganizationBase class's definition for the InviteUser operation.
    /// </summary>
    /// <param name="request">The request containing the organization's name, and the user's email.</param>
    /// <param name="context">The context of the server call, providing metadata and other information.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The result contains an OrganizationReply object indicating
    /// the result of the invitation process.
    /// </returns>
    public override async Task<OrganizationReply> InviteUser(OrgUserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
                tags:
                [
                    new KeyValuePair<string, object?>(nameof(request.OrgId), request.OrgId),
                    new KeyValuePair<string, object?>(nameof(request.UserEmail), request.UserEmail),
                ]);

        OkError okError = await externalService.InviteUser(request.OrgId, request.UserEmail, context.CancellationToken);

        return okError.ToOrganizationReply();
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
