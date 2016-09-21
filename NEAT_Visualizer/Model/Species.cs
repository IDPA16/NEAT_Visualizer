using System.Collections.Generic;
using System.Linq;

namespace NEAT_Visualizer.Model
{
  public class Species
  {
    public Species(IList<NeuralNetwork> networks, int numberOfStagnantGenerations)
    {
      NumberOfStagnantGenerations = numberOfStagnantGenerations;
      Networks = networks;
    }

    public Species() : this(new List<NeuralNetwork>(), 0) { }

    public IList<NeuralNetwork> Networks { get; }

    public float FitnessHighscore => Networks.Select(n => n.Fitness).Max();

    public int NumberOfStagnantGenerations { get; set; }
  }
}