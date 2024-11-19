using Simulator.Maps;
using Simulator;
namespace TestSimulator;
public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 10;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(1, 1, 6, true)]
    [InlineData(12, 12, 20, true)]
    [InlineData(11, 1, 10, false)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 5, 11)]
    [InlineData(6, 6, Direction.Down, 6, 5)]
    [InlineData(5, 8, Direction.Left, 4, 8)]
    [InlineData(10, 10, Direction.Right, 11, 10)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(9, 9, Direction.Up, 9, 9)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(9, 9, Direction.Right, 9, 9)]
    public void Next_ShouldReturnTheSamePointBecauseOfBorder(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(2, 2, Direction.Up, 3, 3)]
    [InlineData(2, 2, Direction.Down, 1, 1)]
    [InlineData(3, 1, Direction.Left, 2, 2)]
    [InlineData(9, 2, Direction.Right, 10, 1)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(9, 9, Direction.Up, 9, 9)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(9, 9, Direction.Right, 9, 9)]
    public void NextDiagonal_ShouldReturnTheSamePointBecauseOfBorder(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(50)]
    [InlineData(100)]
    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallTorusMap(size));
    }
}