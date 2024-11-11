using System.Drawing;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Starting Simulator!\n");
        //Lab4a();
        //Creature c = new Elf("Elandor", 5, 3);
        //Console.WriteLine(c);  // ELF: Elandor [5]
        //Lab4b();
        Lab5a();

    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
        };

        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

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
}