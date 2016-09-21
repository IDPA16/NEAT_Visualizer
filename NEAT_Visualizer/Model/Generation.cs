using System.Collections.Generic;
using System.Linq;

namespace NEAT_Visualizer.Model
{
  public class Generation
  {
    public Generation() : this(0, 0, new List<Species>(), 0) { }

    public Generation(int generationsPassed, int populationSize, IList<Species> species, float fitnessHighscore)
    {
      GenerationsPassed = generationsPassed;
      PopulationSize = populationSize;
      Species = species;
      FitnessHighscore = fitnessHighscore;
    }

    public int PopulationSize { get; set; }

    public int GenerationsPassed { get; set; }

    public IList<Species> Species { get; set; }

    public float FitnessHighscore { get; set; }
    //public float FitnessHighscore => Species.Select(n => n.FitnessHighscore).Max();
  }
}