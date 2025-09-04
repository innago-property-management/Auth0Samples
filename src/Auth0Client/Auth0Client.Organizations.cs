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
    public Task<Role> CreateRole(string description, string name, CancellationToken cancellationToken)
    {
        RoleCreateRequest request = new()
        {
            Description = description,
            Name = name,
        };

        return client.Roles.CreateAsync(request, cancellationToken);
    }

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

    public Task AddUserToOrganization(string userId, string orgId, CancellationToken cancellationToken)
    {
        OrganizationAddMembersRequest request = new()
        {
            Members = [userId],
        };

        return client.Organizations.AddMembersAsync(orgId, request, cancellationToken);
    }
}
