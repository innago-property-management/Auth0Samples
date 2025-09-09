
using IdpServiceFacade;

using Newtonsoft.Json;

using Identity = IdpServiceFacade.Identity;
using User = Auth0.ManagementApi.Models.User;

public static class UserResponseHelpers
{
    public static UserResponse ToGetUserResponse(this User user)
    {
        if (user == null)
        {
            return new UserResponse();
        }

        return new UserResponse
        {
            Email = user.Email ?? "",
            EmailVerified = user.EmailVerified ?? false,
            Username = user.UserName ?? "",
            Nickname = user.NickName ?? "",
            GivenName = user.FirstName ?? "",
            Name = user.FullName ?? "",
            FamilyName = user.LastName ?? "",
            Picture = user.Picture ?? "",
            PhoneNumber = user.PhoneNumber ?? "",
            PhoneVerified = user.PhoneVerified ?? false,
            Blocked = user.Blocked ?? false,
            UserMetadata = JsonConvert.SerializeObject(user.UserMetadata),
            UserId = user.UserId,
            LastLogin = user.LastLogin?.ToString(),
            LastIp = user.LastIpAddress ?? "",
            Identities =
            {
                user.Identities?.Select(i => new Identity
                    {
                        UserId = i.UserId ?? ""
                    }
                ),
            },
        };
    }
}
