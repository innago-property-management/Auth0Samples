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

        string serviceName = configuration["MY_POD_SERVICE_ACCOUNT"] ?? throw new InvalidOperationException("missing service name");

        string version = configuration["MY_APP_VERSION"] ?? "0.0.1";

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

        services.AddAuth0AuthenticationClient(ConfigureAuth0);
        services.AddAuth0ManagementClient().AddManagementAccessToken();

        services.AddScoped<IUserService, Auth0Client>();

        void ConfigureAuth0(Auth0Configuration config)
        {
            config.ClientId = configuration["client_id"];
            config.ClientSecret = configuration["client_secret"];
            config.Domain = configuration["domain"] ?? throw new InvalidOperationException("missing auth0 domain");
        }
    }
}
