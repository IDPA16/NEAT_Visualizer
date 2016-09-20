using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Model;
using PropertyChanged;

namespace NEAT_Visualizer.UserControls
{
  [DoNotNotify]
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
      this.DrawNeuron(network.Neurons.First(), new Point(50, 50), 20);
    }
  }
}
