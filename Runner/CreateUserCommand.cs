namespace Runner;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

[CliCommand]
internal class CreateUserCommand(IAuth0Client client)
{
    public async Task RunAsync(CliContext context)
    {
        User user = await client.CreateUser(context.CancellationToken).ConfigureAwait(false);

        Console.WriteLine($"{user.UserId} created");
    }
}