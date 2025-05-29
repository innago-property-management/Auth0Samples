namespace Runner;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

internal partial class Auth0Client
{
    public Task<Organization> CreateOrganization(CancellationToken cancellationToken)
    {
        string name = Faker.Company.CompanyName();
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
}