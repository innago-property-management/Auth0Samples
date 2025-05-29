namespace Runner.Client;

using System.Text.RegularExpressions;

using Abstractions;

using Auth0.ManagementApi;

using Bogus;

internal partial class Auth0Client(IManagementApiClient client) : IAuth0Client
{
    private const string Auth0DatabaseName = "Username-Password-Authentication";

    private static Faker Faker { get; } = new();

    [GeneratedRegex("[^a-z0-9\\-_]+")]
    private static partial Regex Auth0NameCleaner();

    private static string CleanName(string name)
    {
        return Auth0NameCleaner().Replace(name.ToLowerInvariant().Trim(), "_");
    }
}