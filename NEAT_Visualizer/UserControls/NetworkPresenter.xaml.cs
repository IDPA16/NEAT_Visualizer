using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using NEAT_Visualizer.Model;
using PropertyChanged;

namespace NEAT_Visualizer.UserControls
{
  [DoNotNotify]
  public class NetworkPresenter : Canvas
  {
    // TODO parameter and dependend on amount of layers
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
        var neuronsDrawingInformation = new Dictionary<Neuron, Point>();

        // construct all neurons
        int layerCount = Network.Neurons.Max(n => n.Layer) + 1; // smallest layer is 0

        int height = (int)Bounds.Height;
        int widht = (int)Bounds.Width;
        const int margin = 50;
        int ystep = (height - margin) / (layerCount + 1);

        var layers = Network.Neurons.GroupBy(n => n.Layer).ToList();
        for (int layer = 0; layer < layerCount; layer++)
        {
          var neurons = layers[layer];
          int neuronsInLayer = neurons.Count();
          int ypos = (height - 2 * margin) - ystep * (layer + 1);
          int xstep = (widht - margin) / (neuronsInLayer + 1);

          for (int j = 0; j < neuronsInLayer; j++)
          {
            var neuron = neurons.ElementAt(j);
            int xpos = xstep * (j + 1);
            Point neuronCenter = new Point(xpos, ypos);
            neuronsDrawingInformation.Add(neuron, neuronCenter);
          }
        }

        var connectionsDrawingInformation = new Dictionary<Connection, LineData>();

        foreach (var neuronDrawingInformation in neuronsDrawingInformation)
        {
          // foreach incoming connection of the neuron
          foreach (var connection in neuronDrawingInformation.Key.IncomingConnections)
          {
            Point leftTopOfStartNeuron = neuronsDrawingInformation[connection.Neuron];
            Point startPoint = leftTopOfStartNeuron.WithX(leftTopOfStartNeuron.X + NEURON_CIRCLE_RADIUS).WithY(leftTopOfStartNeuron.Y + NEURON_CIRCLE_RADIUS);
            // the location of the neuron itself
            Point leftTopOfEndNeuron = neuronDrawingInformation.Value;
            Point endPoint = leftTopOfEndNeuron.WithX(leftTopOfEndNeuron.X + NEURON_CIRCLE_RADIUS).WithY(leftTopOfEndNeuron.Y + NEURON_CIRCLE_RADIUS);

            connectionsDrawingInformation.Add(connection, new LineData(startPoint, endPoint));
          }
        }

        uint black = ColorToUInt(new Color(255, 0, 0, 0));
        var blackLinePen = new Pen(black, 4);
        var blackOutlinePen = new Pen(black);
        var neuronFillColor = new SolidColorBrush(new Color(255, 102, 255, 102));

        // draw all lines (draw connections before neurons, so neurons overlap the connections)
        foreach (LineData line in connectionsDrawingInformation.Values)
        {
          context.DrawLine(blackLinePen, line.Start, line.End);
        }

        // draw all neurons
        foreach (Point neuronCenters in neuronsDrawingInformation.Values)
        {
          context.DrawGeometry(neuronFillColor, blackOutlinePen, GetNeuronCircle(neuronCenters));
        }
      }

      base.Render(context);
    }

    private static EllipseGeometry GetNeuronCircle(Point center)
    {
      return new EllipseGeometry(new Rect(center.X, center.Y, NEURON_CIRCLE_RADIUS * 2, NEURON_CIRCLE_RADIUS * 2));
    }

    private uint ColorToUInt(Color color)
    {
      return (uint)((color.A << 24) | (color.R << 16) |
                    (color.G << 8) | (color.B << 0));
    }

    private struct LineData
    {
      public LineData(Point start, Point end)
      {
        Start = start;
        End = end;
      }

      public Point Start { get; }

      public Point End { get; }
    }
  }
}
