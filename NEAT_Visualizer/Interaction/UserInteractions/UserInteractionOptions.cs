using System;

namespace NEAT_Visualizer.Interaction.UserInteractions
{
  [Flags]
  public enum UserInteractionOptions
  {
    Yes = 0x01,
    Ok = 0x02,
    No = 0x04,
    Cancel = 0x08
  }
}