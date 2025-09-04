namespace Innago.Security.IdpServiceFacade;

using System.Diagnostics;

/// <summary>
/// Provides trace instrumentation for operations related to the Identity Provider (IdP) service facade.
/// </summary>
/// <remarks>
/// This static class is designed to facilitate distributed tracing by acting as a source for activity tracking
/// in the context of Identity Provider-related operations within the system.
/// </remarks>
public static class IdpServiceFacadeTracer
{
    /// <summary>
    /// Represents the <see cref="ActivitySource"/> for tracing operations in the Identity Provider (IdP) service facade.
    /// </summary>
    /// <remarks>
    /// This field is used to create and manage activity spans for distributed tracing, enabling detailed monitoring
    /// and troubleshooting of operations within the IdP service facade. It is configured to use the fully qualified
    /// name of the <see cref="IdpServiceFacadeTracer"/> class as its source name.
    /// </remarks>
    public static readonly ActivitySource Source = new(typeof(IdpServiceFacadeTracer).FullName!);
}
