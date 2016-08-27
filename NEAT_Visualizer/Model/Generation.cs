using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class Generation
  {
    public IList<Species> Species { get; set; } = new List<Species>();
  }
}