using IdpServiceFacade;

using Newtonsoft.Json;

using Identity = IdpServiceFacade.Identity;
using User = Auth0.ManagementApi.Models.User;

namespace Innago.Security.IdpServiceFacade.Services;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Converter for the user model from Auth0
/// </summary>
public static class UserResponseHelpers
{
    /// <summary>
    /// Converts auth0 user to grpc repsonse
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [SuppressMessage("ReSharper", "NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract")]
    public static UserResponse ToGetUserResponse(this User user)
    {
        var response = new UserResponse
        {
            Email = user.Email ?? string.Empty,
            EmailVerified = user.EmailVerified ?? false,
            Username = user.UserName ?? string.Empty,
            Nickname = user.NickName ?? string.Empty,
            GivenName = user.FirstName ?? string.Empty,
            Name = user.FullName ?? string.Empty,
            FamilyName = user.LastName ?? string.Empty,
            Picture = user.Picture ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            PhoneVerified = user.PhoneVerified ?? false,
            Blocked = user.Blocked ?? false,
            UserMetadata = JsonConvert.SerializeObject(user.UserMetadata ?? "{}") ?? new { },
            UserId = user.UserId ?? string.Empty,
            LastLogin = user.LastLogin?.ToString() ?? string.Empty,
            LastIp = user.LastIpAddress ?? string.Empty,
        };

        response.Identities.AddRange((user.Identities ?? []).Select(identity => new Identity { UserId = identity.UserId ?? string.Empty }));

        return response;
    }
}
