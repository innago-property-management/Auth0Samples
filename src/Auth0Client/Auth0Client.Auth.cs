namespace Auth0Client;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;

using Innago.Shared.TryHelpers;

using System;
using System.Threading;
using System.Threading.Tasks;

public partial class Auth0Client
{
    public async Task<Result<string>> GetToken(string clientId, string clientSecret, string audience, CancellationToken cancellationToken)
    {
        try
        {
            // 2. Call the GetToken method for the Client Credentials Grant
            AccessTokenResponse response = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                Audience = audience
            }, cancellationToken);

            // 3. Handle Success
            // The SDK handles non-2xx responses and throws an exception, so we only need to check for a valid token.
            if (!string.IsNullOrEmpty(response.AccessToken))
            {
                return new Result<string>(response.AccessToken);
            }
            else
            {
                // This is unlikely if the call succeeds, but good for safety.
                return new Result<string>(new InvalidOperationException("Auth0 SDK call succeeded but returned an empty access token."));
            }
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
}
