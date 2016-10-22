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

    //private readonly List<FileInfo> generationFiles;
    private readonly IEnumerable<GenerationMetadata> metadata;
    private List<Lazy<Generation>> generations;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="generationFiles">the generation files that can be loaded, and the metadata of them</param>
    /// <param name="loader">the loader required to load the generation file.</param>
    public LazyGenerationProvider(Dictionary<GenerationMetadata, FileInfo> generationFiles, IGenerationLoader loader)
    {
      metadata = generationFiles.Keys;

      foreach (FileInfo file in generationFiles.Values)
      {
        generations.Add(new Lazy<Generation>(() => loader.LoadGeneration(file)));
      }
    }

    /// <summary>
    /// Get a specific generation. This will load the file and read its content
    /// with the <see cref="loader"/>
    /// </summary>
    /// <param name="index">index of the generation that will be returned</param>
    /// <returns></returns>
    public Generation GetGeneration(int index)
    {
      return generations[index].Value;
    }

    /// <summary> Returns the metadata </summary>
    /// <returns>Gets the information about the available generations</returns>
    public IEnumerable<GenerationMetadata> GetGenerations()
    {
      return metadata;
    }
  }
}
