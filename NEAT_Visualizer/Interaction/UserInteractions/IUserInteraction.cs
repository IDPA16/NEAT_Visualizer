namespace NEAT_Visualizer.Interaction.UserInteractions
{
  public interface IUserInteraction
  {
    string Title { get; set; }

    object Content { get; set; }

    UserInteractionOptions UserInteractionOptions { get; set; }

    UserInteractionOptions UserInteractionResult { get; set; }
  }
}