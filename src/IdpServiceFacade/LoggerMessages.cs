namespace Innago.Security.IdpServiceFacade;

using System;

using Microsoft.Extensions.Logging;

using Services;

internal static partial class LoggerMessages
{
    private static readonly Action<ILogger, string?, Exception?> ErrorDefinition =
        LoggerMessage.Define<string?>(LogLevel.Error, new EventId(0), "Error: {ErrorMessage}");

    private static readonly Action<ILogger, string?, string, Exception?> ErrorDefinition2 =
        LoggerMessage.Define<string?, string>(LogLevel.Error, new EventId(0), "Error: {ErrorMessage}; Data: {Data}");

    internal static void Error(this ILogger logger, Exception? exception)
    {
        LoggerMessages.ErrorDefinition(logger, exception?.Message, exception);
    }

    internal static void GetUsersByIdsError(this ILogger<UserService> logger, Exception? exception, string userIds)
    {
        LoggerMessages.ErrorDefinition2(logger, exception?.Message, userIds, exception);
    }

    [LoggerMessage(LogLevel.Error, EventName = nameof(OrganizationService.CreateOrganization), Message = "{Error}")]
    internal static partial void CreateOrganizationError(this ILogger<OrganizationService> logger, string? error);

    [LoggerMessage(LogLevel.Information, "{Message}")]
    internal static partial void Information(this ILogger logger, string message);

    [LoggerMessage(LogLevel.Information, "{Email}", EventName = nameof(UserService.InitiatePasswordReset))]
    internal static partial void InitiatePasswordReset(this ILogger logger, string email);

    [LoggerMessage(LogLevel.Debug, "{Message}")]
    internal static partial void Debug(this ILogger logger, string message);
}
