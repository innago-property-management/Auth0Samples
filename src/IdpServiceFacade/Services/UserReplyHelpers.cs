namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using global::IdpServiceFacade;

using MorseCode.ITask;

internal static class UserReplyHelpers
{
    public static UserReply ToUserReply(this OkError result)
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
}
