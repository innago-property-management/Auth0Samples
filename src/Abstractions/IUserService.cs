namespace Abstractions;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models;

using MorseCode.ITask;

/// <summary>
///     Defines a contract for user-related operations such as password management, user status updates,
///     and multifactor authentication (MFA) toggling.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Blocks a user based on their email address, preventing them from accessing the system.
    /// </summary>
    /// <param name="email">The email address of the user to block.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> BlockUser(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Changes the password for a user identified by the provided email.
    /// </summary>
    /// <param name="email">The email address of the user whose password needs to be changed.</param>
    /// <param name="newPassword">The new password to set for the user.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> ChangePassword(string email, string newPassword, CancellationToken cancellationToken);

    /// <summary>
    ///     Creates a new user.
    /// </summary>
    /// <param name="userCreateInfo">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created user.</returns>
    Task<User?> CreateUser(UserCreateInfo userCreateInfo, CancellationToken cancellationToken);
    /// <summary>
    ///     Creates a new user.
    /// </summary>
    /// <param name="userCreateRequest">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created user.</returns>
    Task<User> CreateUserImplementation(UserCreateRequest userCreateRequest, CancellationToken cancellationToken);

    /// <summary>
    ///     Disables Multi-Factor Authentication (MFA) for a user.
    /// </summary>
    /// <param name="email">The email address of the user for whom to toggle MFA.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> DisableMfa(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Disables Multi-Factor Authentication (MFA) for a user for next login
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> EnableMfa(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves token for a user identified by the provided username and password.
    /// </summary>
    /// <param name="refreshToken">The refreshToken from Auth0 to fetch a new token.</param>
    /// <param name="keys">
    ///     A collection of keys specifying which metadata fields to fetch. If null, all metadata will be
    ///     retrieved.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that resolves to an <see cref="TokenResponsePayload&lt;TokenResponse>" /> containing the response from an
    ///     OpenAPI client authentication request.
    /// </returns>
    ITask<TokenResponsePayload<TokenResponse>> GetRefreshTokenAsyncImplementation(
        string refreshToken,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves token for a user identified by the provided username and password.
    /// </summary>
    /// <param name="username">The username of the client whose token is to be retrieved.</param>
    /// <param name="password">The password of the client whose token is to be retrieved.</param>
    /// <param name="keys">
    ///     A collection of keys specifying which metadata fields to fetch. If null, all metadata will be
    ///     retrieved.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that resolves to an <see cref="TokenResponsePayload&lt;TokenResponse>" /> containing the response from an
    ///     OpenAPI client authentication request.
    /// </returns>
    ITask<TokenResponsePayload<TokenResponse>> GetTokenAsyncImplementation(
        string username,
        string password,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves metadata for a user identified by the provided email.
    /// </summary>
    /// <param name="email">The email address of the user whose metadata is to be retrieved.</param>
    /// <param name="keys">
    ///     A collection of keys specifying which metadata fields to fetch. If null, all metadata will be
    ///     retrieved.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that resolves to an <see cref="IReadOnlyDictionary{String, String}" /> containing the user's metadata,
    ///     or null if no metadata exists.
    /// </returns>
    ITask<IReadOnlyDictionary<string, string?>?> GetUserMetadata(string email, IEnumerable<string>? keys, CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves metadata for users based on their email addresses.
    /// </summary>
    /// <param name="emailAddresses">The email addresses</param>
    /// <param name="keys">
    ///     A collection of specific metadata keys to retrieve for each user.
    ///     Can be null to retrieve all keys.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task containing a read-only dictionary where the key is the email address,
    ///     and the value is another dictionary with user metadata as key-value pairs,
    ///     or null if no metadata is found.
    /// </returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByEmailAddresses(
        IEnumerable<string> emailAddresses,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves metadata for users whose email addresses match the provided search term.
    /// </summary>
    /// <param name="searchTerm">A fragment of the email address to search for.</param>
    /// <param name="keys">
    ///     A collection of specific metadata keys to include in the result. If null, all available metadata
    ///     will be included.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that resolves to a dictionary where the keys are user identifiers, and the values are dictionaries of
    ///     metadata key-value pairs, or null if no matches are found.
    /// </returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByEmailFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves a dictionary of user metadata for users whose names or identifiers contain the specified search term.
    /// </summary>
    /// <param name="searchTerm">The text fragment to search for in users' names or identifiers.</param>
    /// <param name="keys">
    ///     A collection of specific metadata keys to include in the response, or null to include all available
    ///     keys.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation and returns a dictionary containing user metadata for
    ///     matching users.
    /// </returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNameFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves metadata for users whose name or email matches the given search term.
    /// </summary>
    /// <param name="searchTerm">The partial name or email fragment to search for matching users.</param>
    /// <param name="keys">The optional list of metadata keys to retrieve for each user. If null, all metadata is returned.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A dictionary where the keys are user identifiers, and the values are dictionaries containing the requested
    ///     metadata. Returns null if no users match the search term.
    /// </returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNameOrEmailFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves a list of all users.
    /// </summary>
    /// <param name="luceneQuery"></param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of users.</returns>
    Task<IEnumerable<User>> ListUsers(string luceneQuery = "user_id:*", CancellationToken cancellationToken = default);

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
    /// <returns>An <see cref="string" /> token that can be used to reset password</returns>
    ITask<string?> ResetPassword(string email, CancellationToken cancellationToken);

    /// <summary>
    ///     Unblocks a user based on their email address, restoring their access to the system.
    /// </summary>
    /// <param name="email">The email address of the user to unblock.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    ITask<OkError> UnblockUser(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves metadata for users whose names or email addresses match the specified search term.
    /// </summary>
    /// <param name="searchTerm">The search string to match against usernames or email addresses.</param>
    /// <param name="orgUid">The unique identifier of the organization to which the users belong.</param>
    /// <param name="keys">A collection of metadata keys to filter the returned metadata.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task containing a dictionary where each key represents a user identifier,
    /// and the value contains a dictionary of metadata keys and their corresponding values.</returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNameOrEmailFragment(
        string searchTerm,
        string orgUid,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    /// Updates a user with the specified email by setting the provided key-value pairs.
    /// </summary>
    /// <param name="identityId"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ITask<OkError> UpdateUser(string identityId, UserUpdateRequest request, CancellationToken cancellationToken);
    /// <summary>
    ///     Creates a new user in Auth0 and returns an OkError result.
    /// </summary>
    /// <param name="userCreateRequest">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing an OkError result.</returns>
    ITask<OkError> CreateUserWithResult(UserCreateRequest userCreateRequest, CancellationToken cancellationToken);
    /// <summary>
    /// Change the password for a user identified by the provided identityId.
    /// </summary>
    /// <param name="identityId"></param>
    /// <param name="newPassword"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ITask<OkError> ChangePasswordWithIdentityId(string identityId, string newPassword, CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves metadata for users whose name match the provided search term.
    /// </summary>
    /// <param name="names">The names.</param>
    /// <param name="keys">
    ///     A collection of specific metadata keys to include in the result. If null, all available metadata
    ///     will be included.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that resolves to a dictionary where the keys are user identifiers, and the values are dictionaries of
    ///     metadata key-value pairs, or null if no matches are found.
    /// </returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNames(
        IEnumerable<string> names,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Retrieves metadata for users whose email or phone number match the provided search term.
    /// </summary>
    /// <param name="searchTerm">The searchTerm.</param>
    /// <param name="keys">
    ///     A collection of specific metadata keys to include in the result. If null, all available metadata
    ///     will be included.
    /// </param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    ///     A task that resolves to a dictionary where the keys are user identifiers, and the values are dictionaries of
    ///     metadata key-value pairs, or null if no matches are found.
    /// </returns>
    ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByEmailOrPhoneFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken);
}
