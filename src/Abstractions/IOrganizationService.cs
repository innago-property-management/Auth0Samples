namespace Abstractions;

using System.Threading;

using MorseCode.ITask;

/// <summary>
/// Defines operations for managing organizations.
/// </summary>
public interface IOrganizationService
{
    /// <summary>
    /// Creates a new organization with the provided information.
    /// </summary>
    /// <param name="organizationCreateInfo">The information required for creating the organization.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the operation as an <see cref="OkError"/> object.</returns>
    ITask<OkError> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default);
}
