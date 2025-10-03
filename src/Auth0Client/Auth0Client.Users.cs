namespace Auth0Client;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Abstractions;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

using Innago.Shared.TryHelpers;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;

using MorseCode.ITask;

using Newtonsoft.Json.Linq;

public partial class Auth0Client
{
    private const string Email = "email";
    private const string FirstName = "given_name";
    private const string LastName = "family_name";
    private const int MinSearchLength = 3;

    /// <summary>
    ///     Creates a new user in Auth0.
    /// </summary>
    /// <param name="userCreateInfo">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created user.</returns>
    public async Task<User?> CreateUser(UserCreateInfo userCreateInfo, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        const bool emailVerified = false;
        UserCreateRequest request = new()
        {
            Email = userCreateInfo.Email,
            FirstName = userCreateInfo.FirstName,
            LastName = userCreateInfo.LastName,
            EmailVerified = emailVerified,
            VerifyEmail = true,
            Password = userCreateInfo.Password,
            Connection = this.auth0DatabaseName ?? throw new InvalidOperationException(),
        };

        return await this.CreateUserImplementation(request, cancellationToken: cancellationToken);
    }
    /// <summary>
    /// Creates a new user in Auth0 using the provided UserCreateRequest.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<User> CreateUserImplementation(UserCreateRequest userCreateRequest, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);
        userCreateRequest.Connection = this.auth0DatabaseName ?? throw new InvalidOperationException();
        return await client.Users.CreateAsync(userCreateRequest, cancellationToken);
    }

    /// <summary>
    ///     Get a user
    /// </summary>
    /// <param name="oruUid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User> GetUser(string oruUid, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);
        string id = "auth0|" + oruUid;
        return await client.Users.GetAsync(id, null!, true, cancellationToken);
    }

    /// <summary>
    ///     Gets List of Users per their Ids
    /// </summary>
    /// <param name="oruUid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns a list of user</returns>
    public async Task<List<User>> GetUsers(string[] oruUid, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        string query = string.Join(" OR ", oruUid.Select(uid => $"user_metadata.user_id:\"{uid}\""));

        GetUsersRequest request = new()
        {
            Connection = this.auth0DatabaseName ?? throw new InvalidOperationException(),
            Sort = "user_id:1",
            Query = query,
            SearchEngine = "v3",
        };

        int pageNo = 0;
        const int perPage = 100;
        bool hasMore;
        List<User> users = [];
        int usersProcessed = 0;

        do
        {
            PaginationInfo paginationInfo = new(pageNo, perPage, true);
            IPagedList<User> pagedList = await client.Users.GetAllAsync(request, paginationInfo, cancellationToken).ConfigureAwait(false);

            users.AddRange(pagedList);

            pageNo += 1;
            usersProcessed += pagedList.Count;
            hasMore = pagedList.Paging.Total > usersProcessed;
        } while (hasMore);

        return users;
    }

    /// <summary>
    ///     Retrieves a list of all users from Auth0.
    /// </summary>
    /// <param name="luceneQuery"></param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of users.</returns>
    public async Task<IEnumerable<User>> ListUsers(string luceneQuery = "user_id:*", CancellationToken cancellationToken = default)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        GetUsersRequest request = new()
        {
            Connection = this.auth0DatabaseName ?? throw new InvalidOperationException(),
            Sort = "user_id:1",
            Query = luceneQuery,
            IncludeFields = true,
            SearchEngine = "v3",
        };

        int pageNo = 0;
        const int perPage = 100;
        bool hasMore;
        List<User> users = [];
        int usersProcessed = 0;

        do
        {
            PaginationInfo paginationInfo = new(pageNo, perPage, true);
            IPagedList<User> pagedList = await client.Users.GetAllAsync(request, paginationInfo, cancellationToken).ConfigureAwait(false);

            users.AddRange(pagedList);

            pageNo += 1;
            usersProcessed += pagedList.Paging.Length;
            hasMore = pagedList.Paging.Total > usersProcessed;
        } while (hasMore);

        return users;
    }

    /// <summary>
    ///     Initiates a password reset for the specified user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the password reset request.</returns>
    public async ITask<string?> ResetPassword(string email, CancellationToken cancellationToken)
    {
        Console.WriteLine($"InitiatePasswordReset called with request {email} step 1");

        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        Console.WriteLine($"ResetPassword step 1 email : {email}");

        PasswordChangeTicketRequest request = new()
        {
            Email = email,
            ConnectionId = this.auth0ConnectionName ?? throw new InvalidOperationException(),
        };

        Console.WriteLine($"InitiatePasswordReset called with request {email} step 2");

        Result<Ticket?> result = await TryHelpers.TryAsync(() => client.Tickets.CreatePasswordChangeTicketAsync(request, cancellationToken)!)
            .ConfigureAwait(false);

        Console.WriteLine($"ResetPassword step 2 email : {email}");

        return await result.Map(ReturnUrl, ChangePasswordError)!;

        static Task<string> ReturnUrl(Ticket? ticket)
        {
            return Task.FromResult(ticket?.Value ?? string.Empty);
        }

        Task<string>? ChangePasswordError(Exception? exception)
        {
            logger.Error(exception);
            return Task.FromException<string>(exception!);
        }
    }

    /// <summary>
    ///     Marks a user as suspicious in Auth0.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the operation.</returns>
    public ITask<OkError> MarkUserAsSuspicious(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserMetadata(email, new FraudStatus(true), cancellationToken);
    }

    /// <summary>
    ///     Marks a user as fraudulent in Auth0.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the operation.</returns>
    public ITask<OkError> MarkUserAsFraud(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserMetadata(email, new FraudStatus(Fraudulent: true), cancellationToken);
    }

    /// <summary>
    ///     Changes the password for the specified user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="newPassword">The new password to set.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the password change.</returns>
    public async ITask<OkError> ChangePassword(string email, string newPassword, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);

        Result<IList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetUsersByEmailAsync(email.ToLowerInvariant(), "user_id", cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(UpdateUserPassword, GetUsersError)!;

        static Task<OkError> GetUsersError(Exception? exception)
        {
            return Task.FromResult(new OkError(Error: exception?.Message ?? string.Empty));
        }

        async Task<OkError> UpdateUserPassword(IList<User>? users)
        {
            return await (users?.Count == 1).Map(OnTrue, MoreThanOneUserFound)!;

            Task<OkError> MoreThanOneUserFound()
            {
                const string? error = "more than one user found";
                // ReSharper disable once AccessToDisposedClosure
                activity?.AddException(new Exception(error));
                return Task.FromResult(new OkError(Error: error));
            }

            async Task<OkError> OnTrue()
            {
                User user = users![0];
                string id = user.UserId;

                UserUpdateRequest request = new()
                {
                    Password = newPassword,
                };

                Result<User?> updateResult = await TryHelpers.TryAsync(() => client.Users.UpdateAsync(id, request, cancellationToken)!).ConfigureAwait(false);

                return updateResult.Map<Result>(_ => Result.Success,
                    exception =>
                    {
                        // ReSharper disable once AccessToDisposedClosure
                        activity?.AddException(exception!);
                        return exception!;
                    });
            }
        }
    }

    /// <summary>
    ///     Disables Multi-Factor Authentication for the specified user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the MFA toggle.</returns>
    public async ITask<OkError> DisableMfa(string email, CancellationToken cancellationToken)
    {
        OkError userMetadataUpdated =
            await this.UpdateUserMetadata(email, new Dictionary<string, object> { ["two_factor_enabled"] = false }, cancellationToken);

        if (!userMetadataUpdated.OK)
        {
            return userMetadataUpdated;
        }

        return await this.RemoveAuthenticationMethods(email, cancellationToken);
    }

    /// <inheritdoc />
    public async ITask<IReadOnlyDictionary<string, string?>?> GetUserMetadata(
        string email,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);

        keys = keys?.ToList();

        Result<IList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetUsersByEmailAsync(email.ToLowerInvariant(), "user_metadata", cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(OnSuccess, GetUserError!)!;

        Task<IReadOnlyDictionary<string, string?>?> OnSuccess(IList<User>? users)
        {
            return (users?.Count == 1).Map(GetMetadata, SingleMatchNotFound)!;

            static Task<IReadOnlyDictionary<string, string?>?> SingleMatchNotFound()
            {
                return Task.FromResult<IReadOnlyDictionary<string, string?>?>(null);
            }

            Task<IReadOnlyDictionary<string, string?>?> GetMetadata()
            {
                var userMetadata = (IDictionary<string, JToken?>?)users?[0].UserMetadata;

                IReadOnlyDictionary<string, string?>? flattened = MapUserMetadata(userMetadata, keys);

                return Task.FromResult(flattened);
            }
        }

        Task<IReadOnlyDictionary<string, string?>?>? GetUserError(Exception exception)
        {
            logger.Error(exception);
            return Task.FromException<IReadOnlyDictionary<string, string?>?>(exception);
        }
    }

    /// <inheritdoc />
    public async ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNameOrEmailFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        searchTerm = searchTerm.Trim();

        if (searchTerm.Length < Auth0Client.MinSearchLength)
        {
            return null;
        }

        searchTerm = searchTerm.SanitizeSearchTerm();

        string searchCriteria = $"{Auth0Client.FirstName}:{searchTerm}* or {Auth0Client.Email}:{searchTerm}* or {Auth0Client.LastName}:{searchTerm}*";

        IEnumerable<User> users = await this.ListUsers(searchCriteria, cancellationToken).ConfigureAwait(false);

        return users.ToDictionary(user => user.Email, IReadOnlyDictionary<string, string?>? (user) => MapUserMetadata(user.UserMetadata, keys));
    }

    /// <inheritdoc />
    public async ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNameOrEmailFragment(
        string searchTerm,
        string orgUid,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        searchTerm = searchTerm.Trim();

        if (searchTerm.Length < Auth0Client.MinSearchLength)
        {
            return null;
        }

        searchTerm = searchTerm.SanitizeSearchTerm();

        string searchCriteria = $"{Auth0Client.FirstName}:{searchTerm}* or {Auth0Client.Email}:{searchTerm}* or {Auth0Client.LastName}:{searchTerm}*";

        searchCriteria = $"({searchCriteria}) and user_metadata.organizationuid:{orgUid}";

        IEnumerable<User> users = await this.ListUsers(searchCriteria, cancellationToken).ConfigureAwait(false);

        return users.ToDictionary(user => user.Email, IReadOnlyDictionary<string, string?>? (user) => MapUserMetadata(user.UserMetadata, keys));
    }

    /// <inheritdoc />
    public async ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByEmailFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        searchTerm = searchTerm.Trim();

        if (searchTerm.Length < Auth0Client.MinSearchLength)
        {
            return null;
        }

        searchTerm = searchTerm.SanitizeSearchTerm();

        string searchCriteria = $"{Auth0Client.Email}:*{searchTerm}*";

        IEnumerable<User> users = await this.ListUsers(searchCriteria, cancellationToken).ConfigureAwait(false);

        return users.ToDictionary(user => user.Email, IReadOnlyDictionary<string, string?>? (user) => MapUserMetadata(user.UserMetadata, keys));
    }

    /// <inheritdoc />
    public async ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByNameFragment(
        string searchTerm,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        searchTerm = searchTerm.Trim();

        if (searchTerm.Length < Auth0Client.MinSearchLength)
        {
            return null;
        }

        searchTerm = searchTerm.SanitizeSearchTerm();

        string searchCriteria = $"{Auth0Client.FirstName}:{searchTerm}* or {Auth0Client.LastName}:{searchTerm}*";

        IEnumerable<User> users = await this.ListUsers(searchCriteria, cancellationToken).ConfigureAwait(false);

        return users.ToDictionary(user => user.Email, IReadOnlyDictionary<string, string?>? (user) => MapUserMetadata(user.UserMetadata, keys));
    }

    /// <summary>
    ///     Blocks a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to block.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the block action.</returns>
    public ITask<OkError> BlockUser(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserBlockStatus(email, true, cancellationToken);
    }

    /// <summary>
    ///     Unblocks a user in the Auth0 system.
    /// </summary>
    /// <param name="email">The email address of the user to unblock.</param>
    /// <param name="cancellationToken">A token to cancel the unblock operation.</param>
    /// <returns>An asynchronous task containing the result of the unblock operation.</returns>
    public ITask<OkError> UnblockUser(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserBlockStatus(email, false, cancellationToken);
    }

    /// <summary>
    ///     Creates a new user in Auth0 and returns an OkError result.
    /// </summary>
    /// <param name="userCreateRequest">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing an OkError result.</returns>
    public async ITask<OkError> CreateUserWithResult(UserCreateRequest userCreateRequest, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(userCreateRequest.Email), userCreateRequest.Email)]);
        
        Result<User?> createResult = await TryHelpers.TryAsync(() => this.CreateUserImplementation(userCreateRequest, cancellationToken)!).ConfigureAwait(false);

        return createResult.Map<Result>(_ => Result.Success,
            exception =>
            {
                activity?.AddException(exception!);
                return exception!;
            });
    }

    /// <summary>
    /// Enables Multi-Factor Authentication (MFA) for a user
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>An <see cref="OkError" /> object indicating success or containing an error message if the operation fails.</returns>
    public ITask<OkError> EnableMfa(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserMetadata(email, new Dictionary<string, object> { ["two_factor_enabled"] = true }, cancellationToken);
    }

    /// <inheritdoc />
    public async ITask<IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>?> GetUsersMetadataByEmailAddresses(
        IEnumerable<string> emailAddresses,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        emailAddresses = emailAddresses.Select(email => email.ToLowerInvariant().Trim().SanitizeSearchTerm()).ToList();

        string searchCriteria = emailAddresses.Aggregate(string.Empty,
            (agg, current) => $"{agg}{(!string.IsNullOrEmpty(agg) ? " or " : string.Empty)}{Auth0Client.Email}:{current}");

        IEnumerable<User> users = await this.ListUsers(searchCriteria, cancellationToken).ConfigureAwait(false);

        return users.DistinctBy(user => user.Email).ToDictionary(user => user.Email, IReadOnlyDictionary<string, string?>? (user) => MapUserMetadata(user.UserMetadata, keys));
    }
    /// <inheritdoc/>
    public async ITask<OkError> UpdateUser(string identityId, UserUpdateRequest request, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(identityId), identityId)]);
        GetUsersRequest getUsersRequest = new()
        {
            Query = $"user_metadata.identity_id:\"{identityId}\"",
            SearchEngine = "v3",
        };
        Result<IPagedList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetAllAsync(getUsersRequest, cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(UpdateUser, GetUsersError)!;

        Task<OkError> GetUsersError(Exception? exception)
        {
            logger.Information($"Error getting user with identityId {identityId}: {exception?.Message}");
            return Task.FromResult(new OkError(false, Error: exception?.Message ?? string.Empty));
        }

        async Task<OkError> UpdateUser(IList<User>? users)
        {
            if (users == null || !users.Any())
            {
                logger.Information("No User found to update");
                return new OkError(false, Error: "No User found to update");
            }
            User user = users![0];  //in case due to an error more than one user is returned, we will update ONLY the first one
            string id = user.UserId;

            Result<User?> updateResult = await TryHelpers.TryAsync(() => client.Users.UpdateAsync(id, request, cancellationToken)!).ConfigureAwait(false);

            return updateResult.Map<Result>(_ => Result.Success,
                exception =>
                {
                    // ReSharper disable once AccessToDisposedClosure
                    activity?.AddException(exception!);
                    return exception!;
                });
        }
    }
    /// <inheritdoc/>
    public async ITask<OkError> ChangePasswordWithIdentityId(string identityId, string newPassword, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(identityId), identityId)]);
        GetUsersRequest getUsersRequest = new()
        {
            Query = $"user_metadata.identity_id:\"{identityId}\"",
            SearchEngine = "v3",
        };
        Result<IPagedList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetAllAsync(getUsersRequest, cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(UpdateUserPassword, GetUsersError)!;

        static Task<OkError> GetUsersError(Exception? exception)
        {
            return Task.FromResult(new OkError(Error: exception?.Message ?? string.Empty));
        }

        async Task<OkError> UpdateUserPassword(IList<User>? users)
        {
            return await (users?.Count == 1).Map(OnTrue, MoreThanOneUserFound)!;

            Task<OkError> MoreThanOneUserFound()
            {
                const string? error = "more than one user found";
                // ReSharper disable once AccessToDisposedClosure
                activity?.AddException(new Exception(error));
                return Task.FromResult(new OkError(Error: error));
            }

            async Task<OkError> OnTrue()
            {
                User user = users![0];
                string id = user.UserId;

                UserUpdateRequest request = new()
                {
                    Password = newPassword,
                };

                Result<User?> updateResult = await TryHelpers.TryAsync(() => client.Users.UpdateAsync(id, request, cancellationToken)!).ConfigureAwait(false);

                return updateResult.Map<Result>(_ => Result.Success,
                    exception =>
                    {
                        // ReSharper disable once AccessToDisposedClosure
                        activity?.AddException(exception!);
                        return exception!;
                    });
            }
        }
    }
    private FormUrlEncodedContent MakeRefreshTokenContent(string? refreshToken)
    {
        FormUrlEncodedContent requestContent = new([
            new KeyValuePair<string, string>("grant_type", "refresh_token"),
            new KeyValuePair<string, string>("refresh_token", refreshToken ?? string.Empty),
            new KeyValuePair<string, string>("client_id", this.auth0ClientId ?? string.Empty),
            new KeyValuePair<string, string>("client_secret", this.auth0ClientSecret ?? string.Empty),
        ]);

        return requestContent;
    }

    private static IReadOnlyDictionary<string, string?>? MapUserMetadata(IDictionary<string, JToken?>? userMetadata, IEnumerable<string>? keys = null)
    {
        IReadOnlyDictionary<string, string?>? dictionary = userMetadata?
            .Where(pair => keys == null || keys.Contains(pair.Key))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.ToString())
            .AsReadOnly();

        return dictionary;
    }
#pragma warning disable S1172
    private static Func<Exception?, Task<TokenResponsePayload<TokenResponse>>> OnError(
        ILogger<Auth0Client> logger,
        [CallerMemberName] string? memberName = null)
#pragma warning restore S1172
    {
        return LogAndReturn;

        Task<TokenResponsePayload<TokenResponse>> LogAndReturn(Exception? exception)
        {
            logger.Error(exception);

            TokenResponsePayload<TokenResponse> payload = new()
            {
                Result = default,
                Error = exception?.Message,
            };

            return Task.FromResult(payload);
        }
    }

    private static Func<HttpResponseMessage, Task<TokenResponsePayload<TokenResponse>>> OnSuccessDeserializeToken(CancellationToken cancellationToken)
    {
        return DeserializeToken;

        async Task<TokenResponsePayload<TokenResponse>> DeserializeToken(HttpResponseMessage response)
        {
            TokenResponse tokenResponse =
                await response.IsSuccessStatusCode.Map(OnSuccessStatusCodeTrueDeserializeToken(response, cancellationToken),
                    OnSuccessStatusCodeFalseReturnDefault)!;

            return new TokenResponsePayload<TokenResponse>
            {
                Result = tokenResponse,
                Error = response.IsSuccessStatusCode ? null : response.ReasonPhrase,
            };
        }
    }

    private static Task<TokenResponse> OnSuccessStatusCodeFalseReturnDefault()
    {
        TokenResponse tokenResponse = new();
        return Task.FromResult(tokenResponse);
    }

    private static Func<Task<TokenResponse>> OnSuccessStatusCodeTrueDeserializeToken(HttpResponseMessage message, CancellationToken cancellationToken)
    {
        return DeserializeToken;

        async Task<TokenResponse> DeserializeToken()
        {
            return await JsonSerializer.DeserializeAsync<TokenResponse>(await message.Content.ReadAsStreamAsync(cancellationToken),
                cancellationToken: cancellationToken);
        }
    }

    private async ITask<OkError> RemoveAuthenticationMethods(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);

        Result<IList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetUsersByEmailAsync(email.ToLowerInvariant(), "user_id", cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(DeleteAuthenticationMethods!, GetUsersError)!;

        static Task<OkError> GetUsersError(Exception? exception)
        {
            return Task.FromResult(new OkError(Error: exception?.Message ?? string.Empty));
        }

        async Task<OkError> DeleteAuthenticationMethods(IList<User?> users)
        {
            return await (users.Count == 1).Map(OnTrue, MoreThanOneUserFound)!;

            Task<OkError> MoreThanOneUserFound()
            {
                const string? error = "more than one user found";
                // ReSharper disable once AccessToDisposedClosure
                activity?.AddException(new Exception(error));
                return Task.FromResult(new OkError(Error: error));
            }

            async Task<OkError> OnTrue()
            {
                User user = users[0]!;
                string userId = user.UserId;

                Result updateResult = await TryHelpers.TryAsync(() => client.Users.DeleteAuthenticationMethodsAsync(userId, cancellationToken))
                    .ConfigureAwait(false);

                return new OkError(updateResult.HasSucceeded, ((Exception?)updateResult)?.Message);
            }
        }
    }

    private async ITask<OkError> UpdateUserBlockStatus(string email, bool blocked, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);

        Result<IList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetUsersByEmailAsync(email.ToLowerInvariant(), "user_id", cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(UpdateUserBlock, GetUsersError)!;

        static Task<OkError> GetUsersError(Exception? exception)
        {
            return Task.FromResult(new OkError(Error: exception?.Message ?? string.Empty));
        }

        async Task<OkError> UpdateUserBlock(IList<User>? users)
        {
            return await (users?.Count == 1).Map(OnTrue, MoreThanOneUserFound)!;

            Task<OkError> MoreThanOneUserFound()
            {
                const string? error = "more than one user found";
                // ReSharper disable once AccessToDisposedClosure
                activity?.AddException(new Exception(error));
                return Task.FromResult(new OkError(Error: error));
            }

            async Task<OkError> OnTrue()
            {
                User user = users![0];
                string id = user.UserId;

                UserUpdateRequest request = new()
                {
                    Blocked = blocked,
                };

                Result<User?> updateResult = await TryHelpers.TryAsync(() => client.Users.UpdateAsync(id, request, cancellationToken)!).ConfigureAwait(false);

                return updateResult.Map<Result>(_ => Result.Success,
                    exception =>
                    {
                        // ReSharper disable once AccessToDisposedClosure
                        activity?.AddException(exception!);
                        return exception!;
                    });
            }
        }
    }

    /// <summary>
    /// Retrieves a token for the specified user by authenticating with the provided credentials.
    /// </summary>
    /// <param name="username">The username of the user attempting authentication.</param>
    /// <param name="password">The password of the user for authentication.</param>
    /// <param name="keys">Optional additional keys used in the token request.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing a <see cref="TokenResponsePayload{TokenResponse}"/> instance with the retrieved token information.
    /// </returns>
    public async ITask<TokenResponsePayload<TokenResponse>> GetTokenAsyncImplementation(
        string username,
        string password,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        using Activity? activity =
            Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(username), username)]);

        logger.Information($"GetTokenAsyncImplementation called for user {username}");
        string tokenEndpoint = $"https://{this.auth0Domain}/oauth/token";

        var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint)
        {
            Content = this.MakeTokenContent(username, password)
        };

        Result<HttpResponseMessage?> response = await TryHelpers.TryAsync(() =>
                this.httpClient.SendAsync(request, cancellationToken)!)
            .ConfigureAwait(false);

        logger.Information($"GetTokenAsyncImplementation succeeded: {response.HasSucceeded}");
        TokenResponsePayload<TokenResponse> payload = await response.Map(OnSuccessDeserializeToken(cancellationToken)!, OnError(logger))!.ConfigureAwait(false);

        return payload; // this contains access_token, id_token, etc.
    }

    /// <summary>
    /// Retrieves a new token using a refresh token.
    /// </summary>
    /// <param name="refreshToken">The refresh token used to request a new access token.</param>
    /// <param name="keys">Optional keys used as additional parameters for the token request.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the token response payload.</returns>
    public async ITask<TokenResponsePayload<TokenResponse>> GetRefreshTokenAsyncImplementation(
        string refreshToken,
        IEnumerable<string>? keys,
        CancellationToken cancellationToken)
    {
        using Activity? activity =
            Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(refreshToken), null)]);

        string tokenEndpoint = $"https://{this.auth0Domain}/oauth/token";

        var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint)
        {
            Content = this.MakeRefreshTokenContent(refreshToken)
        };

        Result<HttpResponseMessage?> response = await TryHelpers.TryAsync(() =>
                this.httpClient.SendAsync(request, cancellationToken)!)
            .ConfigureAwait(false);

        TokenResponsePayload<TokenResponse> payload = await response.Map(OnSuccessDeserializeToken(cancellationToken)!, OnError(logger))!.ConfigureAwait(false);

        return payload; // this contains access_token, id_token, etc.
    }

    private FormUrlEncodedContent MakeTokenContent(string? username, string? password)
    {
        FormUrlEncodedContent requestContent = new([
            new KeyValuePair<string, string>("grant_type", "http://auth0.com/oauth/grant-type/password-realm"),
            new KeyValuePair<string, string>("username", username ?? string.Empty),
            new KeyValuePair<string, string>("password", password ?? string.Empty),
            new KeyValuePair<string, string>("audience", this.auth0Audience ?? string.Empty),
            new KeyValuePair<string, string>("scope", "read:sample offline_access"),
            new KeyValuePair<string, string>("client_id", this.auth0ClientId ?? string.Empty),
            new KeyValuePair<string, string>("client_secret", this.auth0ClientSecret ?? string.Empty),
            new KeyValuePair<string, string>("realm", this.auth0DatabaseName ?? string.Empty),
            new KeyValuePair<string, string>("connection", this.auth0DatabaseName ?? string.Empty)
        ]);

        return requestContent;
    }

    private async ITask<OkError> UpdateUserMetadata(string email, dynamic metadata, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);

        Result<IList<User>?> getUsersResult = await TryHelpers
            .TryAsync(() => client.Users.GetUsersByEmailAsync(email.ToLowerInvariant(), "user_id", cancellationToken: cancellationToken)!)
            .ConfigureAwait(false);

        return await getUsersResult.Map(UpdateUser, GetUsersError)!;

        static Task<OkError> GetUsersError(Exception? exception)
        {
            return Task.FromResult(new OkError(Error: exception?.Message ?? string.Empty));
        }

        async Task<OkError> UpdateUser(IList<User>? users)
        {
            return await (users?.Count == 1).Map(OnTrue, MoreThanOneUserFound)!;

            Task<OkError> MoreThanOneUserFound()
            {
                const string? error = "more than one user found";
                // ReSharper disable once AccessToDisposedClosure
                activity?.AddException(new Exception(error));
                return Task.FromResult(new OkError(Error: error));
            }

            async Task<OkError> OnTrue()
            {
                User user = users![0];
                string id = user.UserId;

                UserUpdateRequest request = new()
                {
                    UserMetadata = metadata,
                };

                Result<User?> updateResult = await TryHelpers.TryAsync(() => client.Users.UpdateAsync(id, request, cancellationToken)!).ConfigureAwait(false);

                return updateResult.Map<Result>(_ => Result.Success,
                    exception =>
                    {
                        // ReSharper disable once AccessToDisposedClosure
                        activity?.AddException(exception!);
                        return exception!;
                    });
            }
        }
    }

    [UsedImplicitly]
    private sealed record FraudStatus(bool? Suspicious = null, bool? Fraudulent = null);
}
