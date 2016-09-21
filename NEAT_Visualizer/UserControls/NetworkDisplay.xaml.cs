using System;
using Avalonia.Controls;
using Avalonia.Controls.Utils;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.UserControls
{
  public class NetworkDisplay : UserControl
  {
    private IObservable<IControl> _this;

    public NetworkDisplay(/*NeuralNetwork network = null*/)
    {
      //DataContext = network;
      this.InitializeComponent();
      _this =  AncestorFinder.Create(this, typeof(NetworkDisplay));
      DataContextChanged += NetworkDisplay_DataContextChanged;
      
    }

    private void NetworkDisplay_DataContextChanged(object sender, EventArgs e)
    {
      //throw new NotImplementedException();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
