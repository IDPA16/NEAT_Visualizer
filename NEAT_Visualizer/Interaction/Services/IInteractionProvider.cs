using NEAT_Visualizer.Interaction.UserInteractions;

namespace NEAT_Visualizer.Interaction.Services
{
  public interface IInteractionProvider
  {
    void RegisterInteraction(InteractionRequest request);
  }
}