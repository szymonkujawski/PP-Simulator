using Simulator.Maps;
using System.Drawing;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {

        Lab7();

    }

    static void Lab7()
    {
        //Elf on square map
        var squareMap = new SmallSquareMap(5);
        var elf = new Elf("Elf", 3, 2);
        Console.WriteLine(elf.Greeting());

        elf.MapAndPosition(squareMap, new Point(0, 0));

        Console.WriteLine($"Elf's position on square map: {elf.Position}");

        Console.WriteLine(elf.Go(Direction.Up));
        Console.WriteLine(elf.Go(Direction.Right));

        Console.WriteLine($"Elf's new position after all moves on square map: {elf.Position}");

        var squareMapPositionCreatures = squareMap.At(0, 0);
        Console.WriteLine($"Number of creatures located at point (0, 0) on square map: {squareMapPositionCreatures?.Count ?? 0}");

        var squareMapPositionCreatures2 = squareMap.At(1, 1);
        Console.WriteLine($"Number of creatures located at point (1, 1) on square map: {squareMapPositionCreatures2?.Count ?? 0}");

        var squareMapPositionCreatures3 = squareMap.At(1, 0);
        Console.WriteLine($"Number of creatures located at point (1, 1) on square map: {squareMapPositionCreatures3?.Count ?? 0}");


        Console.WriteLine();
        Console.WriteLine();

        //Orc on torus map
        var torusMap = new SmallTorusMap(5, 5);
        var orc = new Orc("Orc", 2, 2);
        Console.WriteLine(orc.Greeting());

        orc.MapAndPosition(torusMap, new Point(3, 3));

        Console.WriteLine($"Orc's position on torus map: {orc.Position}");

        Console.WriteLine(orc.Go(Direction.Left));
        Console.WriteLine(orc.Go(Direction.Down));
        Console.WriteLine(orc.Go(Direction.Up));
        Console.WriteLine(orc.Go(Direction.Up));

        Console.WriteLine($"Orc's new position after all moves on torus map: {orc.Position}");
        var torusMapPositionCreatures = torusMap.At(3, 3);
        Console.WriteLine($"Number of creatures located at point (3, 3) on torus map: {torusMapPositionCreatures?.Count ?? 0}");

        var torusMapPositionCreatures2 = torusMap.At(2, 2);
        Console.WriteLine($"Number of creatures located at point (2, 2) on torus map: {torusMapPositionCreatures2?.Count ?? 0}");

        var torusMapPositionCreatures3 = torusMap.At(2, 4);
        Console.WriteLine($"Number of creatures located at point (2, 4) on torus map: {torusMapPositionCreatures3?.Count ?? 0}");
    }

}