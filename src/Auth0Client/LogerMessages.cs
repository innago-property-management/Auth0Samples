namespace Auth0Client;

using System;

using Microsoft.Extensions.Logging;

internal static partial class LogerMessages
{
    private static readonly Action<ILogger, string?, Exception?> ErrorDefinition =
        LoggerMessage.Define<string?>(LogLevel.Error, new EventId(0), "Error: {ErrorMessage}");

    internal static void Error(this ILogger logger, Exception? exception)
    {
        ErrorDefinition(logger, exception?.Message, exception);
    }
}
