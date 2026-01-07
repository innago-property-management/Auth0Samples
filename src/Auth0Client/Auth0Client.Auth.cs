namespace Auth0Client;

using Abstractions;

using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;

using Innago.Shared.TryHelpers;

using System;
using System.Threading;
using System.Threading.Tasks;

public partial class Auth0Client
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <param name="audience"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Result<string>> GetToken(string clientId, string clientSecret, string audience, CancellationToken cancellationToken = default)
    {
        try
        {
            // 2. Call the GetToken method for the Client Credentials Grant
            AccessTokenResponse response = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Audience = audience
                },
                cancellationToken);

            // 3. Handle Success
            // The SDK handles non-2xx responses and throws an exception, so we only need to check for a valid token.
            return !string.IsNullOrEmpty(response.AccessToken) ? new Result<string>(response.AccessToken) :
                // This is unlikely if the call succeeds, but good for safety.
                new Result<string>(new InvalidOperationException("Auth0 SDK call succeeded but returned an empty access token."));
        }
        catch (ApiException apiEx)
        {
            // 4. Handle API Errors (e.g., Invalid Client ID, Invalid Audience)
            return new Result<string>(new InvalidOperationException($"Auth0 API Error: {apiEx.Message}"));
        }
        catch (Exception ex)
        {
            // 5. Handle other exceptions (e.g., network issues)
            return new Result<string>(new InvalidOperationException($"An unexpected error occurred: {ex.Message}", ex));
        }
    }

    /// <summary>
    /// Retrieves an OAuth2 Client Credentials token with full response fields (RFC 6749 Section 4.4).
    /// </summary>
    /// <param name="clientId">The client identifier issued to the client.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="audience">The target audience for the token.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A result containing the full client credentials token response or an error.</returns>
    public async Task<Result<ClientCredentialsToken>> GetClientCredentialsToken(
        string clientId,
        string clientSecret,
        string audience,
        CancellationToken cancellationToken = default)
    {
        try
        {
            AccessTokenResponse response = await authClient.GetTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Audience = audience
                },
                cancellationToken);

            if (string.IsNullOrEmpty(response.AccessToken))
            {
                return new Result<ClientCredentialsToken>(
                    new InvalidOperationException("Auth0 SDK call succeeded but returned an empty access token."));
            }

            return new Result<ClientCredentialsToken>(new ClientCredentialsToken(
                AccessToken: response.AccessToken,
                TokenType: response.TokenType ?? "Bearer",
                ExpiresIn: response.ExpiresIn,
                Scope: null));
        }
        catch (ApiException apiEx)
        {
            return new Result<ClientCredentialsToken>(
                new InvalidOperationException($"Auth0 API Error: {apiEx.Message}"));
        }
        catch (Exception ex)
        {
            return new Result<ClientCredentialsToken>(
                new InvalidOperationException($"An unexpected error occurred: {ex.Message}", ex));
        }
    }
}
