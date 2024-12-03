using Simulator;
using Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields;
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
        _fields = new List<IMappable>?[sizeX, sizeY];
    }

    public override void Add(IMappable mappable, Point position)
    {
        PositionInsideOfTheMapCheck(position);
        _fields[position.X, position.Y] ??= new List<IMappable>();
        _fields[position.X, position.Y]?.Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        PositionInsideOfTheMapCheck(position);
        _fields[position.X, position.Y]?.Remove(mappable);
    }
    public override List<IMappable>? At(Point position)
    {
        PositionInsideOfTheMapCheck(position);
        return _fields[position.X, position.Y];
    }
    public override List<IMappable>? At(int x, int y) => At(new Point(x, y));
    private void PositionInsideOfTheMapCheck(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position is not inside of the map.");
    }
}