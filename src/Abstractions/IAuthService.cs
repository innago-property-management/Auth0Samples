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

    /// <summary>
    /// Retrieves an OAuth2 Client Credentials token as defined in RFC 6749 Section 4.4.
    /// </summary>
    /// <param name="clientId">The client identifier issued to the client.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="audience">The target audience for the token.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A result containing the client credentials token response or an error.</returns>
    Task<Result<ClientCredentialsToken>> GetClientCredentialsToken(
        string clientId,
        string clientSecret,
        string audience,
        CancellationToken cancellationToken = default);
}
