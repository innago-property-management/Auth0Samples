namespace Abstractions;

using System.Text.Json.Serialization;

using JetBrains.Annotations;

/// <summary>
/// Represents an OAuth2 Client Credentials token response as defined in RFC 6749 Section 4.4.3.
/// </summary>
/// <param name="AccessToken">The access token issued by the authorization server.</param>
/// <param name="TokenType">The type of the token issued, typically "Bearer".</param>
/// <param name="ExpiresIn">The lifetime in seconds of the access token.</param>
/// <param name="Scope">The scope of the access token, if different from those requested. Space-delimited.</param>
[PublicAPI]
public record ClientCredentialsToken(
    [property: JsonPropertyName("access_token")] string AccessToken,
    [property: JsonPropertyName("token_type")] string TokenType,
    [property: JsonPropertyName("expires_in")] int ExpiresIn,
    [property: JsonPropertyName("scope")] string? Scope = null);
