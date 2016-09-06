using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels;

namespace NEAT_Visualizer.Views
{
  public class MainWindow : Window
  {
    public MainWindow()
    {
      this.InitializeComponent();
      App.AttachDevTools(this);

      //Canvas canvas = this.Find<Canvas>("Canvas");
      this.DataContext = new MainWindowViewModel();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
