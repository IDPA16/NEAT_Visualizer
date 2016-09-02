using NEAT_Visualizer.Interaction.Services;
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
      RegisterInteractionRequests();
    }

    private void RegisterInteractionRequests()
    {
      interactionProvider.RegisterInteraction(MainWindowViewModel.ShowInfoInteractionRequest);
    }
  }
}