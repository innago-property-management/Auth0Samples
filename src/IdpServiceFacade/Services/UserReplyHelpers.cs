namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using global::IdpServiceFacade;

using MorseCode.ITask;

internal static class UserReplyHelpers
{
    private static UserReply ToUserReply(this OkError result)
    {
        return new UserReply
        {
            Ok = result.OK,
            Error = result.Error ?? string.Empty,
        };
    }

    public static async Task<UserReply> ToUserReply(this ITask<OkError> task)
    {
        OkError result = await task.ConfigureAwait(false);

        return result.ToUserReply();
    }

    private static UserMetadataReply ToUserMetadataReply(this IReadOnlyDictionary<string, string?> metadata)
    {
        UserMetadataReply retVal = new();

        foreach ((string key, string? value) in metadata)
        {
            retVal.Metadata.Add(key,value);
        }

        return retVal;
    }

    public static async Task<UserMetadataReply> ToUserMetadataReply(this ITask<IReadOnlyDictionary<string, string?>?> task)
    {
        IReadOnlyDictionary<string, string?>? metadata = await task.ConfigureAwait(false) ?? new Dictionary<string, string?>();

        return metadata.ToUserMetadataReply();
    }



    private static GetTokenAuthReply ToTokenReply(this TokenResponsePayload<TokenResponse> result)
    {
        return new GetTokenAuthReply
        {
            Accesstoken = result.Result.AccessToken,
            Expiresin = result.Result.ExpiresIn,
            Scope = result.Result.Scope,
            Tokentype = result.Result.TokenType,
        };
    }

    public async static Task<GetTokenAuthReply> ToTokenReply(this ITask<TokenResponsePayload<TokenResponse>> task)
    {
        TokenResponsePayload<TokenResponse> result = await task.ConfigureAwait(false);

        return result.ToTokenReply();
    }


}
