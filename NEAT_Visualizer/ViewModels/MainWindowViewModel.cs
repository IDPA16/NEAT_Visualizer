using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia;
using NEAT_Visualizer.Business;
using NEAT_Visualizer.Interaction.Commands;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels.Dialogs;
using PropertyChanged;

namespace NEAT_Visualizer.ViewModels
{
  [ImplementPropertyChanged]
  public class MainWindowViewModel
  {
    private readonly IVisualizerBusiness business;

    //private const char DELIMITER = '\t';
    #region ctors and initializers
    public MainWindowViewModel(IVisualizerBusiness business)
    {
      this.business = business;
      InitCommands();
    }

    private void InitCommands()
    {
      OpenFileCommand = new DelegateCommand(OnOpenFile);
      OpenFolderCommand = new DelegateCommand(OnOpenFolder);
      CloseCommand = new DelegateCommand(OnClose);
    }
    #endregion

    #region InteractionRequests
    public static InteractionRequest ShowInfoInteractionRequest { get; } = InteractionRequest.Register();

    public static InteractionRequest OpenFileDialogInteractionRequest { get; } = InteractionRequest.Register();
    #endregion

    #region Commands
    public ICommand OpenFileCommand { get; private set; }

    public ICommand OpenFolderCommand { get; private set; }

    public ICommand CloseCommand { get; private set; }
    #endregion

    #region Properties
    public int SelectedGeneration { get; set; }
    // ReSharper disable once UnusedMember.Local
    private void OnSelectedGenerationChanged()
    {
      SelectedSpecies = 0;
      SelectedNetwork = 0;
    }

    public int SelectedSpecies { get; set; }
    // ReSharper disable once UnusedMember.Local
    private void OnSelectedSpeciesChanged()
    {
      SelectedNetwork = 0;
    }

    public int SelectedNetwork { get; set; }

    public ObservableCollection<string> Generations { get; set; } = new ObservableCollection<string>() { " 1\t32", " 2\t110", " 3\t110" };

    public ObservableCollection<string> Species { get; set; } = new ObservableCollection<string>() { " 1\t110", " 2\t80" };

    public ObservableCollection<string> Networks { get; set; } = new ObservableCollection<string>() { " 1\t80", " 2\t80" };
    #endregion

    #region CommandHandlers
    private void OnOpenFile()
    {
      var viewModel = new OpenFileDialogViewModel();
      var interaction = new UserInteraction()
      {
        Title = "Select generation file",
        Content = viewModel,
        UserInteractionOptions = UserInteractionOptions.Ok | UserInteractionOptions.Cancel
      };

      OpenFileDialogInteractionRequest.Raise(interaction);

      if (interaction.UserInteractionResult == UserInteractionOptions.Ok)
      {
        business.NetworkLoader.LoadGeneration(viewModel.SelectedFile);
      }
    }

    private void OnOpenFolder()
    {

    }

    private void OnClose()
    {
      Application.Current.Exit();
    }
    #endregion
  }
}