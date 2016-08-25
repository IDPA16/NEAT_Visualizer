using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NEAT_Visualizer.Views
{
  public class MainWindow : Window
  {
    public MainWindow()
    {
      this.InitializeComponent();
      App.AttachDevTools(this);
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
