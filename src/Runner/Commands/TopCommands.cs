namespace Runner.Commands;

using System.Diagnostics.CodeAnalysis;

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
[PublicAPI]
[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
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
