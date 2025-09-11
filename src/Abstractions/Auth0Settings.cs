namespace Abstractions;

/// <summary>
/// Contains configuration settings for Auth0 authentication and authorization.
/// </summary>
public class Auth0Settings
{
    /// <summary>
    /// Gets or sets the Auth0 domain URL.
    /// </summary>
    public required string Domain { get; set; }

    /// <summary>
    /// Gets or sets the Auth0 client identifier.
    /// </summary>
    public required string ClientId { get; set; }

    /// <summary>
    /// Gets or sets the Auth0 client secret.
    /// </summary>
    public required string ClientSecret { get; set; }

    /// <summary>
    /// Gets or sets the name of the Auth0 database.
    /// </summary>
    public required string DatabaseName { get; set; }

    /// <summary>
    /// Gets or sets the name of the Auth0 connection.
    /// </summary>
    public required string ConnectionName { get; set; }

    /// <summary>
    /// Gets or sets the name of the Auth0 audience.
    /// </summary>
    public required string Audience { get; set; }

    /// <summary>
    /// Gets or sets the API audience used for authentication and authorization.
    /// </summary>
    public required string ApiAudience { get; set; }
}
