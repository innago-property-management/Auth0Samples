namespace Runner;

using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

using Bogus;

internal class Auth0Client(IManagementApiClient client) : IAuth0Client
{
    private static Faker Faker { get; } = new();

    public Task<User> CreateUser(CancellationToken cancellationToken)
    {
        UserCreateRequest request = new()
        {
            Email = Faker.Person.Email,
            FirstName = Faker.Person.FirstName,
            LastName = Faker.Person.LastName,
            EmailVerified = false,
            VerifyEmail = false,
            Password = $"{Faker.Internet.Password(16)}-Aa1!",
            Connection = "Username-Password-Authentication",
        };

        return client.Users.CreateAsync(request, cancellationToken);
    }
}