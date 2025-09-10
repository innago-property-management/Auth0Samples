using IdpServiceFacade;

namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using Grpc.Core;

using MorseCode.ITask;

internal class UserService(IUserService externalService, IAuth0Client auth0Client, ILogger<UserService> logger) : User.UserBase
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

    public override Task<UserReply> DisableMfa(UserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.DisableMfa(request.Email, context.CancellationToken).ToUserReply();
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
            var result = (await auth0Client.GetUsers([request.Id], context.CancellationToken)).FirstOrDefault();
            
            if (result == null)
            {
                return new UserResponse();
            }

            UserResponse userResponse = result.ToGetUserResponse();
            return userResponse;
        }
        catch (OperationCanceledException ex)
        {
            throw new RpcException(new Status(StatusCode.Cancelled, "Request was cancelled"), ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "There was an error in calling Get User method through grpc for User id {UserId}", request.Id);

            throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"), ex.Message);
        }
    }

    public override async Task<UserResponseList> GetUsersByIds(UserIds request, ServerCallContext context)
    {
        try
        {
            using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client);
            var result = await auth0Client.GetUsers(request.Ids.ToArray(), context.CancellationToken);
            var responseList = new UserResponseList();

            if (result.Any())
            {
                responseList.UserResponseList_.AddRange(result.Select(u => u.ToGetUserResponse()));
            }

            return responseList;
        }
        catch (OperationCanceledException ex)
        {
            throw new RpcException(new Status(StatusCode.Cancelled, "Request was cancelled"), ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "There was an error in calling Get Users method through grpc for User id {UserIds}", string.Join(", ", request.Ids));
            throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"), ex.Message);
        }
    }

    public override Task<UserSearchResponse> GetUsers(UsersSearchRequest request, ServerCallContext context)
    {
        return auth0Client.ListUsers(request.Text, context.CancellationToken).ToUserSearchResponse();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNameOrEmailFragment(UsersMetadataByNameOrEmailFragmentRequest request, ServerCallContext context)
    {
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await auth0Client.GetUsersMetadataByNameOrEmailFragment(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override Task<UserReply> EnableMfa(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);
        return externalService.EnableMfa(request.Email, context.CancellationToken).ToUserReply();
    }
}
