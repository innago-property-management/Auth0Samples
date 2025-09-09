namespace Innago.Security.IdpServiceFacade;

using Abstractions;

using Auth0Client;

using Auth0Net.DependencyInjection;
using Auth0Net.DependencyInjection.Cache;

using Microsoft.AspNetCore.HttpOverrides;

using OpenTelemetry.Resources;

using Prometheus;

using Serilog;

internal static partial class ProgramConfiguration
{
    internal static void ConfigureServices(this IServiceCollection services, IConfiguration configuration, ILogger logger)
    {
        services.AddSerilog(logger);

        services.AddGrpc();
        services.AddGrpcReflection();

        services.AddScoped<IAuth0Client, Auth0Client>();

        services.AddHealthChecks()
            .AddCheck<Auth0HealthCheck>(nameof(Auth0HealthCheck))
            .ForwardToPrometheus();

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        services.AddHttpContextAccessor();

        services.AddGrpcHealthChecks();

        string serviceName = configuration["openTelemetry:ServiceName"] ?? throw new InvalidOperationException("missing service name");

        services.AddOpenTelemetry()
            .ConfigureResource(builder => builder.AddService(serviceName))
            .WithTracing(ConfigureTracing(serviceName, configuration))
            .WithMetrics(ConfigureOtelMetrics(serviceName));

        services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.WriteIndented = true;
            //// options.SerializerOptions.Converters.Add(new AddressConverter());
            options.SerializerOptions.TypeInfoResolver = AppJsonSerializerContext.Default;
        });

        services.AddAuth0AuthenticationClient(ConfigureAuth0).SetCertificateValidationOptions(configuration);

        services.AddAuth0ManagementClient().AddManagementAccessToken().SetCertificateValidationOptions(configuration);

        services.AddScoped<IUserService, Auth0Client>();

        services.AddOptions<Auth0Settings>().BindConfiguration("Auth0");

        return;

        void ConfigureAuth0(Auth0Configuration config)
        {
            config.ClientId = configuration["Auth0:ClientId"];
            config.ClientSecret = configuration["Auth0:ClientSecret"];
            config.Domain = configuration["Auth0:Domain"] ?? throw new InvalidOperationException("missing auth0 domain");
        }
    }
}
