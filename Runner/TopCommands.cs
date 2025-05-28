namespace Runner;

using DotMake.CommandLine;

[CliCommand(Children = [typeof(HelloWorldCommand), typeof(CreateUserCommand)])]
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