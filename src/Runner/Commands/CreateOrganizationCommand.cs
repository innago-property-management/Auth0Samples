namespace Runner.Commands;

using Abstractions;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Messages;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["create-org"])]
internal class CreateOrganizationCommand(IAuth0Client client, ILogger<CreateOrganizationCommand> logger)
{
    [CliOption(Description = "The name of the organization to create [optional].", Required = false)]
    public string? Name { get; set; } 
    
    public async Task RunAsync(CliContext context)
    {
        OrganizationCreateInfo info = new(this.Name!);
        Organization organization = await client.CreateOrganization(info, context.CancellationToken).ConfigureAwait(false);

        logger.OrganizationCreated(organization);
    }
}
