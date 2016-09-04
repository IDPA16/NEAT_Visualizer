using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public interface INetworkLoader
  {
    Generation LoadGeneration(FileInfo fileName);

    List<Generation> LoadAllGenerations(DirectoryInfo directory);
  }
}