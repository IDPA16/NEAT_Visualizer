using NEAT_Visualizer.Business.DataLoaders;

namespace NEAT_Visualizer.Business
{
  public class VisualizerBusiness : IVisualizerBusiness
  {
    public VisualizerBusiness(IGenerationLoader networkLoader)
    {
      GenerationLoader = networkLoader;
    }

    public IGenerationLoader GenerationLoader { get; }
  }
}