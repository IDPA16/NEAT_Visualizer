using System;

namespace NEAT_Visualizer.Interaction.UserInteractions
{
  public class UserInteractionRequestedEventArgs
  {
    /// <summary>Gets the context for a requested interaction.</summary>
    public IUserInteraction Context { get; private set; }

    /// <summary>
    /// Gets the callback to execute when an interaction is completed.
    /// </summary>
    public Action Callback { get; private set; }

    public UserInteractionRequestedEventArgs(IUserInteraction context, Action callback)
    {
      this.Context = context;
      this.Callback = callback;
    }

  }
}