namespace Runner;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand]
internal class CreateOrganizationCommand(IAuth0Client client, ILogger<CreateOrganizationCommand> logger)
{
    public async Task RunAsync(CliContext context)
    {
        Organization organization = await client.CreateOrganization(context.CancellationToken).ConfigureAwait(false);

        logger.OrganizationCreated(organization);
    }
}