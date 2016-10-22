namespace NEAT_Visualizer.Business.GenerationProvider
{
  public struct GenerationMetadata
  {
    public GenerationMetadata(int generationNumber, float highestFitness)
    {
      GenerationNumber = generationNumber;
      HighestFitness = highestFitness;
    }

    public int GenerationNumber { get; set; }

    public float HighestFitness { get; set; }
  }
}
