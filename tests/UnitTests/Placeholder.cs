namespace UnitTests;

using FluentAssertions;

public class Placeholder
{
    [Fact]
    public void PlaceholderTest()
    {
        1.Should().NotBe(2);
    }
}