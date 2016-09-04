using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class Generation
  {
    public Generation(uint generationsPassed, uint generationSize, IList<Species> species)
    {
      GenerationsPassed = generationsPassed;
      GenerationSize = generationSize;
      Species = species;
    }

    public uint GenerationSize { get; set; }

    public uint GenerationsPassed { get; set; }

    public IList<Species> Species { get; set; }
  }
}