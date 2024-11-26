namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;


    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    public abstract int Power { get; }
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public abstract string Info { get; }
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public Creature() { }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (level < 10) { level++; }
    }

    public string Go(Direction direction) => $"{Name} goes {direction.ToString().ToLower()}.";

    public string[] Go(Direction[] directions)
    {
        var results = new string[directions.Length];
        for (int i =0; i < directions.Length; i++)
        {
            results[i] = Go(directions[i]);
        }
        return results;
    }
    public string[] Go(string directionSeq) =>
        Go(DirectionParser.Parse(directionSeq));

}