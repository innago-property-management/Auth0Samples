namespace Abstractions;

using Innago.Shared.TryHelpers;

using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Defines operations related to role management.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Generate token based on ClientId and ClientSecret
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="clientSecret"></param>
    /// <param name="audience"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Result<string>> GetToken(string clientId, string clientSecret, string audience, CancellationToken cancellationToken = default);
}
