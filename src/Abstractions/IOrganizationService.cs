namespace Abstractions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models;

using JetBrains.Annotations;

using MorseCode.ITask;

/// <summary>
///     Defines operations for managing organizations.
/// </summary>
[PublicAPI]
public interface IOrganizationService
{
    /// <summary>
    ///     Adds a user to an organization.
    /// </summary>
    /// <param name="user">The user to add.</param>
    /// <param name="orgId">The ID of the organization.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddUserToOrganization(User user, string orgId, CancellationToken cancellationToken);

    /// <summary>
    ///     Creates a new organization with the provided information.
    /// </summary>
    /// <param name="organizationCreateInfo">The information required for creating the organization.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing the result of the operation as an
    ///     <see cref="OkError" /> object.
    /// </returns>
    ITask<OkError> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Sends an invitation to a user to join the specified organization.
    /// </summary>
    /// <param name="organizationId">The auth0 ID of the organization to invite the user to.</param>
    /// <param name="userEmail">The email address of the user to be invited.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing the result of the operation as an
    ///     <see cref="OkError" /> object.
    /// </returns>
    ITask<OkError> InviteUser(string organizationId, string userEmail, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a list of all organizations available in the system.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing a collection of <see cref="Org" /> objects
    ///     representing the organizations.
    /// </returns>
    ITask<IEnumerable<Org>> ListOrganizations(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an organization identified by the provided organization_uid in metadata.
    /// </summary>
    /// <param name="organizationUid">The unique identifier (organization_uid) stored in the organization's metadata.</param>
    /// <param name="updateInfo">The information to update for the organization.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation, containing the result of the operation as an
    ///     <see cref="OkError" /> object.
    /// </returns>
    ITask<OkError> UpdateOrganizationByUid(string organizationUid, OrganizationUpdateInfo updateInfo, CancellationToken cancellationToken = default);
}
