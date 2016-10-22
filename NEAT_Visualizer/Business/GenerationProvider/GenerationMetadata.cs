namespace NEAT_Visualizer.Business.GenerationProvider
{
  public struct GenerationMetadata
  {
    public GenerationMetadata(int generationNumber, float fitnessHighscore)
    {
      GenerationNumber = generationNumber;
      FitnessHighscore = fitnessHighscore;
    }

    public int GenerationNumber { get; set; }

    public float FitnessHighscore { get; set; }
  }
}