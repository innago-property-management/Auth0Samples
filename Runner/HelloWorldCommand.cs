namespace Runner;

using DotMake.CommandLine;

[CliCommand(Aliases = ["hello"])]
internal class HelloWorldCommand
{
    public void Run()
    {
        Console.WriteLine("Hello World!");
    }
}