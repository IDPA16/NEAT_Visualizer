using System.Linq;
using Avalonia.Controls;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels.Dialogs;
using NEAT_Visualizer.Views.Dialogs;

namespace NEAT_Visualizer.Interaction.Services
{
  public class InteractionProvider : IInteractionProvider
  {
    /// registeres an interaction. the requests raise event will be handled appropriately
    public void RegisterInteraction(InteractionRequest request)
    {
      request.Raised += DisplayInteraction;
    }

    private async void DisplayInteraction(object sender, UserInteractionRequestedEventArgs e)
    {
      var openFileDialogViewModel = e.Context.Content as OpenFileDialogViewModel;
      var openFolderDialogViewModel = e.Context.Content as OpenFolderDialogViewModel;

      if (openFileDialogViewModel != null)
      {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.AllowMultiple = false;
        string[] result = await dialog.ShowAsync();
        dialog.Title = e.Context.Title;
        e.Context.UserInteractionResult = result.ToList().Count == 1
          ? UserInteractionOptions.Ok
          : UserInteractionOptions.Cancel;

        openFileDialogViewModel.SelectedFile = new System.IO.FileInfo(result.SingleOrDefault() ?? "");
      }
      else if (openFolderDialogViewModel != null)
      {

      }
      else
      {
        new DialogWindow(e.Context).Show();
      }

      e.Callback.Invoke();
    }

  }
}