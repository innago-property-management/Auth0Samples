namespace Auth0Client;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Abstractions;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

using Innago.Shared.TryHelpers;

using JetBrains.Annotations;

using MorseCode.ITask;

[PublicAPI]
public partial class Auth0Client
{
    private sealed record Metadata(string? LegacyId = null);

    /// <summary>
    /// Creates a new organization in Auth0.
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
            Metadata = new Metadata(organizationCreateInfo.LegacyId),
        };

        Result<Organization?> result = await TryHelpers.TryAsync(() => client.Organizations.CreateAsync(request, cancellationToken)!).ConfigureAwait(false);

        return new OkError
        {
            OK = result.HasSucceeded,
            Error = ((Exception?)result)?.Message,
        };
    }

    /// <summary>
    /// Retrieves a list of all organizations from Auth0.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of organizations.</returns>
    public async Task<IEnumerable<Organization>> ListOrganizations(CancellationToken cancellationToken)
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

        return organizations;
    }

    /// <summary>
    /// Adds a user to an organization in Auth0.
    /// </summary>
    /// <param name="userId">The ID of the user to add.</param>
    /// <param name="orgId">The ID of the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task AddUserToOrganization(string userId, string orgId, CancellationToken cancellationToken)
    {
        OrganizationAddMembersRequest request = new()
        {
            Members = [userId],
        };

        return client.Organizations.AddMembersAsync(orgId, request, cancellationToken);
    }
}
