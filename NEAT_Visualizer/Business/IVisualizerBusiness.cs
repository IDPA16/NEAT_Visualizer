using NEAT_Visualizer.Business.DataHandling;

namespace NEAT_Visualizer.Business
{
  public interface IVisualizerBusiness
  {
    INetworkLoader NetworkLoader { get; }
  }
}