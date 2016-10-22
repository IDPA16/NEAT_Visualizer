using System.Collections.Generic;
using System.IO;
using System.Linq;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public class GenerationProvider : IGenerationProvider
  {
    private readonly List<Generation> generations;

    public GenerationProvider(List<FileInfo> files, IGenerationLoader loader)
    {
      generations = files.Select(loader.LoadGeneration).ToList();
    }

    public GenerationProvider(DirectoryInfo directory, IGenerationLoader loader)
    {
      generations = loader.LoadAllGenerations(directory);
    }

    public Generation GetGeneration(int index)
    {
      return generations[index];
    }

    public IEnumerable<GenerationMetadata> GetGenerations()
    {
      return generations.Select(g => g.ToMetadata());
    }
  }

  public static class GenerationExtensions
  {
    public static GenerationMetadata ToMetadata(this Generation generation)
    {
      return new GenerationMetadata(generation.GenerationsPassed, generation.FitnessHighscore);
    }
  }
}
