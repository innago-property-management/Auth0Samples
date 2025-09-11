namespace Abstractions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models;

/// <summary>
/// Represents a client for interacting with Auth0 authentication services.
/// </summary>
public interface IAuth0Client : IUserService, IRoleService
{
    /// <summary>
    /// Adds a user to an organization.
    /// </summary>
    /// <param name="userId">The ID of the user to add.</param>
    /// <param name="orgId">The ID of the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddUserToOrganization(string userId, string orgId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new organization.
    /// </summary>
    /// <param name="organizationCreateInfo">The information required to create the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created organization.</returns>
    Task<Organization> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="userCreateInfo">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created user.</returns>
    Task<User> CreateUser(UserCreateInfo userCreateInfo, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a list of all organizations.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of organizations.</returns>
    Task<IEnumerable<Organization>> ListOrganizations(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a list of all users.
    /// </summary>
    /// <param name="luceneQuery"></param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of users.</returns>
    Task<IEnumerable<User>> ListUsers(string luceneQuery = "user_id:*", CancellationToken cancellationToken = default);

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
