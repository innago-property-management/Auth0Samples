namespace Runner.Commands;

using Abstractions;

using DotMake.CommandLine;

using Messages;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["orgs"])]
internal class ListOrganizationsCommand(IAuth0Client client, ILogger<ListOrganizationsCommand> logger)
{
    public async Task RunAsync(CliContext context)
    {
        List<Org> organizations = (await client.ListOrganizations(context.CancellationToken).ConfigureAwait(false)).ToList();

        organizations.ForEach(organization => logger.Organization(organization.Id, organization.DisplayName));
    }
}
