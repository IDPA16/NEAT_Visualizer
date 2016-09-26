using System.Collections.Generic;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public interface IGenerationProvider
  {
    IList<GenerationMetadata> GetGenerations();

    Generation GetGeneration(int index);
  }
}