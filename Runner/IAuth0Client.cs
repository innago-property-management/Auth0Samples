namespace Runner;

using Auth0.ManagementApi.Models;

internal interface IAuth0Client
{
   Task<User> CreateUser(CancellationToken cancellationToken);
}