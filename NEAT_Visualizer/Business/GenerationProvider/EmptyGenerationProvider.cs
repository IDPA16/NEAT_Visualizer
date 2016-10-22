using System;
using System.Collections.Generic;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public class EmptyGenerationProvider : IGenerationProvider
  {
    public IEnumerable<GenerationMetadata> GetGenerations()
    {
      return new List<GenerationMetadata>();
    }

    public Generation GetGeneration(int index)
    {
      throw new ArgumentOutOfRangeException();
    }

    // doesnt have any generations
    public int GenerationCount => 0;
  }
}