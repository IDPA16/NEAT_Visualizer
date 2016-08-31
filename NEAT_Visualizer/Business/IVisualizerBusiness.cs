using NEAT_Visualizer.Business.DataLoaders;

namespace NEAT_Visualizer.Business
{
  public interface IVisualizerBusiness
  {
    INetworkLoader NetworkLoader { get; }
  }
}