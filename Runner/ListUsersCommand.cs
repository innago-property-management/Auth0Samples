namespace Runner;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

[CliCommand]
internal class ListUsersCommand(IAuth0Client client)
{
    public async Task RunAsync(CliContext context)
    {
        List<User> users = (await client.ListUsers(context.CancellationToken).ConfigureAwait(false)).ToList();

        users.ForEach(user => Console.WriteLine($"{user.UserId}\t{user.Email}\t{user.FullName}\t{user.LastLogin:O}"));
    }
}