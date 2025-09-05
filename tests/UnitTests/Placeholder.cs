namespace UnitTests;

using AwesomeAssertions;

public class Placeholder
{
    [Fact]
    public void PlaceholderTest()
    {
        1.Should().NotBe(2);
    }
}
