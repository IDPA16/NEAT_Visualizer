using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class Generation
  {
    public Generation() : this(0, 0, new List<Species>()) { }

    public Generation(int generationsPassed, int populationSize, IList<Species> species)
    {
      GenerationsPassed = generationsPassed;
      PopulationSize = populationSize;
      Species = species;
    }

    public int PopulationSize { get; set; }

    public int GenerationsPassed { get; set; }

    public IList<Species> Species { get; set; }
  }
}