using Simulator;
using Simulator.Maps;
using System.ComponentModel;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        for (int i = 0; i < _simulation.Moves.Length; i++)
        {
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName.ToString(),
                Symbols = _simulation.Mappables.GroupBy(mappable => mappable.Position).ToDictionary(
                    group => group.Key,
                    group => group.Count() > 1 ? 'X' : group.First().Symbol
                    )
            });

            _simulation.Turn();
        }
    }

    
    public class SimulationTurnLog
    {
        
        public required string Mappable { get; init; }
        
        public required string Move { get; init; }
        
        public required Dictionary<Point, char> Symbols { get; init; }
    }
}