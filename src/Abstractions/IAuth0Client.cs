namespace Abstractions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models;

public interface IAuth0Client
{
    Task AddUserToOrganization(string userId, string orgId, CancellationToken cancellationToken);
    Task<Organization> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default);
    Task<(User user, string password)> CreateUser(UserCreateInfo userCreateInfo, CancellationToken cancellationToken);
    Task<IEnumerable<Organization>> ListOrganizations(CancellationToken cancellationToken);
    Task<IEnumerable<User>> ListUsers(CancellationToken cancellationToken);
}
