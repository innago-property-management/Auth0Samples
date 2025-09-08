namespace Auth0Client;

using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Abstractions;

using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

using Innago.Shared.TryHelpers;

using Microsoft.Extensions.Logging;

/// <summary>
/// Provides functionality for interacting with Auth0 authentication services.
/// </summary>
/// <param name="client">The Auth0 management API client.</param>
/// <param name="settings">The Auth0 configuration settings.</param>
/// <param name="logger">The logger.</param>
public partial class Auth0Client(
    IManagementApiClient client,
    IOptions<Auth0Settings> settings,
    ILogger<Auth0Client> logger) : IAuth0Client
{
    private readonly string auth0DatabaseName = settings.Value.DatabaseName;
    private readonly string auth0ConnectionName = settings.Value.ConnectionName;

    [GeneratedRegex("[^a-z0-9\\-_]+")]
    private static partial Regex Auth0NameCleaner();

    private static string CleanName(string name)
    {
        return Auth0NameCleaner().Replace(name.ToLowerInvariant().Trim(), "_");
    }

    /// <inheritdoc />
    public async Task<bool> HealthCheck(CancellationToken cancellationToken)
    {
        Result<TenantSettings?> result =
            await TryHelpers.TryAsync(() => client.TenantSettings.GetAsync(cancellationToken: cancellationToken)!).ConfigureAwait(false);

        return result.Map(_ => true, _ => false);
    }
}
