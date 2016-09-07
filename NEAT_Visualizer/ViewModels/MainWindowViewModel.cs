using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NEAT_Visualizer.Interaction.Commands;
using NEAT_Visualizer.Interaction.UserInteractions;
using PropertyChanged;

namespace NEAT_Visualizer.ViewModels
{
  [ImplementPropertyChanged]
  public class MainWindowViewModel : ViewModelBase
  {
    //private const char DELIMITER = '\t';
    #region backing fields
    private int selectedGeneration = 0;

    private int selectedSpecies = 0;

    //private int selectedNetwork = 0;
    #endregion
    #region ctors and initializers
    public MainWindowViewModel()
    {
      InitCommands();
    }

    private void InitCommands()
    {
      OpenFileCommand = new DelegateCommand(OnOpenFile);
      OpenFolderCommand = new DelegateCommand(OnOpenFolder);
    }
    #endregion
    #region InteractionRequests
    public static InteractionRequest ShowInfoInteractionRequest { get; } = InteractionRequest.Register();
    #endregion
    #region Commands
    public ICommand OpenFileCommand { get; private set; } 

    public ICommand OpenFolderCommand { get; private set; }
    #endregion
    #region Properties
    public int SelectedGeneration
    {
      get { return selectedGeneration; }
      set
      {
        if (value != selectedGeneration)
        {
          selectedGeneration = value;
          SelectedSpecies = 0;
          SelectedNetwork = 0;
          OnPropertyChanged();
        }
      }
    }

    public int SelectedSpecies
    {
      get { return selectedSpecies; }
      set
      {
        if (value != selectedSpecies)
        {
          selectedSpecies = value;
          SelectedNetwork = 0;
          OnPropertyChanged();
        }
      }
    }

    public int SelectedNetwork { get; set; }

    public ObservableCollection<string> Generations { get; set; } = new ObservableCollection<string>() { " 1\t32", " 2\t110", " 3\t110" };

    public ObservableCollection<string> Species { get; set; } = new ObservableCollection<string>() { " 1\t110", " 2\t80" };

    public ObservableCollection<string> Networks { get; set; } = new ObservableCollection<string>() { " 1\t80", " 2\t80" };
    #endregion
    #region CommandHandlers
    private void OnOpenFile()
    {
      
    }

    private void OnOpenFolder()
    {
      
    }
    #endregion
  }
}