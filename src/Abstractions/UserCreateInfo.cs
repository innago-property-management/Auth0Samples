namespace Abstractions;

using JetBrains.Annotations;

/// <summary>
/// Represents the information required to create a user.
/// </summary>
/// <param name="FirstName">The first name of the user.</param>
/// <param name="LastName">The last name of the user.</param>
/// <param name="Email">The email address of the user.</param>
/// <param name="Password">The password for the user account.</param>
[PublicAPI]
public record UserCreateInfo(string FirstName, string LastName, string Email, string Password);
