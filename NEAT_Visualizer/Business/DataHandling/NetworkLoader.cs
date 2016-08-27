using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataHandling
{
  public class NetworkLoader : INetworkLoader
  {
    public NeuralNetwork LoadNetwork(FileInfo jsonFile)
    {
      throw new System.NotImplementedException();
    }

    public Species LoadSpecies(DirectoryInfo directory)
    {
      throw new System.NotImplementedException();
    }

    /// <summary>
    /// loads all provided species from the root directory.
    /// </summary>
    /// <param name="rootDirectory">the directory with multiple directories of species</param>
    /// <returns></returns>
    public List<Species> LoadFullNeatData(DirectoryInfo rootDirectory)
    {
      throw new System.NotImplementedException();
    }
  }
}