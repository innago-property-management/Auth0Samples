namespace Auth0Client;

using System.Diagnostics;

/// <summary>
/// Provides tracing capabilities for Auth0 client operations using Activity Source.
/// </summary>
public static class Auth0ClientTracer
{
    /// <summary>
    /// The activity source used for tracking and monitoring Auth0 client operations.
    /// </summary>
    public static readonly ActivitySource Source = new(typeof(Auth0ClientTracer).FullName!);
}
