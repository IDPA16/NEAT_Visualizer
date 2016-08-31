using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public interface INetworkLoader
  {
    NeuralNetwork GetNetwork(string json);
  }
}