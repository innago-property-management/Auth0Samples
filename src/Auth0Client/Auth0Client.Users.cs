namespace Auth0Client;

using Abstractions;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

using Innago.Shared.TryHelpers;

using MorseCode.ITask;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

public partial class Auth0Client
{
    /// <summary>
    /// Creates a new user in Auth0.
    /// </summary>
    /// <param name="userCreateInfo">The information required to create the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the created user.</returns>
    public async Task<User> CreateUser(UserCreateInfo userCreateInfo, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        UserCreateRequest request = new()
        {
            Email = userCreateInfo.Email,
            FirstName = userCreateInfo.FirstName,
            LastName = userCreateInfo.LastName,
            EmailVerified = false,
            VerifyEmail = false,
            Password = userCreateInfo.Password,
            Connection = this.auth0DatabaseName,
        };

        return await client.Users.CreateAsync(request, cancellationToken);
    }

    /// <summary>
    /// Retrieves a list of all users from Auth0.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the list of users.</returns>
    public async Task<IEnumerable<User>> ListUsers(CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        GetUsersRequest request = new()
        {
            Connection = this.auth0DatabaseName,
            Sort = "user_id:1",
            Query = "user_id:*",
            Fields = "user_id,email,name,last_login",
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
    /// Initiates a password reset for the specified user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the password reset request.</returns>
    public async ITask<OkError> ResetPassword(string email, CancellationToken cancellationToken)
    {
        Console.WriteLine($"InitiatePasswordReset called with request {email} step 1");

        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        PasswordChangeTicketRequest request = new()
        {
            Email = email,
            ConnectionId = this.auth0ConnectionName,
        };
        Console.WriteLine($"InitiatePasswordReset called with request {email} step 2");

        Result<Ticket?> result = await TryHelpers.TryAsync(() => client.Tickets.CreatePasswordChangeTicketAsync(request, cancellationToken)!)
            .ConfigureAwait(false);

        var response = new OkError
        {
            OK = result.HasSucceeded,
            Error = ((Exception?)result)?.Message,
        };
        Console.WriteLine($"InitiatePasswordReset response: {response.OK}, {response.Error}");
        return response;
    }

    /// <summary>
    /// Marks a user as suspicious in Auth0.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the operation.</returns>
    public ITask<OkError> MarkUserAsSuspicious(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserMetadata(email, new FraudStatus(Suspicious: true), cancellationToken);
    }

    /// <summary>
    /// Marks a user as fraudulent in Auth0.
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
    /// Changes the password for the specified user.
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
    /// Enables or disables Multi-Factor Authentication for the specified user.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <param name="enable">True to enable MFA, false to disable it.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the MFA toggle.</returns>
    public async ITask<OkError> ToggleMFA(string email, bool enable, CancellationToken cancellationToken)
    {
        OkError userMetadataUpdated = await this.UpdateUserMetadata(email, new TwoFactorEnabled(enable), cancellationToken);

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

        return await getUsersResult.Map(OnSuccess, OnError!)!;

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

                IReadOnlyDictionary<string, string?>? flattened = userMetadata?
                    .Where(pair => keys == null || keys.Contains(pair.Key))
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.ToString())
                    .AsReadOnly();

                return Task.FromResult(flattened);
            }
        }

        Task<IReadOnlyDictionary<string, string?>?>? OnError(Exception exception)
        {
            logger.Error(exception);
            return Task.FromException<IReadOnlyDictionary<string, string?>?>(exception);
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

                return new OkError(OK: updateResult.HasSucceeded, Error: ((Exception?)updateResult)?.Message);
            }
        }
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

    public ITask<OkError> BlockUser(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserBlockStatus(email, true, cancellationToken);
    }

    public ITask<OkError> UnblockUser(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserBlockStatus(email, false, cancellationToken);
    }

    public async ITask<TokenResponsePayload<TokenResponse>?> GetTokenAsyncImplementation(string username, string password, IEnumerable<string>? keys, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(username), username)]);

        var tokenEndpoint = $"{this.auth0Domain}/oauth/token";
        var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint)
        {
            Content = this.MakeTokenContent(username, password)
        };
        Result<HttpResponseMessage?> response = await TryHelpers.TryAsync(() =>
                this.httpClient.SendAsync(request, cancellationToken)!)
            .ConfigureAwait(false);

        TokenResponsePayload<TokenResponse> payload = await response.Map(OnSuccessDeserializeToken(cancellationToken)!, OnError(logger))!.ConfigureAwait(false);

        return payload; // this contains access_token, id_token, etc.
    }

    public async ITask<TokenResponsePayload<TokenResponse>?> GetRefreshTokenAsyncImplementation(string refreshToken, IEnumerable<string>? keys, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(refreshToken), default)]);

        var tokenEndpoint = $"{this.auth0Domain}/oauth/token";
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

    private FormUrlEncodedContent MakeTokenContent(string username, string password)
    {
        FormUrlEncodedContent requestContent = new([
            new KeyValuePair<string, string>("grant_type", "http://auth0.com/oauth/grant-type/password-realm"),
            new KeyValuePair<string, string>("username", username ?? string.Empty),
            new KeyValuePair<string, string>("password", password ?? string.Empty),
            new KeyValuePair<string, string>("audience", this.auth0Audience ?? string.Empty),
            new KeyValuePair<string, string>("scope", "read:sample offline_access" ?? string.Empty),
            new KeyValuePair<string, string>("client_id", this.auth0ClientId ?? string.Empty),
            new KeyValuePair<string, string>("client_secret", this.auth0ClientSecret ?? string.Empty),
            new KeyValuePair<string, string>("realm", this.auth0ConnectionName ?? string.Empty),
            new KeyValuePair<string, string>("connection", this.auth0ConnectionName ?? string.Empty)
        ]);

        return requestContent;
    }

    private FormUrlEncodedContent MakeRefreshTokenContent(string refreshToken)
    {
        FormUrlEncodedContent requestContent = new([
            new KeyValuePair<string, string>("grant_type", "refresh_token"),
            new KeyValuePair<string, string>("refresh_token", refreshToken ?? string.Empty),
            new KeyValuePair<string, string>("client_id", this.auth0ClientId ?? string.Empty),
            new KeyValuePair<string, string>("client_secret", this.auth0ClientSecret ?? string.Empty)
        ]);

        return requestContent;
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
#pragma warning disable S1172
    private static Func<Exception?, Task<TokenResponsePayload<TokenResponse>>> OnError(ILogger<Auth0Client> logger, [CallerMemberName] string? memberName = null)
#pragma warning restore S1172
    {
        return LogAndReturn;

        Task<TokenResponsePayload<TokenResponse>> LogAndReturn(Exception? exception)
        {
            Action logError = memberName switch
            {
                nameof(GetTokenAsyncImplementation) => () => logger.Error(exception),
                nameof(GetRefreshTokenAsyncImplementation) => () => logger.Error(exception),
            };

            logError();

            TokenResponsePayload<TokenResponse> payload = new()
            {
                Result = default,
                Error = exception?.Message,
            };

            return Task.FromResult(payload);
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

    [UsedImplicitly]
    private sealed record FraudStatus(bool? Suspicious = null, bool? Fraudulent = null);

    private sealed record TwoFactorEnabled([property: JsonPropertyName("two_factor_enabled")] bool? Enabled = false);
}
