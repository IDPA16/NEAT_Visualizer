using System.IO;

namespace NEAT_Visualizer.ViewModels.Dialogs
{
  public class OpenFileDialogViewModel
  {
    public string FileFilterMask { get; set; } = "Json Files (*.json)|*.json";

    public FileInfo SelectedFile { get; set; }
  }
}