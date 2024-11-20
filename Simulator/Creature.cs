using System.ComponentModel.DataAnnotations;
using Simulator.Maps;
namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void initMapAndPosition(Map map, Point position)



    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }
    public abstract int Power
    {
        get;
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10) { level++; }
    }
    public string Go(Direction direction)
    {
        var size = direction.Length;
        return $"{direction.ToString().ToLower()}";
    }

    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];
        for (int i =0; i<directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }
    public string[] Go(string directionSeq) =>
        Go(DirectionParser.Parse(directionSeq));
    
}