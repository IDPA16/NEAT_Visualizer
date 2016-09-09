using System.Collections.Generic;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business
{
  public class VisualizerBusiness : IVisualizerBusiness
  {
    public VisualizerBusiness(IGenerationLoader networkLoader)
    {
      NetworkLoader = networkLoader;
    }

    public IGenerationLoader NetworkLoader { get; }

    public IList<Generation> Generations { get; } = new List<Generation>();
  }
}