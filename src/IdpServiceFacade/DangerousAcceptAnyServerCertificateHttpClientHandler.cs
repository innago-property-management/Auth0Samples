namespace Innago.Security.IdpServiceFacade;

internal static class DangerousAcceptAnyServerCertificateHttpClientHandler
{
    public static IHttpClientBuilder SetCertificateValidationOptions(this IHttpClientBuilder builder, IConfiguration configuration)
    {
        return configuration["ASPNETCORE_ENVIRONMENT"] switch
        {
#if DEBUG
            "Development" => builder.ConfigurePrimaryHttpMessageHandler(() =>
                new HttpClientHandler
                {
#pragma warning disable S4830
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
#pragma warning restore S4830
                }),
#endif
            _ => builder,
        };
    }
}
