namespace Runner;

using Auth0.ManagementApi.Models;

using Microsoft.Extensions.Logging;

internal static partial class LoggerMessages
{
    private static Action<ILogger, string, Exception?> UserCreatedDefinition =>
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(),
            "User created with id: {Id}");

    private static Action<ILogger, string, Exception?>
        OrganizationCreatedDefinition =>
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(),
            "Organization created with id: {Id}");

    internal static void UserCreated(this ILogger<CreateUserCommand> logger, User user)
    {
        UserCreatedDefinition(logger, user.UserId, null);
    }

    internal static void OrganizationCreated(this ILogger<CreateOrganizationCommand> logger, Organization organization)
    {
        OrganizationCreatedDefinition(logger, organization.Id, null);
    }
}