using System;

namespace NEAT_Visualizer.Interaction.UserInteractions
{
  public class InteractionRequestAddedEventArgs : EventArgs
  {
    public InteractionRequestAddedEventArgs(InteractionRequest addedInteraction)
    {
      AddedInteraction = addedInteraction;
    }

    public InteractionRequest AddedInteraction { get; }
  }
}