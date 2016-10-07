using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.UserControls
{
  public class NetworkPresenter : UserControl, INetworkPresenter
  {
    public NetworkPresenter()
    {
      this.InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public void DisplayNetwork(NeuralNetwork network)
    {
      throw new NotImplementedException();
    }
  }
}
