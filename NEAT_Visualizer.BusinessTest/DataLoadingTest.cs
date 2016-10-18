using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Business.GenerationProvider;
using NEAT_Visualizer.Model;
using Xunit;

namespace NEAT_Visualizer.BusinessTest
{
  public class DataLoadingTest : IClassFixture<GenerationLoader>, IClassFixture<MetatdataLoader>
  {
    private readonly GenerationLoader generationLoader;

    private readonly MetatdataLoader metatdataLoader;

    private const string JSON_DIR = @"../../../JsonExamples/";

    public DataLoadingTest(GenerationLoader generationLoader, MetatdataLoader metatdataLoader)
    {
      this.generationLoader = generationLoader;
      this.metatdataLoader = metatdataLoader;
    }

    [Theory]
    [InlineData(JSON_DIR + "generation_1.json")]
    [InlineData(JSON_DIR + "generation_2.json")]
    [InlineData(JSON_DIR + "generation_3.json")]
    [InlineData(JSON_DIR + "generation_4.json")]
    public void CanLoadJsonFileWithoutError(string relativeJsonPath)
    {
      // Act
      Generation generation = generationLoader.LoadGeneration(new FileInfo(Path.GetFullPath(relativeJsonPath)));

      // Assert
      Assert.NotNull(generation);
    }

    [Theory]
    //[InlineData(JSON_DIR + "generation_1.json")]
    //[InlineData(JSON_DIR + "generation_5.json")]
    //[InlineData(JSON_DIR + "generation_9.json")]
    // Content correctness test only set up for this generation file.
    [InlineData(JSON_DIR + "generation_1.json")] 
    public void LoadsAllJsonDataIntoModel(string relativeJsonPath)
    {
      // Act
      Generation generation = generationLoader.LoadGeneration(new FileInfo(Path.GetFullPath(relativeJsonPath)));

      // Assert (that most stuff is correct...)
      Assert.Equal(150, generation.PopulationSize);
      Assert.Equal(3f, generation.FitnessHighscore);
      Assert.Equal(1, generation.Species.Last().Networks.Last().Neurons.Last().Layer);
      Assert.Equal(2, generation.Species.ToList()[0].Networks.ToList()[2].Fitness);
    }

    [Theory]
    [InlineData(JSON_DIR + "meta.json")]
    public void LoadsMetadataFileCorrectly(string relativeJsonPath)
    {
      // Act
      List<GenerationMetadata> metadata = metatdataLoader.LoadMetadata(new FileInfo(Path.GetFullPath(relativeJsonPath))).ToList();
      Assert.Equal(4, metadata.Count);
      Assert.Equal(3m, metadata.First().HighestFitness);
      Assert.Equal(3m, metadata.Last().HighestFitness);
    }
  }
}
