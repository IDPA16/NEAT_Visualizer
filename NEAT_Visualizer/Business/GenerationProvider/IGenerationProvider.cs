using System.Collections.Generic;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public interface IGenerationProvider
  {
    IEnumerable<GenerationMetadata> GetGenerations();

    Generation GetGeneration(int index);

    int GenerationCount { get; }
  }
}