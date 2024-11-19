using Simulator;
namespace TestSimulator;
public class RectangleTests
{
    [Theory]
    [InlineData(4, 5, 1, 1, 1, 1, 4, 5)]
    [InlineData(1, 5, 4, 1, 1, 1, 4, 5)]
    [InlineData(-7, -7, 7, 7, -7, -7, 7, 7)]
    [InlineData(0, 0, 7, 7, 0, 0, 7, 7)]
    [InlineData(5, 5, 2, 2, 2, 2, 5, 5)]
    public void Constructor_ShouldSetCorrectCoordinates(int x1, int y1, int x2, int y2, int expectedX1, int expectedY1, int expectedX2, int expectedY2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(expectedX1, rectangle.X1);
        Assert.Equal(expectedY1, rectangle.Y1);
        Assert.Equal(expectedX2, rectangle.X2);
        Assert.Equal(expectedY2, rectangle.Y2);
    }

    [Theory]
    [InlineData(1, 1, 5, 5, 2, 2, true)]
    [InlineData(1, 1, 5, 5, 4, 6, false)]
    [InlineData(1, 1, 3, 5, 3, 1, true)]
    [InlineData(1, 1, 3, 5, 1, 5, true)]
    [InlineData(0, 0, 15, 10, 7, 7, true)]
    [InlineData(0, 0, 15, 15, 0, 0, true)]
    [InlineData(0, 0, 15, 15, 15, 15, true)]
    [InlineData(0, 0, 15, 15, -1, -1, false)]
    [InlineData(0, 0, 15, 15, 16, 5, false)]
    [InlineData(0, 0, 15, 15, 5, 16, false)]
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        var result = rectangle.Contains(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 15, 15, "(0, 0):(15, 15)")]
    [InlineData(0, 0, 12, 12, "(0, 0):(12, 12)")]
    [InlineData(-15, -5, 5, 15, "(-15, -5):(5, 15)")]
    [InlineData(7, 7, 0, 0, "(0, 0):(7, 7)")]
    public void ToString_ShouldReturnCorrectFormat(int x1, int y1, int x2, int y2, string expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var result = rectangle.ToString();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0, 7)]
    [InlineData(0, 0, 7, 0)]
    [InlineData(-7, -7, -2, -7)]
    [InlineData(2, 2, 2, 7)]
    [InlineData(7, 7, 7, 7)]
    public void Constructor_InvalidRectangle_ShouldThrowArgumentExceptionBecauseOfInlinePoints(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }
}