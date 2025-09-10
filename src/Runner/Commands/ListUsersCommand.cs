namespace Runner.Commands;

using Abstractions;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Messages;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["users"])]
internal class ListUsersCommand(IAuth0Client client, ILogger<ListUsersCommand> logger)
{
    public async Task RunAsync(CliContext context)
    {
        List<User> users = (await client.ListUsers(cancellationToken: context.CancellationToken).ConfigureAwait(false)).ToList();

        users.ForEach(user => logger.User(user.UserId, user.Email, user.FullName, user.LastLogin));
    }
}
