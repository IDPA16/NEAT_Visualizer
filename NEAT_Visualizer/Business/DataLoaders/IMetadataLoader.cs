using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Business.GenerationProvider;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public interface IMetatdataLoader
  {
    IList<GenerationMetadata> LoadMetadata(FileInfo fileName);
  }
}
