namespace Auth0Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Abstractions;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

using Innago.Shared.TryHelpers;

using JetBrains.Annotations;

using MorseCode.ITask;

using Newtonsoft.Json.Linq;

[PublicAPI]
public partial class Auth0Client
{
    /// <summary>
    ///     Creates a new organization in Auth0.
    /// </summary>
    /// <param name="organizationCreateInfo">The information required to create the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created organization.</returns>
    public async ITask<OkError> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default)
    {
        string orgName = CleanName(organizationCreateInfo.Name);

        OrganizationCreateRequest request = new()
        {
            Name = orgName,
            DisplayName = organizationCreateInfo.Name,
            Metadata = new Metadata(organizationCreateInfo.LegacyId, organizationCreateInfo.LegacyUid),
        };

        Result<Organization?> result = await TryHelpers.TryAsync(() => client.Organizations.CreateAsync(request, cancellationToken)!).ConfigureAwait(false);

        return new OkError
        {
            OK = result.HasSucceeded,
            Error = ((Exception?)result)?.Message,
        };
    }

    /// <summary>
    ///     Retrieves a list of all organizations from Auth0.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of organizations.</returns>
    public async ITask<IEnumerable<Org>> ListOrganizations(CancellationToken cancellationToken = default)
    {
        const int perPage = 10;
        List<Organization> organizations = [];
        string? from = null;

        do
        {
            CheckpointPaginationInfo paginationInfo = new(perPage, from!);

            ICheckpointPagedList<Organization> pagedList = await client.Organizations.GetAllAsync(paginationInfo, cancellationToken).ConfigureAwait(false);

            organizations.AddRange(pagedList);

            from = pagedList.Paging.Next;
        } while (!string.IsNullOrEmpty(from));

        return organizations.Select(MapOrganization).ToList();

        static Org MapOrganization(Organization org)
        {
            return new Org(org.Id, org.Name, org.DisplayName, MapMetadata(org.Metadata));
        }

        static IReadOnlyDictionary<string, string>? MapMetadata(JObject? obj)
        {
            return (obj as IDictionary<string, JToken?>)?.ToDictionary(pair => pair.Key, pair => pair.Value?.ToString() ?? string.Empty);
        }
    }

    /// <summary>
    ///     Updates an organization in Auth0 by finding it using the organization_uid in metadata.
    /// </summary>
    /// <param name="organizationUid">The unique identifier stored in the organization's metadata.</param>
    /// <param name="updateInfo">The information to update for the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the update result.</returns>
    public async ITask<OkError> UpdateOrganizationByUid(string organizationUid, OrganizationUpdateInfo updateInfo, CancellationToken cancellationToken = default)
    {
        // First, find the organization by organization_uid in metadata
        IEnumerable<Org> orgs = await this.ListOrganizations(cancellationToken);

        Org? organization = orgs.FirstOrDefault(org =>
            org.Metadata != null &&
            org.Metadata.TryGetValue("organization_uid", out string? uid) &&
            uid == organizationUid);

        if (organization == null)
        {
            return new OkError(false, $"Organization with organization_uid '{organizationUid}' not found");
        }

        // Prepare the update request
        OrganizationUpdateRequest request = new()
        {
            DisplayName = updateInfo.DisplayName,
        };

        // Merge existing metadata with new metadata
        if (updateInfo.Metadata != null)
        {
            Dictionary<string, object> mergedMetadata = organization.Metadata?.ToDictionary(
                pair => pair.Key,
                pair => (object)pair.Value) ?? [];

            foreach (KeyValuePair<string, string> kvp in updateInfo.Metadata)
            {
                mergedMetadata[kvp.Key] = kvp.Value;
            }

            request.Metadata = mergedMetadata;
        }

        // Update the organization using Auth0 org ID
        Result<Organization?> result = await TryHelpers.TryAsync(() =>
            client.Organizations.UpdateAsync(organization.Id, request, cancellationToken)!).ConfigureAwait(false);

        return new OkError
        {
            OK = result.HasSucceeded,
            Error = ((Exception?)result)?.Message,
        };
    }

    /// <inheritdoc />
    public async ITask<OkError> InviteUser(string organizationId, string userEmail, CancellationToken cancellationToken = default)
    {
        string password = Guid.CreateVersion7().ToString();

        UserCreateRequest userCreateRequest = new UserCreateRequest
        {
            Email = userEmail,
            Password = password,
            EmailVerified = true,
            VerifyEmail = true,
            AppMetadata = new Metadata(RoleId: "3"),
        };
        Result<User?> userCreationResult = await TryHelpers
            .TryAsync(() => this.CreateUserImplementation(userCreateRequest,
                cancellationToken: cancellationToken)!).ConfigureAwait(false);

        return await userCreationResult.Map(OnCreateSuccess!, HandleError)!;

        async Task<OkError> OnCreateSuccess(User user)
        {
            Result addToOrganizationResult = await TryHelpers.TryAsync(() => this.AddUserToOrganization(user, organizationId, cancellationToken));

            Result<OkError> addToOrgResult = await addToOrganizationResult.MapAsync(OnAddSuccess, OnAddError!);

            return addToOrgResult!;

            async Task<Result<OkError>> OnAddSuccess()
            {
                Result<string?> resetPasswordResult =
                    await TryHelpers.TryAsync(() => this.ResetPassword(user.Email, cancellationToken).AsTask()).ConfigureAwait(false);

                return new OkError(resetPasswordResult.HasSucceeded, ((Exception?)resetPasswordResult)?.Message);
            }
        }
    }

    /// <summary>
    ///     Adds a user to an organization in Auth0.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <param name="orgId">The ID of the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task AddUserToOrganization(User user, string orgId, CancellationToken cancellationToken)
    {
        OrganizationAddMembersRequest request = new()
        {
            Members = [user.UserId],
        };

        await client.Organizations.AddMembersAsync(orgId, request, cancellationToken).ConfigureAwait(false);

        Result<Ticket?> ticket = await TryHelpers.TryAsync(() => client.Tickets.CreateEmailVerificationTicketAsync(new EmailVerificationTicketRequest
        {
            OrganizationId = orgId,
            UserId = user.UserId,
        },
            cancellationToken)!).ConfigureAwait(false);

        ticket.IfFailed(ThrowOnError);
        return;

        static void ThrowOnError(Exception? exception)
        {
            throw exception!;
        }
    }

    /// <summary>
    ///     Adds a user to an organization in Auth0.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <param name="organizationUid">The ID of the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<OkError> AddUserToOrganizationByUid(User user, string organizationUid, CancellationToken cancellationToken)
    {
        Result<Organization?> orgResult = await TryHelpers.TryAsync(() => 
            client.Organizations.GetByNameAsync(organizationUid, cancellationToken)!).ConfigureAwait(false);

        return await orgResult.Map(OnGetOrgSuccess!, OnGetOrgError)!;

        async Task<OkError> OnGetOrgSuccess(Organization? org)
        {
            if (org is null)
            {
                return new OkError(false, $"Organization with name '{organizationUid}' not found");
            }

            OrganizationAddMembersRequest request = new()
            {
                Members = [user.UserId],
            };

            Result addMemberResult = await TryHelpers.TryAsync(() => 
                client.Organizations.AddMembersAsync(org.Id, request, cancellationToken)).ConfigureAwait(false);

            return new OkError
            {
                OK = addMemberResult.HasSucceeded,
                Error = ((Exception?)addMemberResult)?.Message,
            };
        }

        static Task<OkError> OnGetOrgError(Exception? exception)
        {
            return Task.FromResult(new OkError(false, exception?.Message ?? "Failed to get organization"));
        }
    }

    private static Task<OkError> HandleError(Exception? exception)
    {
        return Task.FromResult(new OkError(false, exception?.Message ?? string.Empty));
    }

    private static Task<Result<OkError>> OnAddError(Exception exception)
    {
        Result<OkError> errorResult = new OkError(false, exception.Message);
        return Task.FromResult(errorResult);
    }

    private sealed record Metadata(string? LegacyId = null, string? LegacyUid = null, string? RoleId = null);
}
