using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEAT_Visualizer.Business.GenerationProvider
{
  public struct GenerationMetadata
  {
    public GenerationMetadata(int generationNumber, decimal highestFitness)
    {
      GenerationNumber = generationNumber;
      HighestFitness = highestFitness;
    }

    public int GenerationNumber { get; set; }

    public decimal HighestFitness { get; set; }
  }
}
