namespace Simulator.Maps;
public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        int x = (nextPoint.X + SizeX) % SizeX;
        int y = (nextPoint.Y + SizeY) % SizeY;
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextDiagonal = p.NextDiagonal(d);
        int x = (nextDiagonal.X + SizeX) % SizeX;
        int y = (nextDiagonal.Y + SizeY) % SizeY;
        return new Point(x, y);
    }
}