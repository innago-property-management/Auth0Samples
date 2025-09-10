using IdpServiceFacade;

namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using Grpc.Core;

using MorseCode.ITask;

internal class UserService(IUserService externalService) : User.UserBase
{
    public override Task<UserReply> InitiatePasswordReset(UserRequest request, ServerCallContext context)
    {
        Console.WriteLine($"InitiatePasswordReset called with request {request.Email}");
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.ResetPassword(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> MarkAsSuspicious(UserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.MarkUserAsSuspicious(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> MarkAsFraud(UserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.MarkUserAsFraud(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> ToggleMfa(UserMFARequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.ToggleMFA(request.Email, request.Enable, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> ChangePassword(UserChangePasswordRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.ChangePassword(request.Email, request.Password, context.CancellationToken).ToUserReply();
    }

    public override Task<UserMetadataReply> GetUserMetadata(UserMetadataRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        ITask<IReadOnlyDictionary<string, string?>?> f = externalService.GetUserMetadata(request.Email, request.Keys?.Key.ToArray(), context.CancellationToken);

        return f.ToUserMetadataReply();
    }

    public override Task<UserReply> BlockUser(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.BlockUser(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> UnblockUser(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.UnblockUser(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<GetTokenAuthReply> GetToken(GetTokenAuthRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Username), request.Username)]);

       return externalService.GetTokenAsyncImplementation(request.Username, request.Password, request.Keys?.Key.ToArray(), context.CancellationToken).ToTokenReply();
    }
    public override Task<GetTokenAuthReply> GetRefreshToken(GetRefreshTokenAuthRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Refreshtoken), request.Refreshtoken)]);

        return externalService.GetRefreshTokenAsyncImplementation(request.Refreshtoken, request.Keys?.Key.ToArray(), context.CancellationToken).ToTokenReply();
    }
}
