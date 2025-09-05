using IdpServiceFacade;

namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using Grpc.Core;

internal class UserService(IUserService externalService) : User.UserBase
{
    public override Task<UserReply> InitiatePasswordReset(UserRequest request, ServerCallContext context)
    {
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
}
