namespace Runner.Messages;

using Auth0.ManagementApi.Models;

using Microsoft.Extensions.Logging;

using Commands;

internal static partial class LoggerMessages
{
    private static Action<ILogger, string, Exception?> UserCreatedDefinition =>
        LoggerMessage.Define<string>(
            LogLevel.Information,
            new EventId(),
            "User created with id: {Id}");

    internal static void UserCreated(this ILogger<CreateUserCommand> logger, User user)
    {
        UserCreatedDefinition(logger, user.UserId, null);
    }

    [LoggerMessage(LogLevel.Information, EventName = nameof(OrganizationCreated), Message = "{Result}")]
    internal static partial void OrganizationCreated(this ILogger<CreateOrganizationCommand> logger, string? result);

    [LoggerMessage(LogLevel.Information, "{Id}: {Name}")]
    internal static partial void Organization(this ILogger<ListOrganizationsCommand> logger, string id, string name);

    [LoggerMessage(LogLevel.Information, "{Id}")]
    internal static partial void GetUser(this ILogger<GetUserCommand> logger, string id);

    [LoggerMessage(LogLevel.Information, "{Id}\t {Email}\t{Name}\t{LastLogin:O}")]
    internal static partial void User(this ILogger<ListUsersCommand> logger, string id, string email, string name, DateTime? lastLogin);

    [LoggerMessage(LogLevel.Information, "{Message}")]
    internal static partial void Hello(this ILogger<HelloWorldCommand> logger, string message);
}
