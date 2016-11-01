using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public int MaxLoadedGenerations { get; set; } = 10;

    //private readonly List<FileInfo> generationFiles;
    private readonly IEnumerable<GenerationMetadata> metadata;
    private readonly List<LazyCache<Generation>> generations = new List<LazyCache<Generation>>();

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
        generations.Add(new LazyCache<Generation>(() => loader.LoadGeneration(file)));
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
      // delete internal references to make sure when the generation is not used anymore,
      // it can be removed by the GC.
      var loadedGenerations = generations.Where(x => x.IsLoaded).ToList();
      if (loadedGenerations.Count > MaxLoadedGenerations)
      {
        loadedGenerations.ForEach(x => x.ResetCache());
        //Task.Run(() => GC.Collect()); // not required, because the GC will do it himself and it
        // will be slowing down the application less.
      }

      return generations[index].Value;
    }

    /// <summary> Returns the metadata </summary>
    /// <returns>Gets the information about the available generations</returns>
    public IEnumerable<GenerationMetadata> GetGenerations()
    {
      return metadata;
    }

    public int GenerationCount => generations.Count;
  }
}
