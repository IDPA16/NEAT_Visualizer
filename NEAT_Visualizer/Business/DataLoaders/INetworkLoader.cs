using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public interface INetworkLoader
  {
    NeuralNetwork GetNetwork(FileInfo fileName);

    Species LoadSpecies(DirectoryInfo directory);

    List<Species> LoadFullNeatData(DirectoryInfo rootDirectory);
  }
}