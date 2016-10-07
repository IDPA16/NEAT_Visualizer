using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NEAT_Visualizer.Model;
using PropertyChanged;

namespace NEAT_Visualizer.UserControls
{
  [DoNotNotify]
  public class NetworkPresenter : Canvas, INetworkPresenter
  {
    public NetworkPresenter()
    {
      this.InitializeComponent();
      //DisplayNetwork(null);
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public void DisplayNetwork(NeuralNetwork network)
    {
      var canvas = this;/*.FindControl<Canvas>("Canvas");*/
      var sg = new StreamGeometry();
      

      using (var sgc = sg.Open())
      {
        sgc.BeginFigure(new Point(2, 2), true);
        sgc.LineTo(new Point(20, 20));
        sgc.ArcTo(new Point(50,50), new Size(20,20), 0, false, SweepDirection.Clockwise);
        sgc.EndFigure(false);
      }

      canvas.Clip = sg;
    }
  }
}
