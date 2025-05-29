namespace Runner;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand]
internal class CreateUserCommand(IAuth0Client client, ILogger<CreateUserCommand> logger)
{
    public async Task RunAsync(CliContext context)
    {
        User user = await client.CreateUser(context.CancellationToken).ConfigureAwait(false);

        logger.UserCreated(user);
    }
}