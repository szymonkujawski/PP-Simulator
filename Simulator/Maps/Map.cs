﻿namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Rectangle _map;
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }
        if (sizeY < 5)
        { 
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short"); 
        }    
            

        SizeX = sizeX;
        SizeY = sizeY;


        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public abstract void Add(IMappable mappable, Point position);
    public abstract void Remove(IMappable mappable, Point position);
    public void Move(IMappable mappable, Point previousPosition, Point afterPosition)
    {
        //if (!Exist(previousPosition) || !Exist(afterPosition))
        //{
        //    throw new ArgumentException("Previous or next position is not inside of the map");
        //}
        Add(mappable, afterPosition);
        Remove(mappable, previousPosition);
    }
    public abstract List<IMappable>? At(int x, int y);
    public abstract List<IMappable>? At(Point position);


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}