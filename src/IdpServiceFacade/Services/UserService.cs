namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using Auth0.ManagementApi.Models;

using global::IdpServiceFacade;

using Grpc.Core;

using MorseCode.ITask;

using System.Diagnostics;

using User = global::IdpServiceFacade.User;

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

    public override async Task<UserReply> CreateUserProfile(CreateUserProfileRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId), new KeyValuePair<string, object?>(nameof(request.FirstName), request.FirstName), new KeyValuePair<string, object?>(nameof(request.LastName), request.LastName)]);

        // Check if user exists by email
        Auth0.ManagementApi.Models.User? existingUser = await auth0Client.GetUserByEmail(request.Email, context.CancellationToken);

        bool userExists = existingUser != null;

        // Only create user if they don't exist
        if (!userExists)
        {
            UserCreateRequest userCreateRequest = CreateUserProfileRequest(request);
            OkError createResult = await externalService.CreateUserWithResult(userCreateRequest, context.CancellationToken);

            if (!createResult.OK)
            {
                return new UserReply
                {
                    Ok = createResult.OK,
                    Error = createResult.Error ?? string.Empty,
                };
            }
        }

        // Add user to organization if OrganizationId is provided
        if (!string.IsNullOrWhiteSpace(request.OrganizationId))
        {
            OkError addToOrgResult = await this.AddUserToOrganizationAsync(request.Email, request.OrganizationId, context);

            return new UserReply
            {
                Ok = addToOrgResult.OK,
                Error = addToOrgResult.Error ?? string.Empty,
            };
        }

        return new UserReply
        {
            Ok = true,
            Error = string.Empty,
        };
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

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService
            .GetUsersMetadataByEmailAddresses(request.EmailAddresses.ToArray(), request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNameOrEmailFragmentAndOrgUid(
        UsersMetadataByNameOrEmailFragmentAndOrgUidRequest request,
        ServerCallContext context)
    {
        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await auth0Client
            .GetUsersMetadataByNameOrEmailFragment(request.SearchTerm, request.OrgUid, request.Keys?.Key.ToArray(), context.CancellationToken)
            .ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UserReply> UpdateUserProfile(UpdateUserProfileRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId), new KeyValuePair<string, object?>(nameof(request.FirstName), request.FirstName), new KeyValuePair<string, object?>(nameof(request.LastName), request.LastName)]);
        UserUpdateRequest userUpdateRequest = CreateUserUpdateRequest(request);
        return await externalService.UpdateUser(request.IdentityId, userUpdateRequest, context.CancellationToken).ToUserReply();
    }

    public override async Task<UserReply> UpdateVerifiedEmail(UpdateVerifiedUserEmailRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId), new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);
        UserUpdateRequest userUpdateRequest = new()
        {
            Email = request.Email,
            EmailVerified = request.EmailVerified,
            UserMetadata = new Dictionary<string, object>()
        };
        userUpdateRequest.UserMetadata["is_account_verified"] = true;
        return await externalService.UpdateUser(request.IdentityId, userUpdateRequest, context.CancellationToken).ToUserReply();
    }

    public override async Task<UserReply> UpdateVerifiedPhoneNumber(UpdateVerifiedPhoneNumberRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId), new KeyValuePair<string, object?>(nameof(request.PhoneNumber), request.PhoneNumber)]);
        UserUpdateRequest userUpdateRequest = new()
        {
            UserMetadata = new Dictionary<string, object>()
        };
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "phone_number", request.PhoneNumber);
        return await externalService.UpdateUser(request.IdentityId, userUpdateRequest, context.CancellationToken).ToUserReply();
    }

    public override async Task<UserReply> ChangePasswordWithIdentityId(ChangePasswordWithIdentityIdRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId)]);
        return await externalService.ChangePasswordWithIdentityId(request.IdentityId, request.NewPassword, context.CancellationToken).ToUserReply();
    }
    public override async Task<UserReply> UpdateRiskStatusWithIdentityId(UpdateRiskStatusWithIdentityIdRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId)]);
        UserUpdateRequest userUpdateRequest = new()
        {
            UserMetadata = new Dictionary<string, object>()
        };
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "risk_status", request.RiskStatus);
        return await externalService.UpdateUser(request.IdentityId, userUpdateRequest, context.CancellationToken).ToUserReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByEmailFragment(UsersMetadataByEmailFragmentRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.SearchTerm), request.SearchTerm)]);

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService
            .GetUsersMetadataByEmailFragment(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNames(GetUsersMetadataByNamesRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Names), request.Names)]);

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService
            .GetUsersMetadataByNames(request.Names.ToArray(), request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByEmailOrPhoneFragment(GetUsersMetadataByEmailOrPhoneRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.SearchTerm), request.SearchTerm)]);

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService
            .GetUsersMetadataByEmailOrPhoneFragment(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> GetUsersMetadataByNameAndEmailAndPhoneFragment(GetUsersMetadataByNameAndEmailAndPhoneRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.SearchTerm), request.SearchTerm)]);

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService
            .GetUsersMetadataByNameAndEmailAndPhoneFragment(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UsersMetadataReply> CheckPhoneExistsOnAuth0(CheckPhoneExistsOnAuth0Request request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.SearchTerm), request.SearchTerm)]);

        IReadOnlyDictionary<string, IReadOnlyDictionary<string, string?>?>? users = await externalService
            .CheckPhoneExistsOnAuth0(request.SearchTerm, request.Keys?.Key.ToArray(), context.CancellationToken).ConfigureAwait(false);

        return users.ToUsersMetadataReply();
    }

    public override async Task<UserReply> ActivateUser(ActivateUserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId), new KeyValuePair<string, object?>(nameof(request.IsActivate), request.IsActivate)]);

        return await externalService.ActivateUser(request.IdentityId, request.IsActivate, context.CancellationToken).ToUserReply();
    }

    public override async Task<UserReply> DeleteUser(DeleteUserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId)]);

        return await externalService.DeleteUser(request.IdentityId, context.CancellationToken).ToUserReply();
    }

    public override async Task<UserReply> UnblockBruteforceLockedUser(UserRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
            tags: [new KeyValuePair<string, object?>(nameof(request.Email), request.Email)]);
        return await externalService.UnblockBruteforceLockedUser(request.Email, context.CancellationToken).ToUserReply();
    }
    public override async Task<UserReply> RemoveUserFromOrganization(RemoveUserFromOrganizationRequest request, ServerCallContext context)
    {
        UserReply response = new UserReply();
        try
        {
            // Get the user by email to obtain the User object needed for AddUserToOrganization
            Auth0.ManagementApi.Models.User? user = await auth0Client.GetUserByEmail(request.Email, context.CancellationToken);

            if (user == null)
            {
                response.Ok = false;
                response.Error = "User not found";
                return response;
            }

            OkError result = await auth0Client.RemoveUserFromOrganizationByUid(user, request.OrganizationId, context.CancellationToken);
            response.Ok = result.OK;
            response.Error = result.Error;
            return response;
        }
        catch (Exception ex)
        {
            response.Ok = false;
            response.Error = ex.Message;
            return response;
        }
    }
    public async Task<OkError> AddUserToOrganizationAsync(string email, string organizationId, ServerCallContext context)
    {
        try
        {
            // Get the user by email to obtain the User object needed for AddUserToOrganization
            Auth0.ManagementApi.Models.User? user = await auth0Client.GetUserByEmail(email, context.CancellationToken);

            if (user == null)
            {
                return new OkError(false, Error: "User not found");
            }

            OkError result = await auth0Client.AddUserToOrganizationByUid(user, organizationId, context.CancellationToken).ConfigureAwait(false);

            return result;
        }
        catch (Exception ex)
        {
            return new OkError(false, Error: ex.Message);
        }
    }

    public override async Task<UserReply> UpdateUserRoleId(UpdateUserRoleIdRequest request, ServerCallContext context)
    {
        using Activity? activity = IdpServiceFacadeTracer.Source.StartActivity(ActivityKind.Client,
    tags: [new KeyValuePair<string, object?>(nameof(request.IdentityId), request.IdentityId)]);
        UserUpdateRequest userUpdateRequest = new()
        {
            UserMetadata = new Dictionary<string, object>()
        };
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "role_id", request.RoleId);
        return await externalService.UpdateUser(request.IdentityId, userUpdateRequest, context.CancellationToken).ToUserReply();
    }

    #region private methods
    private static void AddIfNotNullOrEmpty(Dictionary<string, object> dict, string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            dict[key] = value;
        }
    }

    private static UserUpdateRequest CreateUserUpdateRequest(UpdateUserProfileRequest request)
    {
        UserUpdateRequest userUpdateRequest = new()
        {
            Email = request.Email,
            FullName = $"{request.FirstName} {request.LastName}".Trim(),
            UserMetadata = new Dictionary<string, object>()
        };

        // base fields
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "full_name", $"{request.FirstName} {request.LastName}".Trim());
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "first_name", request.FirstName);
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "last_name", request.LastName);
        AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "phone_number", request.PhoneNumber);

        // business fields
        if (request.IsBusinessUpdated)
        {
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "business_name", request.BusinessName);
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "business_email", request.BusinessEmail);
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "business_phone", request.BusinessPhone);
        }

        // address fields
        if (request.IsAddressUpdated)
        {
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "address_line1", request.AddressLine1);
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "address_line2", request.AddressLine2);
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "city", request.City);
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "state", request.State);
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "zip", request.Zip);
        }
        // role field
        if (request.IsRoleUpdated)
        {
            AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "role_id", request.RoleId);
            if (request.RoleId == "3")
            {
                AddIfNotNullOrEmpty(userUpdateRequest.UserMetadata, "system_role_id", request.RoleId);
            }
        }
        if (request.EmailVerified)
        {
            userUpdateRequest.EmailVerified = true;
            userUpdateRequest.UserMetadata["is_account_verified"] = true;
        }
        return userUpdateRequest;
    }

    private static UserCreateRequest CreateUserProfileRequest(CreateUserProfileRequest request)
    {
        UserCreateRequest userCreateRequest = new()
        {
            Email = request.Email,
            FullName = $"{request.FirstName} {request.LastName}",
            Password = Guid.NewGuid().ToString(),
            EmailVerified = request.EmailVerified,
            VerifyEmail = request.VerifyEmail
        };
        if (request.Metadata is not null && request.Metadata.Count > 0)
        {
            userCreateRequest.UserMetadata = request.Metadata.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
        else
        {
            userCreateRequest.UserMetadata = new Dictionary<string, object>();
        }
        return userCreateRequest;
    }
    #endregion
}
