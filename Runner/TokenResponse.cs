namespace Runner;

using JetBrains.Annotations;

[UsedImplicitly]
internal record TokenResponse(string? AccessToken, string? RefreshToken, string? IdToken, string? TokenType, int? ExpiresIn);