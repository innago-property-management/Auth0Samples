namespace Runner;

using DotMake.CommandLine;

[CliCommand(Children =
[
    typeof(HelloWorldCommand),
    typeof(CreateUserCommand),
    typeof(ListUsersCommand),
    typeof(CreateOrganizationCommand),
])]
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