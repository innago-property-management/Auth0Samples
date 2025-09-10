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
using MorseCode.ITask;
using System.Collections.Generic;
using System.Threading;
using System.Net.Http;

/// <summary>
/// Provides functionality for interacting with Auth0 authentication services.
/// </summary>
/// <param name="client">The Auth0 management API client.</param>
/// <param name="settings">The Auth0 configuration settings.</param>
/// <param name="logger">The logger.</param>
/// <param name="httpClientFactory">The httpClientFactory to create http client.</param>
public partial class Auth0Client(
    IManagementApiClient client,
    IOptions<Auth0Settings> settings,
    ILogger<Auth0Client> logger, IHttpClientFactory httpClientFactory) : IAuth0Client
{
    private readonly string auth0DatabaseName = settings.Value.DatabaseName;
    private readonly string auth0ConnectionName = settings.Value.ConnectionName;
    private readonly string auth0Audience = settings.Value.Audience;
    private readonly string auth0ClientId = settings.Value.ClientId;
    private readonly string auth0ClientSecret = settings.Value.ClientSecret;
    private readonly string auth0Domain = settings.Value.Domain;
    private readonly HttpClient httpClient = httpClientFactory.CreateClient();

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

        result.Match(ts => logger.Information(ts!.FriendlyName), logger.Error);

        return result.Map(_ => true, _ => false);
    }
}
