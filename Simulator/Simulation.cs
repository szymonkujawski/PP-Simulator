using Simulator.Maps;
using System.Diagnostics.Metrics;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    private int count = 0;

    private HashSet<char> validMoves = new HashSet<char> { 'u', 'd','l', 'r'};

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get
        {
            int index = count % Creatures.Count;
            return Creatures[index];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            var direction = DirectionParser.Parse(Moves[count % Moves.Length].ToString());

            if (direction.Any())
            {
                return direction[0].ToString().ToLower();
            }
            return string.Empty;
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (positions.Count != creatures.Count || positions == null)
        {
            throw new ArgumentException("Positions count and number of creatures are not the same");
        }
        if (creatures.Count == 0 || creatures == null)
        {
            throw new ArgumentException("Creatures list can't be empty");
        }
        if (string.IsNullOrWhiteSpace(moves))
        {
            throw new ArgumentException("Moves must contain something (cant be empty or null)");
        }
        Map = map ?? throw new ArgumentNullException(nameof(map));

        Moves = ValidateTheMoves(moves);

        Positions = positions;

        Creatures = creatures;


        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].MapAndPosition(map, positions[i]);
        }
    }

    private string ValidateTheMoves(string moves) => new(moves.Where(c => validMoves.Contains(Char.ToLower(c))).ToArray());

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished == true)
        { 
            throw new InvalidOperationException("Simulation is already finished.");
        }
        var direction = DirectionParser.Parse(Moves[count % Moves.Length].ToString())[0];
        CurrentCreature.Go(direction);
        count++;
        if (count >= Moves.Length)
        {
            Finished = true;
        }
    }
}