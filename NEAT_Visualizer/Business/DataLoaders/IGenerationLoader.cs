using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public interface IGenerationLoader
  {
    Generation LoadGeneration(FileInfo fileName);

    List<Generation> LoadAllGenerations(DirectoryInfo directory);
  }
}