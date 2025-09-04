namespace Auth0Client;

using System.Text.RegularExpressions;

using Microsoft.Extensions.Options;

using Abstractions;

using Auth0.ManagementApi;

public partial class Auth0Client(IManagementApiClient client, IOptions<Auth0Settings> settings) : IAuth0Client
{
    private readonly string auth0DatabaseName = settings.Value.DatabaseName;
    private readonly string auth0ConnectionName = settings.Value.ConnectionName;

    [GeneratedRegex("[^a-z0-9\\-_]+")]
    private static partial Regex Auth0NameCleaner();

    private static string CleanName(string name)
    {
        return Auth0NameCleaner().Replace(name.ToLowerInvariant().Trim(), "_");
    }
}
