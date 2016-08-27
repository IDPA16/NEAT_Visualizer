using NEAT_Visualizer.Interaction.UserInteractions;

namespace NEAT_Visualizer.Interaction.Services
{
  public class InteractionProvider : IInteractionProvider
  {
    /// registeres an interaction. the requests raise event will be handled appropriately
    public void RegisterInteraction(InteractionRequest request)
    {
      request.Raised += DisplayInteraction;
    }

    private void DisplayInteraction(object sender, UserInteractionRequestedEventArgs e)
    {
      throw new System.NotImplementedException();
    }

  }
}