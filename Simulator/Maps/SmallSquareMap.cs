namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }

    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        if (!Exist(moved))
        {
            return p;
        } 
        return moved;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        if (!Exist(moved)) return p;
        return moved;
    }
}