namespace Runner;

using Auth0.ManagementApi.Models;

using Commands;

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

    [LoggerMessage(LogLevel.Information, "{Id}: {Name}")]
    internal static partial void Organization(this ILogger<ListOrganizationsCommand> logger, string id, string name);
    
    [LoggerMessage(LogLevel.Information, "{Id}\t {Email}\t{Name}\t{LastLogin:O}")]
    internal static partial void User(this ILogger<ListUsersCommand> logger, string id, string email, string name, DateTime? lastLogin);

    [LoggerMessage(LogLevel.Information, "{Message}")]
    internal static partial void Hello(this ILogger<HelloWorldCommand> logger, string message);
    
    [LoggerMessage(LogLevel.Information, "Added user {UserId} to organization {OrgId}")]
    internal static partial void UserAddedToOrganization(this ILogger<AddUserToOrganizationCommand> logger, string userId, string orgId);
}
