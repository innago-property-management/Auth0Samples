namespace Abstractions;

public class Auth0Settings
{
    public string Domain { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ConnectionName { get; set; } = null!;
}
