using Simulator;
namespace TestSimulator;
public class PointTests
{
    [Theory]
    [InlineData(7, -18, Direction.Up, 7, -17)]
    [InlineData(0, -1, Direction.Up, 0, 0)]
    [InlineData(19, -3, Direction.Right, 20, -3)]
    [InlineData(17, 11, Direction.Right, 18, 11)]
    [InlineData(-2, -18, Direction.Down, -2, -19)]
    [InlineData(-7, 4, Direction.Down, -7, 3)]
    [InlineData(12, -9, Direction.Left, 11, -9)]
    [InlineData(6, -14, Direction.Left, 5, -14)]
    public void Next_ShouldReturnCorrectPositionOfPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(7, -18, Direction.Up, 8, -17)]
    [InlineData(0, -1, Direction.Up, 1, 0)]
    [InlineData(19, -3, Direction.Right, 20, -4)]
    [InlineData(17, 11, Direction.Right, 18, 10)]
    [InlineData(-2, -18, Direction.Down, -3, -19)]
    [InlineData(-7, 4, Direction.Down, -8, 3)]
    [InlineData(12, -9, Direction.Left, 11, -8)]
    [InlineData(6, -14, Direction.Left, 5, -13)]
    public void NextDiagonal_ShouldReturnCorrectPositionOfPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, "(0, 0)")]
    [InlineData(1, 1, "(1, 1)")]
    [InlineData(-2, -1, "(-2, -1)")]
    [InlineData(231, -327, "(231, -327)")]
    public void ToString_ShouldReturnCorrectFormatOfPoints(int x, int y, string expected)
    {
        var point = new Point(x, y);
        var result = point.ToString();
        Assert.Equal(expected, result);
    }
}