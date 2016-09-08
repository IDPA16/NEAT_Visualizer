using Avalonia.Controls;
using NEAT_Visualizer.Business;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels;
using NEAT_Visualizer.Views;

namespace NEAT_Visualizer
{
  /// <summary>
  /// initializes and connects dependencies of the application
  /// </summary>
  public class Bootstrapper
  {
    private IInteractionProvider interactionProvider;

    private IVisualizerBusiness business;

    public Window StartupWindow { get; private set; }

    /// <summary>
    /// Instantiates the main window and all services.
    /// By the point this is called, all rendering subsystems have to be defined.
    /// </summary>
    public void InitializeApplication()
    {
      IGenerationLoader loader = new GenerationLoader();
      business = new VisualizerBusiness(loader);

      interactionProvider = new InteractionProvider();
      InteractionRequest.InteractionRequestAdded += InteractionRequest_InteractionRequestAdded;
      StartupWindow = new MainWindow(new MainWindowViewModel(business));
    }

    private void InteractionRequest_InteractionRequestAdded(object sender, InteractionRequestAddedEventArgs e)
    {
      interactionProvider.RegisterInteraction(e.AddedInteraction);
    }
  }
}