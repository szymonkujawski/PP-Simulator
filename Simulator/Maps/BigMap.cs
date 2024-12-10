﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Simulator.Maps;
public abstract class BigMap : Map
{
    Dictionary<Point, List<IMappable>>? _fields;
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Map is too wide");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Map is too high");
        _fields = new Dictionary<Point, List<IMappable>>();
    }
    public override void Add(IMappable mappable, Point position)
    {
        CheckIfPositionWithinMap(position);
        if (!_fields.ContainsKey(position)) _fields[position] = new List<IMappable>();
        _fields[position].Add(mappable);
    }
    public override void Remove(IMappable mappable, Point position)
    {
        CheckIfPositionWithinMap(position);
        if (_fields.TryGetValue(position, out var mappables))
        {
            mappables.Remove(mappable);
            if (_fields[position].Count == 0) _fields.Remove(position);
        }
    }
    public override List<IMappable>? At(Point position)
    {
        CheckIfPositionWithinMap(position);
        return _fields.TryGetValue(position, out var mappables) ? mappables : null;
    }
    public override List<IMappable>? At(int x, int y) => At(new Point(x, y));
    private void CheckIfPositionWithinMap(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position is outside of the map");
    }
}