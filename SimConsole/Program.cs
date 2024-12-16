using Simulator.Maps;
using Simulator;
using System.Text;
namespace SimConsole;
internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SmallSquareMap squareMap = new(5);
        SmallTorusMap torusMap = new(8, 6);
        BigBounceMap bounceMap = new(8, 6);
        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 3 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 2, CanFly = false }
        };
        List<Point> points = new()
        {
            new Point(1, 1),
            new Point(2, 3),
            new Point(5, 5),
            new Point(4, 4),
            new Point(0, 0)
        };
        string moves = "udlrduuuulllllllllll";
        Simulation simulation = new Simulation(bounceMap, creatures, points, moves);
       
        SimulationHistory simulationHistory = new(simulation);

        for (int i = 0; i < simulation.Moves.Length; i++)
        {
            Console.WriteLine($"Turn: {i + 1}\n");
            Console.WriteLine(simulationHistory.TurnLogs[i].Mappable);
            Console.WriteLine(simulationHistory.TurnLogs[i].Move);
            foreach (KeyValuePair<Point, char> kvp in simulationHistory.TurnLogs[i].Symbols)
            {
                Console.WriteLine($"Postition: {kvp.Key}, Symbol: {kvp.Value}");
            }
            Console.WriteLine("\n");
        }
    }
}