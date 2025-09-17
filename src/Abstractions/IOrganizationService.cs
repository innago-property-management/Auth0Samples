namespace Abstractions;

using System.Collections.Generic;
using System.Threading;

using JetBrains.Annotations;

using MorseCode.ITask;

/// <summary>
/// Defines operations for managing organizations.
/// </summary>
[PublicAPI]
public interface IOrganizationService
{
    /// <summary>
    /// Creates a new organization with the provided information.
    /// </summary>
    /// <param name="organizationCreateInfo">The information required for creating the organization.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the operation as an <see cref="OkError"/> object.</returns>
    ITask<OkError> CreateOrganization(OrganizationCreateInfo organizationCreateInfo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organizations available in the system.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing a collection of <see cref="Org"/> objects representing the organizations.</returns>
    ITask<IEnumerable<Org>> ListOrganizations(CancellationToken cancellationToken = default);
}
