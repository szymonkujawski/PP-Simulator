﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    Point Position { get; }
    char Symbol { get; }
    void Go(Direction direction);
    void MapAndPosition(Map map, Point point);
}
