namespace Simulator.Maps;
public class SmallTorusMap : Map
{
    private readonly Rectangle border;
    public int Size { get; }
    public SmallTorusMap(int size)
    {
        if (size > 20 || size < 5)
            throw new ArgumentOutOfRangeException("Error! Size should be in range [5-20]");
        Size = size;
        border = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point point) => border.Contains(point);
    public override Point Next(Point point, Direction direction)
    {
        var moved = point.Next(direction);

        return new Point((moved.X + Size) % Size, (moved.Y + Size) % Size);
    }

    public override Point NextDiagonal(Point point, Direction direction)
    {
        var moved = point.NextDiagonal(direction);

        return new Point((moved.X + Size) % Size, (moved.Y + Size) % Size);
    }
}