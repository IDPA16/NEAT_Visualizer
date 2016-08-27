using System;
using System.Collections.Generic;

namespace JNF_NEAT_Visualizer.Model
{
  public class Neuron
  {
    public Neuron(IList<Connection> incomingConnections = null)
    {
      IncomingConnections = incomingConnections ?? new List<Connection>();
    }

    [Obsolete("Neurons have no historical marking")]
    public ulong HistoricalMarking { get; set; }

    public IList<Connection> IncomingConnections { get; }

    /// <summary>
    /// Gets or sets the layer.
    /// </summary>
    /// <value>Layer, inputs neurons (and bias) have 0, outputs the highest layer</value>
    public uint Layer { get; set; }
  }

}

