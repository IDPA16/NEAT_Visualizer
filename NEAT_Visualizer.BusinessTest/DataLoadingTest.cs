using System;
using System.IO;
using System.Linq;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Model;
using Xunit;

namespace NEAT_Visualizer.BusinessTest
{
  public class DataLoadingTest : IClassFixture<GenerationLoader>
  {
    private readonly GenerationLoader loader;

    private const string JSON_DIR = @"../../../JsonExamples/";

    public DataLoadingTest(GenerationLoader aLoader)
    {
      loader = aLoader;
    }

    [Theory]
    [InlineData(JSON_DIR + "generation_1.json")]
    [InlineData(JSON_DIR + "generation_5.json")]
    [InlineData(JSON_DIR + "generation_9.json")]
    [InlineData(JSON_DIR + "generation_60.json")]
    public void CanLoadJsonFileWithoutError(string relativeJsonPath)
    {
      // Act
      Generation generation = loader.LoadGeneration(new FileInfo(Path.GetFullPath(relativeJsonPath)));

      // Assert
      Assert.NotNull(generation);
    }

    [Theory]
    //[InlineData(JSON_DIR + "generation_1.json")]
    //[InlineData(JSON_DIR + "generation_5.json")]
    //[InlineData(JSON_DIR + "generation_9.json")]
    // Content correctness test only set up for this generation file.
    [InlineData(JSON_DIR + "generation_60.json")] 
    public void LoadsAllJsonDataIntoModel(string relativeJsonPath)
    {
      // Act
      Generation generation = loader.LoadGeneration(new FileInfo(Path.GetFullPath(relativeJsonPath)));

      // Assert (that most stuff is correct...)
      Assert.Equal(50, generation.PopulationSize);
      Assert.Equal(9f, generation.FitnessHighscore);
      Assert.Equal(3, generation.Species.Last().Networks.Last().Neurons.Last().Layer);
      Assert.Equal(4, generation.Species.ToList()[5].Networks.ToList()[2].Fitness);
    }
  }
}
