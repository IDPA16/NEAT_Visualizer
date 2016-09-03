using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels;

namespace NEAT_Visualizer
{
  /// <summary>
  /// initializes and connects dependencies of the application
  /// </summary>
  public class Bootstrapper
  {
    private IInteractionProvider interactionProvider;

    public void InitializeApplication()
    {
      interactionProvider = new InteractionProvider();
      InteractionRequest.InteractionRequestAdded += InteractionRequest_InteractionRequestAdded;
    }

    private void InteractionRequest_InteractionRequestAdded(object sender, InteractionRequestAddedEventArgs e)
    {
      interactionProvider.RegisterInteraction(e.AddedInteraction);
    }
  }
}