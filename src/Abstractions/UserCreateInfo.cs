namespace Abstractions;

using JetBrains.Annotations;

[PublicAPI]
public record UserCreateInfo(string FirstName, string LastName, string Email, string Password);
