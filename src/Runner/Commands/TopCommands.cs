namespace Runner.Commands;

using DotMake.CommandLine;

using JetBrains.Annotations;

[CliCommand(Children =
[
    typeof(HelloWorldCommand),
    typeof(CreateUserCommand),
    typeof(ListUsersCommand),
    typeof(CreateOrganizationCommand),
    typeof(ListOrganizationsCommand),
    typeof(AddUserToOrganizationCommand),
])]
[UsedImplicitly]
internal class TopCommands
{
    public void Run(CliContext context)
    {
        if (context.IsEmptyCommand())
        {
            context.ShowHierarchy();
        }
        else
        {
            context.ShowValues();
        }
    }
}