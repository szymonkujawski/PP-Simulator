﻿using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; protected set; }
    public virtual char Symbol => 'A';
    private string _description = "Unknown";
    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("Animal cannot move since they are not on the map!");

        var newPosition = GetNewPosition(direction);

        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public virtual void MapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException("This animal is already on a map.");
        if (!map.Exist(point)) throw new ArgumentException("This position does not exist on this map.");

        Map = map;
        Position = point;
        map.Add(this, point);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }
}