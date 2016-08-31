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

      this.LogicalChildren.Add(new Button());
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
