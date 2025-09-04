namespace Runner.Commands;

using Abstractions;

using DotMake.CommandLine;

using Messages;

using Microsoft.Extensions.Logging;

[CliCommand]
internal class AddUserToOrganizationCommand(IAuth0Client client, ILogger<AddUserToOrganizationCommand> logger)
{
    /// <summary>
    /// Gets or sets the OrgId.
    /// </summary>
    [CliOption]
    public string OrgId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the UserId.
    /// </summary>
    [CliOption]
    public string UserId { get; set; } = null!;
    
    public async Task RunAsync(CliContext context)
    {
        await client.AddUserToOrganization(this.UserId, this.OrgId, context.CancellationToken);
        logger.UserAddedToOrganization(this.UserId, this.OrgId);
    }
}