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
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<GetTokenResponse> GetToken(GetTokenRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.ClientId), request.Audience)]);

        Result<string> result = await externalService.GetToken(request.ClientId, request.ClientSecret, request.Audience, context.CancellationToken)
            .ConfigureAwait(false);

        if (!result.HasSucceeded)
        {
            logger.Error(new Exception(result.ToString() ?? "An unknown error occurred while fetching the token."));
        }

        return new GetTokenResponse
        {
            Ok = result.HasSucceeded,
            Error = !result.HasSucceeded ? (result.ToString() ?? "An unknown error occurred.") : string.Empty,
            AccessToken = result.HasSucceeded ? result : string.Empty
        };
    }
}
