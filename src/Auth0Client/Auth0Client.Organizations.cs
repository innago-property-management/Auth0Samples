namespace Auth0Client;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Abstractions;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

using JetBrains.Annotations;

[PublicAPI]
public partial class Auth0Client
{
    /// <summary>
    /// Creates a new role in Auth0.
    /// </summary>
    /// <param name="description">The description of the role.</param>
    /// <param name="name">The name of the role.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created role.</returns>
    public Task<Role> CreateRole(string description, string name, CancellationToken cancellationToken)
    {
        RoleCreateRequest request = new()
        {
            Description = description,
            Name = name,
        };

        return client.Roles.CreateAsync(request, cancellationToken);
    }

    /// <summary>
    /// Creates a new organization in Auth0.
    /// </summary>
    /// <param name="organizationCreateInfo">The information required to create the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created organization.</returns>
    public Task<Organization> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default)
    {
        string orgName = CleanName(organizationCreateInfo.Name);

        OrganizationCreateRequest request = new()
        {
            Name = orgName,
            DisplayName = organizationCreateInfo.Name,
        };

        return client.Organizations.CreateAsync(request, cancellationToken);
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
