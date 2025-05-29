namespace Runner;

using Auth0.ManagementApi.Models;

internal interface IAuth0Client
{
   Task<User> CreateUser(CancellationToken cancellationToken);
   Task<IEnumerable<User>> ListUsers(CancellationToken cancellationToken);
   Task<Organization> CreateOrganization(CancellationToken cancellationToken);
}