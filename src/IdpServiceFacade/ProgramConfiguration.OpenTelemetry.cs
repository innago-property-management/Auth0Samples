namespace Innago.Security.IdpServiceFacade;

using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

internal static partial class ProgramConfiguration
{
    private static Action<MeterProviderBuilder> ConfigureOtelMetrics(string serviceName)
    {
        return Implementation;

        void Implementation(MeterProviderBuilder builder)
        {
            builder.AddMeter(serviceName);
        }
    }

    private static Action<TracerProviderBuilder> ConfigureTracing(string serviceName, IConfiguration configuration)
    {
        return Implementation;

        void Implementation(TracerProviderBuilder builder)
        {
            builder.AddSource(serviceName)
                .AddGrpcCoreInstrumentation()
                .AddAspNetCoreInstrumentation();

            builder.AddOtlpExporter(options =>
            {
                options.Protocol = OtlpExportProtocol.HttpProtobuf;
                options.Endpoint = new Uri(configuration["opentelemetry:endpoint"] ?? throw new InvalidOperationException("missing otlp endpoint"));
            });

            if (configuration["ASPNETCORE_ENVIRONMENT"] == "Development")
            {
                builder.AddConsoleExporter();
            }
        }
    }
}
