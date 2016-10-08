﻿using System.Collections.Generic;
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

        var connectionsDrawingInformation = new Dictionary<Connection, Geometry>();
        
        foreach (var neuronDrawingInformation in neuronsDrawingInformation)
        {
          // foreach incoming connection of the neuron
          foreach (var connection in neuronDrawingInformation.Key.IncomingConnections)
          {
            Point startPoint = neuronsDrawingInformation[connection.Neuron];
            // the location of the neuron itself
            Point endPoint = neuronDrawingInformation.Value;
            connectionsDrawingInformation.Add(connection, new LineGeometry(startPoint, endPoint));
          }
        }

        // draw all neurons
        foreach (Point neuronCenters in neuronsDrawingInformation.Values)
        {
          context.DrawGeometry(new SolidColorBrush(new Color(255, 102, 255, 102)), new Pen(0x000000), GetNeuronCircle(neuronCenters));
        }

        foreach (Geometry connectionLineGeometry in connectionsDrawingInformation.Values)
        {
          context.DrawGeometry(new SolidColorBrush(new Color(255,102,255,102)), new Pen(0x123832, 5), connectionLineGeometry);
        }
      }

      base.Render(context);
    }

    private static EllipseGeometry GetNeuronCircle(Point center)
    {
      return new EllipseGeometry(new Rect(center.X, center.Y, NEURON_CIRCLE_RADIUS * 2, NEURON_CIRCLE_RADIUS * 2));
    }
  }
}
