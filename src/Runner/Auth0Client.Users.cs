namespace Runner;

using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

internal partial class Auth0Client
{
    public Task<User> CreateUser(CancellationToken cancellationToken)
    {
        UserCreateRequest request = new()
        {
            Email = Faker.Person.Email,
            FirstName = Faker.Person.FirstName,
            LastName = Faker.Person.LastName,
            EmailVerified = false,
            VerifyEmail = false,
            Password = $"{Faker.Internet.Password(16)}-Aa1!",
            Connection = Auth0Client.Auth0DatabaseName,
        };

        return client.Users.CreateAsync(request, cancellationToken);
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
            IPagedList<User>? pagedList = await client.Users.GetAllAsync(request, paginationInfo, cancellationToken).ConfigureAwait(false);

            users.AddRange(pagedList);

            pageNo += 1;
            usersProcessed += pagedList.Paging.Length;
            hasMore = pagedList.Paging.Total > usersProcessed;
        } while (hasMore);

        return users;
    }
}