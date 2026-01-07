namespace UnitTests;

using Abstractions;

using AwesomeAssertions;

using Grpc.Core;

using IdpServiceFacade;

using Innago.Security.IdpServiceFacade.Services;

using Innago.Shared.TryHelpers;

using Microsoft.Extensions.Logging;

using Moq;

/// <summary>
/// Unit tests for <see cref="AuthService"/>.
/// </summary>
public class AuthServiceTests
{
    private readonly Mock<IAuthService> _mockAuthService;
    private readonly Mock<ILogger<AuthService>> _mockLogger;
    private readonly AuthService _sut;

    public AuthServiceTests()
    {
        _mockAuthService = new Mock<IAuthService>(MockBehavior.Strict);
        _mockLogger = new Mock<ILogger<AuthService>>(MockBehavior.Loose);
        _sut = new AuthService(_mockAuthService.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task GetToken_WithValidCredentials_ReturnsFullOAuth2Response()
    {
        // Arrange
        var request = new GetTokenRequest
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret",
            Audience = "https://api.example.com"
        };

        var expectedToken = new ClientCredentialsToken(
            AccessToken: "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.test-token",
            TokenType: "Bearer",
            ExpiresIn: 86400,
            Scope: "read:data write:data");

        _mockAuthService
            .Setup(x => x.GetClientCredentialsToken(
                request.ClientId,
                request.ClientSecret,
                request.Audience,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Result<ClientCredentialsToken>(expectedToken));

        var context = CreateTestServerCallContext();

        // Act
        GetTokenResponse response = await _sut.GetToken(request, context);

        // Assert
        response.Ok.Should().BeTrue();
        response.AccessToken.Should().Be(expectedToken.AccessToken);
        response.TokenType.Should().Be("Bearer");
        response.ExpiresIn.Should().Be(86400);
        response.Scope.Should().Be("read:data write:data");
        response.Error.Should().BeEmpty();
    }

    [Fact]
    public async Task GetToken_WithInvalidCredentials_ReturnsErrorResponse()
    {
        // Arrange
        var request = new GetTokenRequest
        {
            ClientId = "invalid-client-id",
            ClientSecret = "wrong-secret",
            Audience = "https://api.example.com"
        };

        _mockAuthService
            .Setup(x => x.GetClientCredentialsToken(
                request.ClientId,
                request.ClientSecret,
                request.Audience,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Result<ClientCredentialsToken>(
                new InvalidOperationException("Auth0 API Error: invalid_client")));

        var context = CreateTestServerCallContext();

        // Act
        GetTokenResponse response = await _sut.GetToken(request, context);

        // Assert
        response.Ok.Should().BeFalse();
        response.Error.Should().Be("invalid_grant");
        response.ErrorDescription.Should().Be("Token request failed");
        response.AccessToken.Should().BeEmpty();
        response.TokenType.Should().BeEmpty();
        response.ExpiresIn.Should().Be(0);
    }

    [Fact]
    public async Task GetToken_WithNullScope_ReturnsEmptyScope()
    {
        // Arrange
        var request = new GetTokenRequest
        {
            ClientId = "test-client-id",
            ClientSecret = "test-client-secret",
            Audience = "https://api.example.com"
        };

        var tokenWithNullScope = new ClientCredentialsToken(
            AccessToken: "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.test-token",
            TokenType: "Bearer",
            ExpiresIn: 3600,
            Scope: null);

        _mockAuthService
            .Setup(x => x.GetClientCredentialsToken(
                request.ClientId,
                request.ClientSecret,
                request.Audience,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Result<ClientCredentialsToken>(tokenWithNullScope));

        var context = CreateTestServerCallContext();

        // Act
        GetTokenResponse response = await _sut.GetToken(request, context);

        // Assert
        response.Ok.Should().BeTrue();
        response.Scope.Should().BeEmpty();
    }

    [Fact]
    public async Task GetToken_CallsAuthServiceWithCorrectParameters()
    {
        // Arrange
        var request = new GetTokenRequest
        {
            ClientId = "verify-params-client",
            ClientSecret = "verify-params-secret",
            Audience = "https://verify.example.com"
        };

        var token = new ClientCredentialsToken(
            AccessToken: "test-token",
            TokenType: "Bearer",
            ExpiresIn: 3600,
            Scope: null);

        _mockAuthService
            .Setup(x => x.GetClientCredentialsToken(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Result<ClientCredentialsToken>(token));

        var context = CreateTestServerCallContext();

        // Act
        await _sut.GetToken(request, context);

        // Assert
        _mockAuthService.Verify(x => x.GetClientCredentialsToken(
            "verify-params-client",
            "verify-params-secret",
            "https://verify.example.com",
            It.IsAny<CancellationToken>()), Times.Once);
    }

    private static ServerCallContext CreateTestServerCallContext()
    {
        return new TestServerCallContext();
    }

    /// <summary>
    /// Test implementation of ServerCallContext for unit testing gRPC services.
    /// </summary>
    private sealed class TestServerCallContext : ServerCallContext
    {
        protected override string MethodCore => "TestMethod";
        protected override string HostCore => "localhost";
        protected override string PeerCore => "127.0.0.1";
        protected override DateTime DeadlineCore => DateTime.MaxValue;
        protected override Grpc.Core.Metadata RequestHeadersCore => [];
        protected override CancellationToken CancellationTokenCore => CancellationToken.None;
        protected override Grpc.Core.Metadata ResponseTrailersCore => [];
        protected override Status StatusCore { get; set; }
        protected override WriteOptions? WriteOptionsCore { get; set; }
        protected override AuthContext AuthContextCore => new(string.Empty, []);

        protected override ContextPropagationToken CreatePropagationTokenCore(ContextPropagationOptions? options)
        {
            throw new NotImplementedException();
        }

        protected override Task WriteResponseHeadersAsyncCore(Grpc.Core.Metadata responseHeaders)
        {
            return Task.CompletedTask;
        }
    }
}
