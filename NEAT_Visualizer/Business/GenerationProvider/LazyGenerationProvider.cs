using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  /// <summary>
  /// Loads the content of the generations when they are accessed.
  /// </summary>
  public class LazyGenerationProvider : IGenerationProvider
  {

    private readonly List<FileInfo> generationFiles;
    private readonly List<GenerationMetadata> metadata;
    private readonly IGenerationLoader loader;

    public LazyGenerationProvider(Dictionary<GenerationMetadata, FileInfo> generationFiles, IGenerationLoader loader)
    {
      this.generationFiles = generationFiles.Values.ToList();
      this.metadata = generationFiles.Keys.ToList();
      this.loader = loader;
    }

    public Generation GetGeneration(int index)
    {
      return loader.LoadGeneration(generationFiles[index]);
    }

    public IList<GenerationMetadata> GetGenerations()
    {
      return metadata;
    }
  }
}
