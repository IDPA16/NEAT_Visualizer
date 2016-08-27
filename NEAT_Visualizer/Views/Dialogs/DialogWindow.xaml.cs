using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NEAT_Visualizer.Views.Dialogs
{
  public class DialogWindow : Window
  {
    public DialogWindow()
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
