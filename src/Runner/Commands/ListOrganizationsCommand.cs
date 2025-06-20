namespace Runner.Commands;

using Abstractions;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["orgs"])]
internal class ListOrganizationsCommand(IAuth0Client client, ILogger<ListOrganizationsCommand> logger)
{
    public async Task RunAsync(CliContext context)
    {
        List<Organization> organizations = (await client.ListOrganizations(context.CancellationToken).ConfigureAwait(false)).ToList();

        organizations.ForEach(organization => logger.Organization(organization.Id, organization.DisplayName));
    }
}