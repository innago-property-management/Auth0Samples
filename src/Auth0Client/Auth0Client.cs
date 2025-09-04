namespace Auth0Client;

using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using Abstractions;

using Auth0.ManagementApi;

public partial class Auth0Client : IAuth0Client
{
    private static string auth0DatabaseName;
    private static string auth0ConnectionName;
    private readonly IManagementApiClient client;

    public Auth0Client(IManagementApiClient client, IOptions<Auth0Settings> settings)
    {
        this.client = client;
        auth0DatabaseName = settings.Value.DatabaseName;
        auth0ConnectionName = settings.Value.ConnectionName;
    }

    [GeneratedRegex("[^a-z0-9\\-_]+")]
    private static partial Regex Auth0NameCleaner();

    private static string CleanName(string name)
    {
        return Auth0NameCleaner().Replace(name.ToLowerInvariant().Trim(), "_");
    }
}
