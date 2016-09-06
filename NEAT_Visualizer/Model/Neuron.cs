using System;
using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class Neuron
  {
    public Neuron(IList<Connection> incomingConnections) { IncomingConnections = incomingConnections; }

    public Neuron() : this(new List<Connection>()) { }

    public IList<Connection> IncomingConnections { get; }

    /// <summary>
    /// Gets or sets the layer.
    /// </summary>
    /// <value>Layer, inputs neurons (and bias) have 0, outputs the highest layer</value>
    public int Layer { get; set; }
  }
}

