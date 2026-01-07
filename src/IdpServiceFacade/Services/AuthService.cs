namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using global::IdpServiceFacade;

using Grpc.Core;

using Shared.TryHelpers;

using System.Diagnostics;

using Auth = global::IdpServiceFacade.Auth;

/// <summary>
///
/// </summary>
/// <param name="externalService"></param>
/// <param name="logger"></param>
public class AuthService(
    IAuthService externalService,
    ILogger<AuthService> logger) : Auth.AuthBase
{
    /// <summary>
    /// Handles OAuth2 Client Credentials token requests (RFC 6749 Section 4.4).
    /// </summary>
    /// <param name="request">The token request containing client credentials and audience.</param>
    /// <param name="context">The gRPC server call context.</param>
    /// <returns>A response containing the access token and OAuth2 standard fields.</returns>
    public override async Task<GetTokenResponse> GetToken(GetTokenRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(
            ActivityKind.Client,
            tags:
            [
                new KeyValuePair<string, object?>("client_id", request.ClientId),
                new KeyValuePair<string, object?>("audience", request.Audience)
            ]);

        logger.TokenRequestStarted(request.ClientId, request.Audience);

        Result<ClientCredentialsToken> result = await externalService
            .GetClientCredentialsToken(request.ClientId, request.ClientSecret, request.Audience, context.CancellationToken)
            .ConfigureAwait(false);

        if (!result.HasSucceeded)
        {
            string errorMessage = result.ToString() ?? "An unknown error occurred while fetching the token.";
            logger.TokenRequestFailed(request.ClientId, request.Audience, errorMessage);

            return new GetTokenResponse
            {
                Ok = false,
                Error = "invalid_grant",
                ErrorDescription = "Token request failed",
                AccessToken = string.Empty,
                TokenType = string.Empty,
                ExpiresIn = 0
            };
        }

        ClientCredentialsToken token = result!;
        logger.TokenRequestSucceeded(request.ClientId, request.Audience, token.ExpiresIn);

        return new GetTokenResponse
        {
            Ok = true,
            AccessToken = token.AccessToken,
            TokenType = token.TokenType,
            ExpiresIn = token.ExpiresIn,
            Scope = token.Scope ?? string.Empty
        };
    }
}
