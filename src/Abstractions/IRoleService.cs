namespace Abstractions;

using System.Threading;

using MorseCode.ITask;

public interface IRoleService
{
    ITask<OkError> CreateRole(string roleName, string? description = null, CancellationToken cancellationToken = default);
}
