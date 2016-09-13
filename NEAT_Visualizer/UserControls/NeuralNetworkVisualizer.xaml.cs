using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.UserControls
{
  public class NeuralNetworkVisualizer : Canvas, INeuralNetworkVisualizer
  {
    private NeuralNetwork currentNetwork;

    public NeuralNetworkVisualizer()
    {
      this.InitializeComponent();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public void DisplayNetwork(NeuralNetwork network)
    {
      currentNetwork = network;
    }
  }
}
