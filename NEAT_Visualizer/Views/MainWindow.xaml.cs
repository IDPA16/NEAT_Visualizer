using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
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

      var canvas = this.FindControl<Canvas>("Canvas");
      canvas.PointerPressed += Canvas_PointerPressed;
    }

    private void Canvas_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
    {
      var canvas = sender as Canvas;
      Point point = e.GetPosition(canvas);
      InteractionRequest.Register().Raise(new UserInteraction() {Content = point.ToString() , Title = "Point clicked"});
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
