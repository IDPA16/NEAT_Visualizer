using System;
using System.Collections.Generic;
using System.IO;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public class GenerationProviderFactory
  {
    public static IGenerationProvider Get(FileInfo file)
    {
      throw new NotImplementedException();
    }

    public static IGenerationProvider Get(DirectoryInfo directory)
    {
      throw new NotImplementedException();
    }
  }
}