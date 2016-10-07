using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NEAT_Visualizer.Model;
using PropertyChanged;

namespace NEAT_Visualizer.UserControls
{
  [DoNotNotify]
  public class NetworkPresenter : Canvas
  {
    private const int NEURON_CIRCLE_RADIUS = 50;

    public NetworkPresenter()
    {
      this.InitializeComponent();
      AffectsRender(NetworkProperty);
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public static readonly DirectProperty<NetworkPresenter, NeuralNetwork> NetworkProperty =
      AvaloniaProperty.RegisterDirect<NetworkPresenter, NeuralNetwork>(
        nameof(Network),
        o => o.Network,
        (o, v) => o.Network = v);

    public NeuralNetwork Network { get; set; }

    public override void Render(DrawingContext context)
    {
      if (Network != null) // no need to draw when no network is available.
      {
        List<Geometry> geometryToDraw = new List<Geometry>();

        int layerCount = Network.Neurons.Max(n => n.Layer) + 1; // smallest layer is 0
        int height = (int)Height;
        int widht = (int)Width;
        const int margin = 50;
        int xstep = (height - margin) / layerCount;

        var layers = Network.Neurons.GroupBy(n => n.Layer).ToList();
        for (int i = 0; i < layerCount; i++)
        {
          var neurons = layers[i];
          int layer = neurons.First().Layer;
          int neuronsInLayer = neurons.Count();
          int ypos = xstep * i;

          for (int j = 0; j < neuronsInLayer; j++)
          {
            //var neuron = neurons.ElementAt(j);
            int xpos = ((widht - margin) / neuronsInLayer) * j;
            geometryToDraw.Add(GetNeuronCircle(xpos, ypos));
          }
        }

        foreach (var geometry in geometryToDraw)
        {
          context.DrawGeometry(new SolidColorBrush(new Color(255, 102, 255, 102)), new Pen(0x000000), geometry);
        }
      }


      base.Render(context);
    }

    private static EllipseGeometry GetNeuronCircle(double x, double y)
    {
      return new EllipseGeometry(new Rect(x, y, NEURON_CIRCLE_RADIUS * 2, NEURON_CIRCLE_RADIUS * 2));
    }
  }
}
