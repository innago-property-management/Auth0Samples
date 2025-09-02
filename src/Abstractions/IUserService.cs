namespace Abstractions;

using System.Threading;

using MorseCode.ITask;

public interface IUserService
{
    ITask<OkError> ResetPassword(string email, CancellationToken cancellationToken);

    ITask<OkError> MarkUserAsSuspicious(string email, CancellationToken cancellationToken);
}
