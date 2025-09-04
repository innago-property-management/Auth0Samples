namespace Abstractions;

public class Auth0Settings
{
    public string Domain { get; set; } = default!;
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
    public string DatabaseName { get; set; } = default!;
    public string ConnectionName { get; set; } = default!;
}
