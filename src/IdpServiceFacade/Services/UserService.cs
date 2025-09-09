using IdpServiceFacade;

namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using Grpc.Core;

using MorseCode.ITask;

internal class UserService(IUserService externalService, IAuth0Client auth0Client) : User.UserBase
{
    public override Task<InitiatePasswordResetReply> InitiatePasswordReset(UserRequest request, ServerCallContext context)
    {
        Console.WriteLine($"InitiatePasswordReset called with request {request.Email}");
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.ResetPassword(request.Email, context.CancellationToken).ToInitiatePasswordResetReply();
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

    public override Task<UserMetadataReply> GetUserMetadata(UserMetadataRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        ITask<IReadOnlyDictionary<string, string?>?> f = externalService.GetUserMetadata(request.Email, request.Keys?.Key.ToArray(), context.CancellationToken);

        return f.ToUserMetadataReply();
    }

    public override async Task<UserResponse> GetUser(UserId request, ServerCallContext context)
    {
        try
        {
            using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client);
            var result = await auth0Client.GetUser(request.Id, context.CancellationToken);
            return result.ToGetUserResponse();
        }
        catch (OperationCanceledException ex)
        {
            throw new RpcException(new Status(StatusCode.Cancelled, "Request was cancelled"), ex.Message);
        }
        catch (Exception ex)
        {
            // Log with activity if you want
            Console.WriteLine(ex);

            throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"), ex.Message);
        }
    }

    public override async Task<UserResponseList> GetUsers(UserIds request, ServerCallContext context)
    {
        try
        {
            using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client);
            var result = await auth0Client.GetUsers(request.Ids.ToArray(), context.CancellationToken);
            var responseList = new UserResponseList();
            responseList.UserResponseList_.AddRange(result.Select(u => u.ToGetUserResponse()));

            return responseList;
        }
        catch (OperationCanceledException ex)
        {
            throw new RpcException(new Status(StatusCode.Cancelled, "Request was cancelled"), ex.Message);
        }
        catch (Exception ex)
        {
            // Log with activity if you want
            Console.WriteLine(ex);

            throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"), ex.Message);
        }
    }
}
