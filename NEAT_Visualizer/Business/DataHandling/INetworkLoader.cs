using System.Collections.Generic;
using NEAT_Visualizer.Model;
using System.IO;

namespace NEAT_Visualizer.Business.DataLoading
{
  public interface INetworkLoader
  {
    NeuralNetwork LoadNetwork(FileInfo jsonFile);

    Species LoadSpecies(DirectoryInfo directory);

    List<Species> LoadFullNeatData(DirectoryInfo rootDirectory);
  }
}