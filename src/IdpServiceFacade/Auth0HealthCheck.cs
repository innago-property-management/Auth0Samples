namespace Innago.Security.IdpServiceFacade;

using Abstractions;

using Shared.TryHelpers;

using Microsoft.Extensions.Diagnostics.HealthChecks;

/// <summary>
/// Health check for the Auth0 Management API.
/// </summary>
internal class Auth0HealthCheck(IAuth0Client client) : IHealthCheck
{
    /// <inheritdoc />
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        bool result = await client.HealthCheck(cancellationToken).ConfigureAwait(false);

        return result.Map(() => HealthCheckResult.Healthy(), () => HealthCheckResult.Unhealthy());
    }
}
