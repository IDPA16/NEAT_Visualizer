using System;
using System.Linq;
using NEAT_Visualizer.Business.DataLoaders;
using Xunit;

namespace NEAT_Visualizer.BusinessTest
{
  public class DataLoadingTest : IClassFixture<GenerationLoader>
  {
    private GenerationLoader loader;

    public DataLoadingTest(GenerationLoader aLoader)
    {
      loader = aLoader;
    }

    [Fact]
    public void CanLoadJsonFileWithoutError()
    {
    }

    [Fact]
    public void LoadsAllJsonDataIntoModel()
    {   
    }
  }
}
