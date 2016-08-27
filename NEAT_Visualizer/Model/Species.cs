using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class Species
  {
    public IList<NeuralNetwork> Networks { get; } = new List<NeuralNetwork>();
  }
}