namespace Innago.Security.IdpServiceFacade;

using Microsoft.AspNetCore.HttpOverrides;

using OpenTelemetry.Resources;

using Prometheus;

using Serilog;

internal static partial class ProgramConfiguration
{
    internal static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSerilog();

        services.AddGrpc();
        services.AddGrpcReflection();

        services.AddHealthChecks().ForwardToPrometheus();

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        services.AddHttpContextAccessor();

        services.AddGrpcHealthChecks();

        ////services.AddScoped<IUserIdService, UserIdService>();

        string serviceName = configuration["serviceName"] ?? throw new InvalidOperationException("missing service name");

        string version = configuration["ServiceVersion"] ?? "0.0.1";

        services.AddOpenTelemetry()
            .ConfigureResource(builder => builder.AddService(serviceName, version))
            .WithTracing(ConfigureTracing(serviceName, configuration))
            .WithMetrics(ConfigureOtelMetrics(serviceName));

        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.WriteIndented = true;
            //// options.SerializerOptions.Converters.Add(new AddressConverter());
            options.SerializerOptions.TypeInfoResolver = AppJsonSerializerContext.Default;
        });
    }
}
