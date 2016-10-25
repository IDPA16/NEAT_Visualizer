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
        // TODO following two lines can be optimized
        int layerCount = Network.Neurons.Max(n => n.Layer) + 1; // smallest layer is 0
        var layers = Network.Neurons.GroupBy(n => n.Layer).ToList();

        int height = (int)Bounds.Height;
        int widht = (int)Bounds.Width;
        int smallestDimension = height > widht ? widht : height;
        const int circleMargin = 5;
        int maxNeuronsInLayers = layers.ToList().Max(layer => layer.Count());
        int biggerNeuronDimension = layerCount > maxNeuronsInLayers ? layerCount : maxNeuronsInLayers;
        // + 2 to keep the margin in count
        int neuronCircleRadius = (smallestDimension / (biggerNeuronDimension + 2) - circleMargin) / 2;
        int margin = neuronCircleRadius;

        int ystep = (height - margin) / (layerCount + 1);

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
            Point startPoint = leftTopOfStartNeuron.WithX(leftTopOfStartNeuron.X + neuronCircleRadius).WithY(leftTopOfStartNeuron.Y + neuronCircleRadius);
            // the location of the neuron itself
            Point leftTopOfEndNeuron = neuronDrawingInformation.Value;
            Point endPoint = leftTopOfEndNeuron.WithX(leftTopOfEndNeuron.X + neuronCircleRadius).WithY(leftTopOfEndNeuron.Y + neuronCircleRadius);

            connectionsDrawingInformation.Add(connection, new LineData(startPoint, endPoint));
          }
        }

        uint black = ColorToUInt(new Color(255, 0, 0, 0));
        uint red = ColorToUInt(new Color(255, 255, 0, 0));
        var blackLinePen = new Pen(black, 4);
        var redLinePen = new Pen(red);
        var blackOutlinePen = new Pen(black);
        var neuronFillColor = new SolidColorBrush(new Color(255, 102, 255, 102));

        var normalConnections = new List<LineData>();
        var recursiveConnections = new List<LineData>();
        // draw all lines (draw connections before neurons, so neurons overlap the connections)
        foreach (LineData line in connectionsDrawingInformation.Values)
        {
          if (line.End.Y > line.Start.Y)
          {
            recursiveConnections.Add(line);
          }
          else
          {
            normalConnections.Add(line);
          }
        }

        //draw normal connections first, so they dont overlap the red lines that represent recursive connections
        foreach (var line in normalConnections)
        {
          context.DrawLine(blackLinePen, line.Start, line.End);
        }

        foreach (var line in recursiveConnections)
        {
          context.DrawLine(redLinePen, line.Start, line.End);
        }


        // draw all neurons
        foreach (Point neuronCenters in neuronsDrawingInformation.Values)
        {
          context.DrawGeometry(neuronFillColor, blackOutlinePen, GetNeuronCircle(neuronCenters, neuronCircleRadius));
        }
      }

      base.Render(context);
    }

    private static EllipseGeometry GetNeuronCircle(Point center, int circleRadius)
    {
      return new EllipseGeometry(new Rect(center.X, center.Y, circleRadius * 2, circleRadius * 2));
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
