﻿namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        List<Direction> directions = new();

        foreach (char dir in input.ToUpper())
        {
            switch (dir)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
            }
        }

        return directions.ToArray();
    }

}