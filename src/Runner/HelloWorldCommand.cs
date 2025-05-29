namespace Runner;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand(Aliases = ["hello"])]
internal class HelloWorldCommand(ILogger<HelloWorldCommand> logger)
{
    public void Run()
    {
        logger.Hello("Hello World!");
    }
}