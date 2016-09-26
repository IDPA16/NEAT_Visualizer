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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="generationFiles">the generation files that can be loaded, and the metadata of them</param>
    /// <param name="loader">the loader required to load the gneration file.</param>
    public LazyGenerationProvider(Dictionary<GenerationMetadata, FileInfo> generationFiles, IGenerationLoader loader)
    {
      this.generationFiles = generationFiles.Values.ToList();
      this.metadata = generationFiles.Keys.ToList();
      this.loader = loader;
    }

    /// <summary>
    /// Get a specific generation. This will load the file and read its content
    /// with the <see cref="loader"/>
    /// </summary>
    /// <param name="index">index of the generation that will be returned</param>
    /// <returns></returns>
    public Generation GetGeneration(int index)
    {
      return loader.LoadGeneration(generationFiles[index]);
    }

    /// <summary> Returns the metadata </summary>
    /// <returns>Gets the information about the available generations</returns>
    public IList<GenerationMetadata> GetGenerations()
    {
      return metadata;
    }
  }
}
