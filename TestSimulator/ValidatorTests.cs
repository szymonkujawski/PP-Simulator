using Simulator;
namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(7, 1, 15, 7)]
    [InlineData(0, 2, 15, 2)]
    [InlineData(19, 1, 15, 15)]
    [InlineData(1, 1, 15, 1)]
    [InlineData(1, 2, 15, 2)]
    [InlineData(15, 2, 15, 15)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_ShouldWorkWithEmptyString()
    {
        string value = "";
        int min = 5;
        int max = 10;
        char placeholder = '_';
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal("_____", result);
    }

    [Fact]
    public void Shortener_ShouldConvertFirstCharacterToUppercaseLetter()
    {
        string value = "lowercase";
        int min = 5;
        int max = 15;
        char placeholder = '_';
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal("Lowercase", result);
    }

    [Theory]
    [InlineData("test", 1, 10, '_', "Test")]
    [InlineData("too long value", 1, 10, '-', "Too long v")]
    [InlineData("short", 7, 15, '_', "Short__")]
    [InlineData("  whitespace  ", 5, 15, '_', "Whitespace")]
    [InlineData("Mice           are great", 3, 15, '#', "Mice")]
    [InlineData("a                            troll name", 5, 10, '#', "A####")]
    [InlineData("  ", 2, 10, '*', "**")]
    [InlineData("  ", 1, 2, '-', "-")]
    [InlineData("  ", 2, 4, '_', "__")]
    [InlineData("Puss in Boots – a clever and brave cat.", 1, 10, '#', "Puss in Bo")]
    public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}