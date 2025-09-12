namespace Abstractions;

using System.Threading;

using MorseCode.ITask;

/// <summary>
/// Defines operations related to role management.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Creates a new role with the specified name and description.
    /// </summary>
    /// <param name="roleName">The name of the role to create. This is a required parameter.</param>
    /// <param name="description">An optional description of the role.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>Returns an <see cref="OkError"/> indicating whether the role creation was successful,
    /// and, if not, the associated error message.</returns>
    ITask<OkError> CreateRole(string roleName, string? description = null, CancellationToken cancellationToken = default);
}
