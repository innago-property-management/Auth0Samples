namespace Runner.Commands;

using DotMake.CommandLine;

using Messages;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["hello"])]
internal class HelloWorldCommand(ILogger<HelloWorldCommand> logger)
{
    public void Run()
    {
        logger.Hello("Hello World!");
    }
}