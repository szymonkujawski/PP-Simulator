namespace Simulator;
internal class Creature
{
    private int level;

    public int Level { get; set; }

    private string? name;

    public string? Name { get; set; }


    public string Info => $"{Name} - [{Level}]";

    public Creature(string name, int level = 1)
    {

        Name = name;
        Level = level;

    }
    public Creature() { }

    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
}