namespace Runner;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand]
internal class ListOrganizationsCommand(IAuth0Client client, ILogger<ListOrganizationsCommand> logger)
{
    public async Task RunAsync(CliContext context)
    {
        List<Organization> organizations = (await client.ListOrganizations(context.CancellationToken).ConfigureAwait(false)).ToList();

        organizations.ForEach(organization => logger.Organization(organization.Id, organization.DisplayName));
    }
}