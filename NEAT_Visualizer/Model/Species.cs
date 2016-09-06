using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class Species
  {
    public Species(IList<NeuralNetwork> networks, float fitnessHighscore, int numberOfStagnantGenerations)
    {
      FitnessHighscore = fitnessHighscore;
      NumberOfStagnantGenerations = numberOfStagnantGenerations;
      Networks = networks;
    }

    public Species() : this(new List<NeuralNetwork>(), 0, 0) { }

    public IList<NeuralNetwork> Networks { get; }

    public float FitnessHighscore { get; set; }

    public int NumberOfStagnantGenerations { get; set; }
  }
}