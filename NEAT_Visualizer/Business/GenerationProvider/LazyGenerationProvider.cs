using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  /// <summary>
  /// Loads the content of the generations when they are accessed.
  /// </summary>
  public class LazyGenerationProvider : IGenerationProvider
  {
    public Generation GetGeneration(int index)
    {
      throw new NotImplementedException();
    }

    public IList<GenerationInformation> GetGenerations()
    {
      throw new NotImplementedException();
    }
  }
}
