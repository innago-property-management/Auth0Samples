namespace Abstractions;

using System.Collections.Generic;
using System.Threading;

using MorseCode.ITask;

/// <summary>
///     Defines a contract for user-related operations such as password management, user status updates,
///     and multifactor authentication (MFA) toggling.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Changes the password for a user identified by the provided email.
    /// </summary>
    /// <param name="email">The email address of the user whose password needs to be changed.</param>
    /// <param name="newPassword">The new password to set for the user.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> ChangePassword(string email, string newPassword, CancellationToken cancellationToken);

    /// <summary>
    ///     Marks a user as fraudulent based on their email address.
    /// </summary>
    /// <param name="email">The email address of the user to mark as fraudulent.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> MarkUserAsFraud(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Marks a user as suspicious based on their email address.
    /// </summary>
    /// <param name="email">The email address of the user to mark as suspicious.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> MarkUserAsSuspicious(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Initiates a password reset process for a user identified by their email address.
    /// </summary>
    /// <param name="email">The email address of the user requesting a password reset.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> ResetPassword(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Enables or disables Multi-Factor Authentication (MFA) for a user.
    /// </summary>
    /// <param name="email">The email address of the user for whom to toggle MFA.</param>
    /// <param name="enable">True to enable MFA, false to disable it.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> ToggleMFA(string email, bool enable, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves metadata for a user identified by the provided email.
    /// </summary>
    /// <param name="email">The email address of the user whose metadata is to be retrieved.</param>
    /// <param name="keys">A collection of keys specifying which metadata fields to fetch. If null, all metadata will be retrieved.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that resolves to an <see cref="IReadOnlyDictionary{String, String}" /> containing the user's metadata,
    /// or null if no metadata exists.
    /// </returns>
    ITask<IReadOnlyDictionary<string, string?>?> GetUserMetadata(string email, IEnumerable<string>? keys, CancellationToken cancellationToken);
}
