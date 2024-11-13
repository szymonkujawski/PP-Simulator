using Simulator.Maps;
using System.Drawing;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {

        Lab5b();

    }

    //static void Lab4a()
    //{
    //    Console.WriteLine("HUNT TEST\n");
    //    var o = new Orc() { Name = "Gorbag", Rage = 7 };
    //    o.SayHi();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        o.Hunt();
    //        o.SayHi();
    //    }

    //    Console.WriteLine("\nSING TEST\n");
    //    var e = new Elf("Legolas", agility: 2);
    //    e.SayHi();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        e.Sing();
    //        e.SayHi();
    //    }

    //    Console.WriteLine("\nPOWER TEST\n");
    //    Creature[] creatures = {
    //    o,
    //    e,
    //    new Orc("Morgash", 3, 8),
    //    new Elf("Elandor", 5, 3)
    //    };

    //    foreach (Creature creature in creatures)
    //    {
    //        Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
    //    }
    //}

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
        };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void Lab5a()
    {
        try
        {
            var rect1 = new Rectangle(5, 6, 2, 2);
            Console.WriteLine(rect1);
            var rect2 = new Rectangle(2, 6, 5, 2);
            Console.WriteLine(rect2);
            try
            {
                var rect3 = new Rectangle(2, 2, 2, 6);
                Console.WriteLine(rect3);
            }
            catch (ArgumentException expectation)
            {
                Console.WriteLine($"{expectation.Message}");
            }
            var p1 = new Point(2, 2);
            var p2 = new Point(5, 6);
            var rect4 = new Rectangle(p1, p2);
            Console.WriteLine(rect4);

            var pointInside = new Point(3, 3);
            var pointOutside = new Point(1, 1);
            var pointOnEdge = new Point(2, 6);
            var pointOnEdge2 = new Point(5, 2);
            Console.WriteLine($"Point {pointInside} inside the rectangle? {rect4.Contains(pointInside)}");
            Console.WriteLine($"Point {pointOutside} inside the rectangle? {rect4.Contains(pointOutside)}");
            Console.WriteLine($"Point {pointOnEdge} inside the rectangle? {rect4.Contains(pointOnEdge)}");
            Console.WriteLine($"Point {pointOnEdge2} inside the rectangle? {rect4.Contains(pointOnEdge2)}");
        }
        catch (Exception expectation)
        {
            Console.WriteLine($"{expectation.Message}");
        }
    }

    public static void Lab5b()
    {
        // Create map with correct size
        try
        {
            SmallSquareMap map = new SmallSquareMap(10);
            Console.WriteLine(map);
        }
        catch (ArgumentOutOfRangeException expectation)
        {
            Console.WriteLine("Error: " + expectation.Message);
        }
        Console.Write("\n");
        // Create map with invalid size
        try
        {
            SmallSquareMap invalidMap = new SmallSquareMap(3);
        }
        catch (ArgumentOutOfRangeException expectation)
        {
            Console.WriteLine("Error: " + expectation.Message);
        }
        Console.Write("\n");
        SmallSquareMap map10 = new SmallSquareMap(9);
        Console.WriteLine(map10);
        Point pointInside = new Point(4, 4);
        Point pointInside2 = new Point(3, 7);
        Point pointOutside = new Point(9, 9);
        Point pointOutside2 = new Point(-14, -2);
        Console.WriteLine($"Point {pointInside} inside map: {map10.Exist(pointInside)}?");
        Console.WriteLine($"Point {pointInside2} inside map: {map10.Exist(pointInside2)}?");
        Console.WriteLine($"Point {pointOutside} inside map: {map10.Exist(pointOutside)}?");
        Console.WriteLine($"Point {pointOutside2} inside map: {map10.Exist(pointOutside2)}?");
        Console.Write("\n");
        

        Point startPoint = new Point(5, 5);
        Console.WriteLine($"Starting point: {startPoint}");
        Console.WriteLine($"Next point after up move {startPoint}: {map10.Next(startPoint, Direction.Up)}");
        Console.WriteLine($"Next point after down move {startPoint}: {map10.Next(startPoint, Direction.Down)}");
        Console.WriteLine($"Next point afrer left move {startPoint}: {map10.Next(startPoint, Direction.Left)}");
        Console.WriteLine($"Next point afrer right move {startPoint}: {map10.Next(startPoint, Direction.Right)}");
        Console.Write("\n");
        

        Point edgePoint = new Point(0, 0);
        Console.WriteLine($"Trying to move out of a map {edgePoint}: ");
        Console.WriteLine($"After move down {map10.Next(edgePoint, Direction.Down)}");
        SmallSquareMap map20 = new SmallSquareMap(20);
        Console.WriteLine(map20);
        Point edgePoint2 = new Point(19, 19);
        Console.WriteLine($"Trying to move out of a map after right move: {edgePoint2}");
        Console.WriteLine($"After move right {map20.Next(edgePoint2, Direction.Right)}");
        Console.Write("\n");
        

        Console.WriteLine($"Next diagonal point after right-up from {startPoint}: {map10.NextDiagonal(startPoint, Direction.Up)}");
        Console.WriteLine($"Next diagonal point after right-down from {startPoint}: {map10.NextDiagonal(startPoint, Direction.Right)}");
        Console.WriteLine($"Next diagonal point after left-down from {startPoint}: {map10.NextDiagonal(startPoint, Direction.Down)}");
        Console.WriteLine($"Next diagonal point after left-up from {startPoint}: {map10.NextDiagonal(startPoint, Direction.Left)}");
    }
}