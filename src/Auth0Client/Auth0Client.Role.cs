namespace Auth0Client;

using System;
using System.Threading;

using Abstractions;

using Auth0.ManagementApi.Models;

using Innago.Shared.TryHelpers;

using MorseCode.ITask;

public partial class Auth0Client
{
    /// <summary>
    ///     Creates a new role in the Auth0 system with the specified name and optional description.
    /// </summary>
    /// <param name="roleName">The name of the role to be created. This value is required and must be unique.</param>
    /// <param name="description">An optional description for the role. If not provided, an empty string will be used.</param>
    /// <param name="cancellationToken">A cancellation token used to cancel the operation if needed.</param>
    /// <returns>
    ///     An instance of <see cref="OkError" /> indicating whether the operation was successful or an error message if
    ///     it failed.
    /// </returns>
    public async ITask<OkError> CreateRole(string roleName, string? description = null, CancellationToken cancellationToken = default)
    {
        RoleCreateRequest request = new()
        {
            Name = roleName,
            Description = description ?? string.Empty,
        };

        Result<Role?> result = await TryHelpers.TryAsync(() => client.Roles.CreateAsync(request, cancellationToken)!).ConfigureAwait(false);

        return new OkError(result.HasSucceeded, ((Exception?)result)?.Message);
    }
}
