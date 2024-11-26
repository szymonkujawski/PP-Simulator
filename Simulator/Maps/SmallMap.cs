using Simulator;
using Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 20)
        { 
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }
        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point position)
    {
        PositionInsideOfTheMapCheck(position);
        _fields[position.X, position.Y] ??= new List<Creature>();
        _fields[position.X, position.Y]?.Add(creature);
    }

    public override void Remove(Creature creature, Point position)
    {
        PositionInsideOfTheMapCheck(position);
        _fields[position.X, position.Y]?.Remove(creature);
    }
    public override List<Creature>? At(Point position)
    {
        PositionInsideOfTheMapCheck(position);
        return _fields[position.X, position.Y];
    }
    public override List<Creature>? At(int x, int y) => At(new Point(x, y));
    private void PositionInsideOfTheMapCheck(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position is not inside of the map.");
    }
}