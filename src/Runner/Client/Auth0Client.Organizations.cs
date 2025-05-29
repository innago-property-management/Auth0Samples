namespace Runner.Client;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

internal partial class Auth0Client
{
    public Task<Organization> CreateOrganization(string? name = null, CancellationToken cancellationToken = default)
    {
        name ??= Faker.Company.CompanyName();
        string orgName = CleanName(name);

        OrganizationCreateRequest request = new()
        {
            Name = orgName,
            DisplayName = name,
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
            CheckpointPaginationInfo paginationInfo = new(perPage, from);

            ICheckpointPagedList<Organization>? pagedList = await client.Organizations.GetAllAsync(paginationInfo, cancellationToken).ConfigureAwait(false);
            
            organizations.AddRange(pagedList);

            from = pagedList.Paging.Next;
        } while (from != null);

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