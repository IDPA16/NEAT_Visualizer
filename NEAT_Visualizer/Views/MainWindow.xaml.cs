using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
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
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
