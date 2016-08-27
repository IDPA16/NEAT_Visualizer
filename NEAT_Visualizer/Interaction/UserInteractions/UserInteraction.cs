namespace NEAT_Visualizer.Interaction.UserInteractions
{
  public class UserInteraction : IUserInteraction
  {
    public string Title { get; set; }
    public object Content { get; set; }
    public UserInteractionOptions UserInteractionOptions { get; set; }
    public UserInteractionOptions UserInteractionResult { get; set; }
  }
}