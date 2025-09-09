using Innago.Security.IdpServiceFacade;
using Innago.Security.IdpServiceFacade.Services;

using Prometheus;

using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Grafana.Loki;
using Serilog.Sinks.OpenTelemetry;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
    .SetLogLevelsFromConfig(builder.Configuration)
    .WriteTo.Console(new RenderedCompactJsonFormatter())
    .WriteTo.OpenTelemetry(options =>
    {
        string authority = new Uri(builder.Configuration["openTelemetry:endpoint"] ?? throw new InvalidOperationException()).GetLeftPart(UriPartial.Authority);
        options.Endpoint = $"{authority}/v1/logs";
        options.Protocol = OtlpProtocol.HttpProtobuf;
    })
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentVariable("MY_POD_NAME")
    .Enrich.WithClientIp()
    .Enrich.WithCorrelationId()
    .Enrich.WithRequestHeader("x-user-id")
    .Enrich.WithRequestHeader("x-organization-id")
    .Enrich.WithRequestHeader("x-user-email-address")
    .Enrich.WithRequestHeader("X-Forwarded-For")
    .Enrich.WithRequestHeader("X-B3-TraceId")
    .Enrich.WithRequestHeader("X-B3-SpanId")
    .Enrich.WithRequestHeader("X-B3-ParentSpanId");

if (builder.Environment.IsDevelopment())
{
    string uri = builder.Configuration["serilog:writeTo:1:args:uri"] ?? throw new InvalidOperationException();
    string serviceName = builder.Configuration["MY_POD_SERVICE_ACCOUNT"] ?? throw new InvalidOperationException();
    loggerConfiguration.WriteTo.GrafanaLoki(uri, propertiesAsLabels: ["app"], labels: [new LokiLabel { Key = "app", Value = serviceName }]);
}

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080, listenOptions =>
    {
        listenOptions.Protocols =  HttpProtocols.Http1;
    });

    serverOptions.ListenAnyIP(5009, listenOptions =>
    {
        listenOptions.Protocols =  HttpProtocols.Http1AndHttp2;

        listenOptions.UseHttps(httpsOptions =>
        {
            try
            {
                httpsOptions.ServerCertificate = X509Certificate2.CreateFromPemFile("/etc/ssl/certs/tls.crt", "/etc/ssl/certs/tls.key");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TLS ERROR] Failed to load certificate: {ex.Message}");
            }
        });

        listenOptions.Protocols =  HttpProtocols.Http2;
    });
    serverOptions.ListenAnyIP(5008, listenOptions =>
    {
        // gRPC over plaintext (no TLS)
        listenOptions.Protocols =  HttpProtocols.Http2;
    });
});

Log.Logger = loggerConfiguration.CreateLogger();

builder.Services.ConfigureServices(builder.Configuration, Log.Logger);

WebApplication app = builder.Build();

app.UseRouting();
app.UseGrpcMetrics();
app.UseHttpMetrics();

app.UseForwardedHeaders();
app.UseSerilogRequestLogging();

app.MapGrpcService<UserService>();

app.MapGrpcHealthChecksService();

app.MapGrpcReflectionService();
app.MapMetrics("/metricsz");
app.MapHealthChecks("/healthz");

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

await app.RunAsync().ConfigureAwait(false);
