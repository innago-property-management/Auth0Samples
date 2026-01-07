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

    [LoggerMessage(LogLevel.Error, EventName = nameof(OrganizationService.ListOrganizations), Message = "{Error}")]
    internal static partial void ListOrganizationsError(this ILogger<OrganizationService> logger, string? error);

    [LoggerMessage(LogLevel.Error, EventName = nameof(OrganizationService.UpdateOrganizationByUid), Message = "{Error}")]
    internal static partial void UpdateOrganizationByUidError(this ILogger<OrganizationService> logger, string? error);

    [LoggerMessage(LogLevel.Information, "{Message}")]
    internal static partial void Information(this ILogger logger, string message);

    [LoggerMessage(LogLevel.Information, "{Email}", EventName = nameof(UserService.InitiatePasswordReset))]
    internal static partial void InitiatePasswordReset(this ILogger logger, string email);

    [LoggerMessage(LogLevel.Debug, "{Message}")]
    internal static partial void Debug(this ILogger logger, string message);

    // Auth Service Events (2000-2099)
    [LoggerMessage(
        LogLevel.Information,
        EventId = 2001,
        EventName = nameof(TokenRequestSucceeded),
        Message = "Token request succeeded for client {ClientId}, audience {Audience}, expires in {ExpiresIn}s")]
    internal static partial void TokenRequestSucceeded(
        this ILogger<AuthService> logger,
        string clientId,
        string audience,
        int expiresIn);

    [LoggerMessage(
        LogLevel.Warning,
        EventId = 2002,
        EventName = nameof(TokenRequestFailed),
        Message = "Token request failed for client {ClientId}, audience {Audience}: {ErrorMessage}")]
    internal static partial void TokenRequestFailed(
        this ILogger<AuthService> logger,
        string clientId,
        string audience,
        string? errorMessage);

    [LoggerMessage(
        LogLevel.Debug,
        EventId = 2003,
        EventName = nameof(TokenRequestStarted),
        Message = "Starting token request for client {ClientId}, audience {Audience}")]
    internal static partial void TokenRequestStarted(
        this ILogger<AuthService> logger,
        string clientId,
        string audience);
}
