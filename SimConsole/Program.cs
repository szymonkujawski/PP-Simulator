﻿using Simulator.Maps;
using Simulator;
using System.Text;
namespace SimConsole;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";
        //List<Point> points = [new(3, 3), new(3, 2)];
        //string moves = "ldulrld";
        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        //start of simulation
        Console.WriteLine("SIMULATION!");
        Console.WriteLine();
        Console.WriteLine("Starting positions:");
        mapVisualizer.Draw();
        var turn = 1;
        while (!simulation.Finished)
        {

            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            Console.WriteLine($"Turn {turn}");

            Console.WriteLine($"{simulation.CurrentMappable} moves {simulation.CurrentMoveName}");

            if (key.Key == ConsoleKey.Spacebar)
            {
                simulation.Turn();
                mapVisualizer.Draw();
                turn++;
            }
        }
    }
}