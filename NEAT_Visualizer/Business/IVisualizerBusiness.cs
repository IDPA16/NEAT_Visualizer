using System.Collections.Generic;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business
{
  public interface IVisualizerBusiness
  {
    IGenerationLoader NetworkLoader { get; }

    IList<Generation> Generations { get; }
  }
}