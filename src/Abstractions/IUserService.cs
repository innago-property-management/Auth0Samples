namespace Abstractions;

using System.Threading;

using MorseCode.ITask;

public interface IUserService
{
    ITask<OkError> ResetPassword(string email, CancellationToken cancellationToken);

    ITask<OkError> MarkUserAsSuspicious(string email, CancellationToken cancellationToken);

    ITask<OkError> ChangePassword(string email, string newPassword, CancellationToken cancellationToken);

    ITask<OkError> ToggleMFA(string email, bool enable, CancellationToken cancellationToken);

    ITask<OkError> BlockUser(string email, CancellationToken cancellationToken);

    ITask<OkError> UnblockUser(string email, CancellationToken cancellationToken);
}
