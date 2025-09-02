namespace Auth0Client;

using System.Text.RegularExpressions;

using Abstractions;

using Auth0.ManagementApi;

public partial class Auth0Client(IManagementApiClient client) : IAuth0Client
{
    private const string Auth0DatabaseName = "Username-Password-Authentication";
    private const string Auth0ConnectionName = "con_4BTwKBI5S3zH7d2T"; // TODO move this to config

    [GeneratedRegex("[^a-z0-9\\-_]+")]
    private static partial Regex Auth0NameCleaner();

    private static string CleanName(string name)
    {
        return Auth0NameCleaner().Replace(name.ToLowerInvariant().Trim(), "_");
    }
}
