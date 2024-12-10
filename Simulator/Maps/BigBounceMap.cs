using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Simulator.Maps;
public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }
    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        if (!Exist(moved))
        {
            var reversed = p.Next(DirectionParser.Reverse(d));
            if (Exist(reversed)) return reversed;
            return p;
        }
        return moved;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        if (!Exist(moved))
        {
            var reversed = p.NextDiagonal(DirectionParser.Reverse(d));
            if (Exist(reversed)) return reversed;
            return p;
        }
        return moved;
    }
}