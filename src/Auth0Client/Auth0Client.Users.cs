namespace Auth0Client;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Abstractions;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

using Innago.Shared.TryHelpers;

using MorseCode.ITask;

public partial class Auth0Client
{
    public async Task<User> CreateUser(UserCreateInfo userCreateInfo, CancellationToken cancellationToken)
    {
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
        PasswordChangeTicketRequest request = new()
        {
            Email = email,
            ConnectionId = Auth0Client.Auth0ConnectionName,
        };

        Result<Ticket?> result = await TryHelpers.TryAsync(() => client.Tickets.CreatePasswordChangeTicketAsync(request, cancellationToken)!).ConfigureAwait(false);

        return new OkError
        {
            OK = result.HasSucceeded,
            Error = ((Exception?)result)?.Message,
        };
    }
}
