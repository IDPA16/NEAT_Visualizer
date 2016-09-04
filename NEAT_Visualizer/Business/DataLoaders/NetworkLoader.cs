using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public class NetworkLoader : INetworkLoader
  {
    private class JsonRepresentation
    {
      //here comes the native json representation to make deserializing easier
    }

    public NeuralNetwork GetNetwork(FileInfo fileName)
    {
      throw new System.NotImplementedException();
    }

    public Species LoadSpecies(DirectoryInfo directory)
    {
      throw new System.NotImplementedException();
    }

    public List<Species> LoadFullNeatData(DirectoryInfo rootDirectory)
    {
      throw new System.NotImplementedException();
    }
  }
}