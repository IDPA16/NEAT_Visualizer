using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.UserControls;
using NEAT_Visualizer.ViewModels;
using PropertyChanged;

namespace NEAT_Visualizer.Views
{
  [DoNotNotify]
  public class MainWindow : Window
  {
    public MainWindow(MainWindowViewModel viewModel)
    {
      DataContext = viewModel;

      InitializeComponent();
      App.AttachDevTools(this);

      var path = this.FindControl<Path>("SVGHost");     
      //path.Data = ?
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
