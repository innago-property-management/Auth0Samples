namespace Auth0Client;

using System.Diagnostics;

public static class Auth0ClientTracer
{
    public static readonly ActivitySource Source = new(typeof(Auth0ClientTracer).FullName!);
}
