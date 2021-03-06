﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Avalonia;
using NEAT_Visualizer.Business;
using NEAT_Visualizer.Business.GenerationProvider;
using NEAT_Visualizer.Interaction.Commands;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.Model;
using NEAT_Visualizer.ViewModels.Dialogs;
using PropertyChanged;

namespace NEAT_Visualizer.ViewModels
{
  [ImplementPropertyChanged]
  public class MainWindowViewModel : ViewModelBase
  {
    private const char DELIMITER = '\t';

    private readonly IVisualizerBusiness business;

    private IGenerationProvider currenGenerationProvider = GenerationProviderFactory.GetEmptyGenerationProvider();

    private IList<Species> species =>
      SelectedGeneration >= 0
      ? currenGenerationProvider
        .GetGeneration(SelectedGeneration >= currenGenerationProvider.GenerationCount ? 0 : SelectedGeneration)
        .Species
      : new List<Species>();
    private IList<NeuralNetwork> networks =>
      SelectedSpecies >= 0
        ? species[SelectedSpecies >= species.Count ? 0
        : SelectedSpecies].Networks : new List<NeuralNetwork>();
    public NeuralNetwork CurrentNetwork =>
      SelectedNetwork >= 0
        ? networks[SelectedNetwork >= networks.Count ? 0
        : SelectedNetwork] : null;

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

    public ObservableCollection<string> Generations
      =>
        new ObservableCollection<string>(
          currenGenerationProvider.GetGenerations().Select(g => $" {g.GenerationNumber}{DELIMITER}{g.FitnessHighscore}"));

    public ObservableCollection<string> Species
      => new ObservableCollection<string>(
        species.Select((s, i) => $" {i}{DELIMITER}{s.FitnessHighscore}"));

    public ObservableCollection<string> Networks
      => new ObservableCollection<string>(
        networks.Select((n, i) => $" {i}{DELIMITER}{n.Fitness/**n.FitnessModifier*/}"));
    #endregion

    #region CommandHandlers
    private void OnOpenFile()
    {
      var interaction = new UserInteraction()
      {
        Title = "Select generation file",
        Content = new OpenFileDialogViewModel()
      };

      OpenFileDialogInteractionRequest.Raise(interaction, OnOpenFileCallback);
    }

    private void OnOpenFileCallback(IUserInteraction interaction)
    {
      if (interaction.UserInteractionResult == UserInteractionOptions.Ok)
      {
        var file = (interaction.Content as OpenFileDialogViewModel).SelectedFile;
        currenGenerationProvider = GenerationProviderFactory.Get(file, business.GenerationLoader);

        // ReSharper disable once RedundantArgumentDefaultValue
        OnPropertyChanged(null);
        SelectedGeneration = 0;
      }
    }

    private void OnOpenFolder()
    {
      var interaction = new UserInteraction()
      {
        Title = "Select generation file",
        Content = new OpenFolderDialogViewModel()
      };

      OpenFileDialogInteractionRequest.Raise(interaction, OnOpenFolderCallback);
    }

    private void OnOpenFolderCallback(IUserInteraction interaction)
    {
      if (interaction.UserInteractionResult == UserInteractionOptions.Ok)
      {
        var directory = (interaction.Content as OpenFolderDialogViewModel).SelectedDirectory;
        currenGenerationProvider = GenerationProviderFactory.Get(directory, business.GenerationLoader);

        // ReSharper disable once RedundantArgumentDefaultValue
        OnPropertyChanged(null);
        SelectedGeneration = 0;
      }
    }

    private void OnClose()
    {
      Application.Current.Exit();
    }
    #endregion
  }
}