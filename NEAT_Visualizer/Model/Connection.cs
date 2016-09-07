namespace NEAT_Visualizer.Model
{
  public class Connection
  {
    public Connection(Neuron neuron, float weight, int historicalMarking = 0)
    {
      Neuron = neuron;
      Weight = weight;
      HistoricalMarking = historicalMarking;
    }

    public Neuron Neuron { get; }

    public float Weight { get; }

    public int HistoricalMarking { get; }

    public override string ToString()
    {
      return $"[IncomingConnection: Neuron={Neuron}, Weight={Weight}]";
    }
  }
}

