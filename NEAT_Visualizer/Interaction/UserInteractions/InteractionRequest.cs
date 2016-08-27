using System;

namespace NEAT_Visualizer.Interaction.UserInteractions
{
  // Adapted from Prism.IInteractionRequest and its implementation InteractionRequest<T>
  public class InteractionRequest
  {
    /// <summary>Fired when interaction is needed.</summary>
    public event EventHandler<UserInteractionRequestedEventArgs> Raised;
    //public event EventHandler<UserInteractionRequestedEventArgs> Raised;

    /// <summary>Fires the Raised event.</summary>
    /// <param name="context">The context for the interaction request.</param>
    public void Raise(IUserInteraction context)
    {
      Raise(context, i => { });
    }

    /// <summary>Fires the Raised event.</summary>
    /// <param name="context">The context for the interaction request.</param>
    /// <param name="callback">The callback to execute when the interaction is completed.</param>
    public void Raise(IUserInteraction context, Action<IUserInteraction> callback)
    {
      EventHandler<UserInteractionRequestedEventArgs> eventHandler = Raised;
      eventHandler?.Invoke(this, new UserInteractionRequestedEventArgs(context, () =>
      {
        callback?.Invoke(context);
      }));
    }
  }
}