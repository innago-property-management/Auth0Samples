namespace Abstractions;

using System;
using System.Text.Json.Serialization;

/// <summary>
///     Represents a response containing authentication token details.
/// </summary>
/// <param name="AccessToken">The access token for the authenticated session.</param>
/// <param name="ExpiresIn">The number of seconds until the access token expires.</param>
/// <param name="RefreshExpiresIn">The number of seconds until the refresh token expires.</param>
/// <param name="RefreshToken">The refresh token used to obtain a new access token.</param>
/// <param name="TokenType">The type of the token issued.</param>
/// <param name="NotBeforePolicy">The policy that determines the earliest timestamp the token can be accepted.</param>
/// <param name="SessionState">The state identifier for the user session.</param>
/// <param name="Scope">The scope of access granted by the token.</param>
public record struct TokenResponse(
    [property: JsonPropertyName("access_token")] string? AccessToken,
    [property: JsonPropertyName("expires_in")] string? ExpiresIn,
    [property: JsonPropertyName("refresh_expires_in")] int? RefreshExpiresIn,
    [property: JsonPropertyName("refresh_token")] string? RefreshToken,
    [property: JsonPropertyName("token_type")] string? TokenType,
    [property: JsonPropertyName("not-before-policy")] int? NotBeforePolicy,
    [property: JsonPropertyName("session_state")] Guid? SessionState,
    [property: JsonPropertyName("scope")] string? Scope);
