using System;

namespace NEAT_Visualizer.Interaction.UserInteractions
{
  [Flags]
  public enum UserInteractionOptions
  {
    Yes = 0x01,
    No = 0x02,
    Cancel = 0x04,
    OkCancel = Yes | Cancel,
    YesNoCancel = Yes | No | Cancel
  }
}