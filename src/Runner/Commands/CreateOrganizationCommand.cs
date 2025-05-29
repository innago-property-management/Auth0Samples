namespace Runner.Commands;

using Abstractions;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["create-org"])]
internal class CreateOrganizationCommand(IAuth0Client client, ILogger<CreateOrganizationCommand> logger)
{
    [CliOption(Description = "The name of the organization to create [optional].", Required = false)]
    public string? Name { get; set; } 
    
    public async Task RunAsync(CliContext context)
    {
        Organization organization = await client.CreateOrganization(this.Name, context.CancellationToken).ConfigureAwait(false);

        logger.OrganizationCreated(organization);
    }
}