namespace Runner.Commands;

using Abstractions;

using Auth0.ManagementApi.Models;

using DotMake.CommandLine;

using Microsoft.Extensions.Logging;

[CliCommand]
internal class CreateUserCommand(IAuth0Client client, ILogger<CreateUserCommand> logger)
{
    [CliOption(Description = "The first name.", Required = true)]
    public string Email { get; set; } = null!;

    [CliOption(Description = "The first name.", Required = true)]
    public string FirstName { get; set; } = null!;

    [CliOption(Description = "The first name.", Required = true)]
    public string LastName { get; set; } = null!;

    [CliOption(Description = "The first name.", Required = true)]
    public string Password { get; set; } = null!;

    public async Task RunAsync(CliContext context)
    {
        UserCreateInfo info = new(this.FirstName, this.LastName, this.Email, this.Password);
        (User user, string password) = await client.CreateUser(info, context.CancellationToken).ConfigureAwait(false);

        logger.UserCreated(user, password);
    }
}
