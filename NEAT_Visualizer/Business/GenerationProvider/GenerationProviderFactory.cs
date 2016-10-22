using System.Collections.Generic;
using System.IO;
using System.Linq;
using NEAT_Visualizer.Business.DataLoaders;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public class GenerationProviderFactory
  {
    public static string MetadataFileName = "meta.json";

    public static IGenerationProvider Get(FileInfo file, IGenerationLoader loader)
    {
      return new GenerationProvider(new[] { file }.ToList(), loader);
    }

    public static IGenerationProvider Get(DirectoryInfo directory, IGenerationLoader loader)
    {
      var files = directory.GetFiles();

      if (files.Count(file => file.Name == MetadataFileName) == 1)
      {
        var metatdataLoader = new MetatdataLoader();
        var metadata = metatdataLoader.LoadMetadata(files.Single(file => file.Name == MetadataFileName));
        var generationInfo = new Dictionary<GenerationMetadata, FileInfo>(capacity: files.Length - 1);
        var generationFiles = files.Where(file => file.Name != MetadataFileName).ToList();

        for (int i = 0; i < files.Length - 1; i++)
        {
          generationInfo.Add(metadata[i], generationFiles[i]);
        }

        return new LazyGenerationProvider(generationInfo, loader);
      }

      return new GenerationProvider(files.ToList(), loader);
    }

    public static IGenerationProvider GetEmptyGenerationProvider() => new EmptyGenerationProvider();
  }
}