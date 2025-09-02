namespace Innago.Security.IdpServiceFacade;

using System.Diagnostics;

public static class IdpServiceFacadeTracer
{
    public static readonly ActivitySource Source = new(typeof(IdpServiceFacadeTracer).FullName!);
}
