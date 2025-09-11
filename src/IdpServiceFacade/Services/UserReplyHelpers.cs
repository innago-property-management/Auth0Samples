namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using global::IdpServiceFacade;

using MorseCode.ITask;

using User = Auth0.ManagementApi.Models.User;

internal static class UserReplyHelpers
{
    public static async Task<InitiatePasswordResetReply> ToInitiatePasswordResetReply(this ITask<string?> task)
    {
        string? resetTokenResult = await task.ConfigureAwait(false);

        return new InitiatePasswordResetReply
        {
            Token = resetTokenResult,
        };
    }

    public static async Task<UserMetadataReply> ToUserMetadataReply(this ITask<IReadOnlyDictionary<string, string?>?> task)
    {
        IReadOnlyDictionary<string, string?> metadata = await task.ConfigureAwait(false) ?? new Dictionary<string, string?>();

        return metadata.ToUserMetadataReply();
    }

    public static async Task<UserReply> ToUserReply(this ITask<OkError> task)
    {
        OkError result = await task.ConfigureAwait(false);

        return result.ToUserReply();
    }

    public static async Task<UserSearchResponse> ToUserSearchResponse(this Task<IEnumerable<User>> task)
    {
        return (await task.ConfigureAwait(false)).ToUserSearchResponse();
    }

    public static UsersMetadataReply ToUsersMetadataReply(this IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users)
    {
        UsersMetadataReply response = new();

        foreach ((string email, IReadOnlyDictionary<string, string?>? metadata) in users ?? new Dictionary<string, IReadOnlyDictionary<string, string?>?>())
        {
            response.Users.Add(metadata.ToUserWithMetadata(email));
        }

        return response;
    }

    private static UserMetadataReply ToUserMetadataReply(this IReadOnlyDictionary<string, string?> metadata)
    {
        UserMetadataReply retVal = new();

        foreach ((string key, string? value) in metadata)
        {
            retVal.Metadata.Add(key, value);
        }

        return retVal;
    }

    private static UserReply ToUserReply(this OkError result)
    {
        return new UserReply
        {
            Ok = result.OK,
            Error = result.Error ?? string.Empty,
        };
    }

    private static UserSearchResponse ToUserSearchResponse(this IEnumerable<User> users)
    {
        UserSearchResponse response = new();

        foreach (User user in users)
        {
            response.Users.Add(user.ToGetUserResponse());
        }

        return response;
    }

    private static UserWithMetadata ToUserWithMetadata(this IReadOnlyDictionary<string, string?>? metadata, string email)
    {
        UserMetadataReply userMetadata = metadata?.ToUserMetadataReply() ?? new UserMetadataReply();
        UserWithMetadata userWithMetadata = new();
        userWithMetadata.User.Add(email, userMetadata);

        return userWithMetadata;
    }



    private static GetTokenAuthReply ToTokenReply(this TokenResponsePayload<TokenResponse> result)
    {
        if (!string.IsNullOrEmpty(result.Error))
        {
            return new GetTokenAuthReply
            {
                Error = result.Error,
            };
        }
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
