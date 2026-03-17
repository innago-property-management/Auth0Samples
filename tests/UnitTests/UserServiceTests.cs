namespace UnitTests;

using Abstractions;

using Auth0.ManagementApi.Models;

using Grpc.Core;

using IdpServiceFacade;

using Innago.Security.IdpServiceFacade.Services;

using Microsoft.Extensions.Logging;

using Moq;

using Newtonsoft.Json.Linq;

using System.Reflection;

/// <summary>
/// Unit tests for <see cref="UserService"/> GetMetadataStringValue method.
/// </summary>
public class UserServiceTests
{
    [Fact]
    public void GetMetadataStringValue_WithDictionary_ReturnsValue()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            ["identity_id"] = "b02e9caf-2848-485a-a945-c90a33c21859",
            ["first_name"] = "John",
            ["last_name"] = "Doe"
        };

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "identity_id");

        // Assert
        Assert.Equal("b02e9caf-2848-485a-a945-c90a33c21859", result);
    }

    [Fact]
    public void GetMetadataStringValue_WithJObject_ReturnsValue()
    {
        // Arrange - Simulate Auth0 response with JObject
        var jsonString = @"{
            ""identity_id"": ""b02e9caf-2848-485a-a945-c90a33c21859"",
            ""first_name"": ""Rohit"",
            ""last_name"": ""Lal"",
            ""role_id"": ""3"",
            ""user_id"": ""505130""
        }";
        var metadata = JObject.Parse(jsonString);

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "identity_id");

        // Assert
        Assert.Equal("b02e9caf-2848-485a-a945-c90a33c21859", result);
    }

    [Fact]
    public void GetMetadataStringValue_WithJObject_MultipleKeys_ReturnsCorrectValues()
    {
        // Arrange
        var jsonString = @"{
            ""identity_id"": ""b02e9caf-2848-485a-a945-c90a33c21859"",
            ""first_name"": ""Rohit"",
            ""last_name"": ""Lal"",
            ""role_id"": ""3"",
            ""user_id"": ""505130"",
            ""two_factor_enabled"": ""true""
        }";
        var metadata = JObject.Parse(jsonString);

        // Act & Assert
        Assert.Equal("b02e9caf-2848-485a-a945-c90a33c21859", InvokeGetMetadataStringValue(metadata, "identity_id"));
        Assert.Equal("Rohit", InvokeGetMetadataStringValue(metadata, "first_name"));
        Assert.Equal("Lal", InvokeGetMetadataStringValue(metadata, "last_name"));
        Assert.Equal("3", InvokeGetMetadataStringValue(metadata, "role_id"));
        Assert.Equal("505130", InvokeGetMetadataStringValue(metadata, "user_id"));
        Assert.Equal("true", InvokeGetMetadataStringValue(metadata, "two_factor_enabled"));
    }

    [Fact]
    public void GetMetadataStringValue_WithNullMetadata_ReturnsNull()
    {
        // Act
        var result = InvokeGetMetadataStringValue(null, "identity_id");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetMetadataStringValue_WithNonExistentKey_ReturnsNull()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            ["first_name"] = "John"
        };

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "non_existent_key");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetMetadataStringValue_WithEmptyString_ReturnsNull()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            ["identity_id"] = ""
        };

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "identity_id");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetMetadataStringValue_WithWhitespace_ReturnsNull()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            ["identity_id"] = "   "
        };

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "identity_id");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetMetadataStringValue_WithNullValue_ReturnsNull()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            ["identity_id"] = null!
        };

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "identity_id");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetMetadataStringValue_WithNumericValue_ReturnsStringRepresentation()
    {
        // Arrange
        var metadata = new Dictionary<string, object>
        {
            ["user_id"] = 12345
        };

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "user_id");

        // Assert
        Assert.Equal("12345", result);
    }

    [Fact]
    public void GetMetadataStringValue_WithJObjectNumericValue_ReturnsStringRepresentation()
    {
        // Arrange
        var jsonString = @"{""user_id"": 12345}";
        var metadata = JObject.Parse(jsonString);

        // Act
        var result = InvokeGetMetadataStringValue(metadata, "user_id");

        // Assert
        Assert.Equal("12345", result);
    }

    /// <summary>
    /// Helper method to invoke the private GetMetadataStringValue method using reflection
    /// </summary>
    private static string? InvokeGetMetadataStringValue(object? metadata, string key)
    {
        var method = typeof(UserService).GetMethod(
            "GetMetadataStringValue",
            BindingFlags.NonPublic | BindingFlags.Static);

        if (method == null)
        {
            throw new InvalidOperationException("GetMetadataStringValue method not found");
        }

        return method.Invoke(null, [metadata, key]) as string;
    }
}
