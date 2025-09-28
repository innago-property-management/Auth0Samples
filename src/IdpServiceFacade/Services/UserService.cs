namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics;

using Abstractions;

using Auth0.ManagementApi.Models;

using global::IdpServiceFacade;
using User = global::IdpServiceFacade.User;
using Grpc.Core;

using MorseCode.ITask;

internal class UserService(IUserService externalService, IAuth0Client auth0Client, ILogger<UserService> logger) : User.UserBase
{
    public override Task<UserReply> BlockUser(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.BlockUser(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> ChangePassword(UserChangePasswordRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.ChangePassword(request.Email, request.Password, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> DisableMfa(UserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.DisableMfa(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<GetTokenAuthReply> GetRefreshToken(GetRefreshTokenAuthRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Refreshtoken), request.Refreshtoken)]);

        return externalService.GetRefreshTokenAsyncImplementation(request.Refreshtoken, request.Keys?.Key.ToArray(), context.CancellationToken).ToTokenReply();
    }

    public override Task<GetTokenAuthReply> GetToken(GetTokenAuthRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Username), request.Username)]);

        return externalService.GetTokenAsyncImplementation(request.Username, request.Password, request.Keys?.Key.ToArray(), context.CancellationToken)
            .ToTokenReply();
    }

    public override Task<UserMetadataReply> GetUserMetadata(UserMetadataRequest request, ServerCallContext context)

    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        ITask<IReadOnlyDictionary<string, string?>?> f = externalService.GetUserMetadata(request.Email, request.Keys?.Key.ToArray(), context.CancellationToken);

        return f.ToUserMetadataReply();
    }

    public override Task<UserSearchResponse> GetUsers(UsersSearchRequest request, ServerCallContext context)
    {
        return auth0Client.ListUsers(request.Text, context.CancellationToken).ToUserSearchResponse();
    }

    public override async Task<UserResponseList> GetUsersByIds(UserIds request, ServerCallContext context)
    {
        try
        {
            using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client);
            List<Auth0.ManagementApi.Models.User> result = await auth0Client.GetUsers(request.Ids.ToArray(), context.CancellationToken);
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
            logger.GetUsersByIdsError(ex, string.Join(", ", request.Ids));
            throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred"), ex.Message);
        }
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNameOrEmailFragment(
        UsersMetadataByNameOrEmailFragmentRequest request,
        ServerCallContext context)
    {
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await auth0Client
            .GetUsersMetadataByNameOrEmailFragment(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNameFragment(UsersMetadataByNameFragmentRequest request, ServerCallContext context)
    {
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await auth0Client
            .GetUsersMetadataByNameFragment(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override Task<UserReply> EnableMfa(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.EnableMfa(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<InitiatePasswordResetReply> InitiatePasswordReset(UserRequest request, ServerCallContext context)
    {
        logger.InitiatePasswordReset(request.Email);

        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.ResetPassword(request.Email, context.CancellationToken).ToInitiatePasswordResetReply();
    }

    public override Task<UserReply> MarkAsFraud(UserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.MarkUserAsFraud(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> MarkAsSuspicious(UserRequest request, ServerCallContext context)
    {
        using Activity? activity =
            IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client, tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.MarkUserAsSuspicious(request.Email, context.CancellationToken).ToUserReply();
    }

    public override Task<UserReply> UnblockUser(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);

        return externalService.UnblockUser(request.Email, context.CancellationToken).ToUserReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByEmailAddresses(GetUsersMetadataByEmailAddressesRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.EmailAddresses), request.EmailAddresses)]);

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService.GetUsersMetadataByEmailAddresses(request.EmailAddresses.ToArray(), request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNameOrEmailFragmentAndOrgUid(UsersMetadataByNameOrEmailFragmentAndOrgUidRequest request, ServerCallContext context)
    {
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await auth0Client
            .GetUsersMetadataByNameOrEmailFragment(request.SearchTerm, request.OrgUid, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UserReply> UpdateUserProfile(UpdateUserProfileRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId), new KeyValuePair<string, object?>(nameof(request.FirstName), request.FirstName), new KeyValuePair<string, object?>(nameof(request.LastName), request.LastName)]);
        UserUpdateRequest userUpdateRequest = CreateUserUpdateRequest(request);
        return await externalService.UpdateUser(request.IdentityId, userUpdateRequest, context.CancellationToken).ToUserReply();
    }

    #region private methods
    private static UserUpdateRequest CreateUserUpdateRequest(UpdateUserProfileRequest request)
    {
        UserUpdateRequest userUpdateRequest = new()
        {
            Email = request.Email,
            FullName = $"{request.FirstName} {request.LastName}",
            UserMetadata = new Dictionary<string, object>
            {
                { "full_name", $"{request.FirstName} {request.LastName}" },
                { "first_name", request.FirstName },
                { "last_name", request.LastName },
                { "phone_number", request.PhoneNumber}
            },
        };

        if (request.IsBusinessUpdated)
        {
            userUpdateRequest.UserMetadata.Add("business_name", request.BusinessName);
            userUpdateRequest.UserMetadata.Add("business_email", request.BusinessEmail);
            userUpdateRequest.UserMetadata.Add("business_phone", request.BusinessPhone);
        }
        if (request.IsAddressUpdated)
        {
            userUpdateRequest.UserMetadata.Add("address_line1", request.AddressLine1);
            userUpdateRequest.UserMetadata.Add("address_line2", request.AddressLine2);
            userUpdateRequest.UserMetadata.Add("city", request.City);
            userUpdateRequest.UserMetadata.Add("state", request.State);
            userUpdateRequest.UserMetadata.Add("zip", request.Zip);
        }
        return userUpdateRequest;
    }
    #endregion
}
