using System;
using System.Collections.ObjectModel;
using NEAT_Visualizer.Interaction.UserInteractions;

namespace NEAT_Visualizer.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    //private const char DELIMITER = '\t';

    private int selectedGeneration = 0;

    private int selectedSpecies = 0;

    private int selectedNetwork = 0;

    public static InteractionRequest ShowInfoInteractionRequest { get; } = InteractionRequest.Register();

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

    public int SelectedNetwork
    {
      get { return selectedNetwork; }
      set
      {
        selectedNetwork = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<string> Generations { get; set; } = new ObservableCollection<string>() { " 1\t32", " 2\t110", " 3\t110" };

    public ObservableCollection<string> Species { get; set; } = new ObservableCollection<string>() { " 1\t110", " 2\t80" };

    public ObservableCollection<string> Networks { get; set; } = new ObservableCollection<string>() { " 1\t80", " 2\t80" };
  }
}