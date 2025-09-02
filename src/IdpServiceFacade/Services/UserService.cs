using IdpServiceFacade;

namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using Grpc.Core;

internal class UserService(IUserService externalService) : User.UserBase
{
    public override Task<UserReply> InitiatePasswordReset(UserRequest request, ServerCallContext context)
    {
        return externalService.ResetPassword(request.Email, CancellationToken.None).ToUserReply();
    }
}
