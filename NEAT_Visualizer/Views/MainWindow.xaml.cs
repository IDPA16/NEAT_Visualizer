using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.Model;
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

      //var root = this.FindControl<DockPanel>("Root");
      //var networkPresenter = new NetworkPresenter();
      //root.Children.Add(networkPresenter);

      var canvas = this.FindControl<NetworkPresenter>("NetworkPresenter");

      var sg = new StreamGeometry();


      using (var sgc = sg.Open())
      {
        sgc.BeginFigure(new Point(2, 2), true);
        sgc.LineTo(new Point(20, 20));
        sgc.ArcTo(new Point(50, 50), new Size(20, 20), 0, false, SweepDirection.Clockwise);
        sgc.EndFigure(false);
      }

      canvas.Clip = sg;
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
