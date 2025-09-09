namespace Runner.Commands;

using Abstractions;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Messages;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["getusers"])]
internal class GetUserCommand(IAuth0Client client, ILogger<GetUserCommand> logger)
{
    [CliOption(Description = "The oruId.", Required = true)]
    public string OruUid { get; set; } = null!;

    public async Task RunAsync(CliContext context)
    {
        User users = await client.GetUser(this.OruUid, context.CancellationToken);
        logger.GetUser(users.UserId);
    }
}
