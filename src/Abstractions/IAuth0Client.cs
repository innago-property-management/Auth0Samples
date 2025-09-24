namespace Abstractions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models;

/// <summary>
/// Represents a client for interacting with Auth0 authentication services.
/// </summary>
public interface IAuth0Client : IUserService, IRoleService, IOrganizationService
{

    /// <summary>
    /// Performs a health check on the Auth0 service to verify its availability.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a boolean indicating the health status of the Auth0 service.</returns>
    Task<bool> HealthCheck(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a user by their id.
    /// </summary>
    /// <param name="oruUid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A user response</returns>
    Task<User> GetUser(string oruUid, CancellationToken cancellationToken);

    /// <summary>
    /// Get All the Users based on their oru Ids
    /// </summary>
    /// <param name="oruUid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<User>> GetUsers(string[] oruUid, CancellationToken cancellationToken);
}
