namespace Innago.Security.IdpServiceFacade;

using Serilog;
using Serilog.Events;

internal static partial class ProgramConfiguration
{
    internal static LoggerConfiguration SetLogLevelsFromConfig(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
    {
        IConfigurationSection minimumLevelSection = configuration.GetSection("Serilog:MinimumLevel");

        loggerConfiguration.MinimumLevel.Is(minimumLevelSection["default"].ToLogEventLevel());

        IConfigurationSection overrideSection = minimumLevelSection.GetSection("Override");

        foreach (IConfigurationSection overrideEntry in overrideSection.GetChildren())
        {
            loggerConfiguration.MinimumLevel.Override(overrideEntry.Key, overrideEntry.Value.ToLogEventLevel());
        }

        return loggerConfiguration;
    }

    private static LogEventLevel ToLogEventLevel(this string? logLevel)
    {
        return Enum.TryParse(logLevel, true, out LogEventLevel logEventLevel) ? logEventLevel : LogEventLevel.Error;
    }
}
