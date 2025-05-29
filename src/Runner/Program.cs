using Auth0Net.DependencyInjection;
using Auth0Net.DependencyInjection.Cache;

using DotMake.CommandLine;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Runner;

using Serilog;

IHostBuilder builder = Host.CreateDefaultBuilder();

builder.UseSerilog((context, provider, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(provider));

builder.ConfigureAppConfiguration((_, configurationBuilder) => { configurationBuilder.AddUserSecrets<Program>(); });

builder.ConfigureServices((context, services) =>
{
    services.AddLogging();
    services.AddSingleton(context.Configuration);
    services.AddAuth0AuthenticationClient(ConfigureAuth0);
    services.AddAuth0ManagementClient().AddManagementAccessToken();
    services.AddTransient<IAuth0Client, Auth0Client>();

    return;

    void ConfigureAuth0(Auth0Configuration config)
    {
        config.ClientId = context.Configuration["client_id"];
        config.ClientSecret = context.Configuration["client_secret"];
        config.Domain = context.Configuration["domain"] ?? throw new InvalidOperationException("missing auth0 domain");
    }
});

IHost app = builder.Build();

Cli.Ext.SetServiceProvider(app.Services);

Cli.Run<TopCommands>(args);