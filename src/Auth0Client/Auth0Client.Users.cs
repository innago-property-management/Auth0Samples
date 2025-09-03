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

public partial class Auth0Client
{
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
            Connection = Auth0Client.Auth0DatabaseName,
        };

        return await client.Users.CreateAsync(request, cancellationToken);
    }

    public async Task<IEnumerable<User>> ListUsers(CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        GetUsersRequest request = new()
        {
            Connection = Auth0Client.Auth0DatabaseName,
            Sort = "user_id:1",
            Query = "user_id:*",
            Fields = "user_id,email,name,last_login",
            IncludeFields = true,
            SearchEngine = "v3",
        };

        var pageNo = 0;
        const int perPage = 100;
        bool hasMore;
        List<User> users = [];
        var usersProcessed = 0;

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

    public async ITask<OkError> ResetPassword(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client);

        PasswordChangeTicketRequest request = new()
        {
            Email = email,
            ConnectionId = Auth0Client.Auth0ConnectionName,
        };

        Result<Ticket?> result = await TryHelpers.TryAsync(() => client.Tickets.CreatePasswordChangeTicketAsync(request, cancellationToken)!)
            .ConfigureAwait(false);

        return new OkError
        {
            OK = result.HasSucceeded,
            Error = ((Exception?)result)?.Message,
        };
    }

    public ITask<OkError> MarkUserAsSuspicious(string email, CancellationToken cancellationToken)
    {
        using Activity? activity = Auth0ClientTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(email), email)]);
        return this.UpdateUserMetadata(email, new FraudStatus(Suspicious: true), cancellationToken);
    }

    public async ITask<OkError> ToggleMFA(string email, bool enable, CancellationToken cancellationToken)
    {
        OkError userMetadataUpdated = await this.UpdateUserMetadata(email, new TwoFactorEnabled(enable), cancellationToken);
        if(!userMetadataUpdated.OK)
        {
            return userMetadataUpdated;
        }
        return await this.RemoveAuthenticationMethods(email, cancellationToken);
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
                User user = users!.First();
                string userId = user!.UserId;
                Result updateResult = await TryHelpers.TryAsync(() => client.Users.DeleteAuthenticationMethodsAsync(userId, cancellationToken)!).ConfigureAwait(false);
                return new(OK: updateResult.HasSucceeded, Error: ((Exception?)updateResult)?.Message);
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
                User user = users!.First();
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

    private record FraudStatus(bool? Suspicious = null, bool? Fraudulent = null);
    private record TwoFactorEnabled([property: JsonPropertyName("two_factor_enabled")] bool? twoFactorEnabled = false);
}
