namespace Runner.Abstractions;

using Auth0.ManagementApi.Models;

internal interface IAuth0Client
{
   Task<User> CreateUser(CancellationToken cancellationToken);
   Task<IEnumerable<User>> ListUsers(CancellationToken cancellationToken);
   Task<Organization> CreateOrganization(string? name = null, CancellationToken cancellationToken = default);
   Task<IEnumerable<Organization>> ListOrganizations(CancellationToken cancellationToken);
}