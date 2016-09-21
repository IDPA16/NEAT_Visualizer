using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.UserControls
{
  public static class NetworkStructuresCanvasDrawer
  {
    public static void DrawNeuron(this Canvas canvas, Neuron neuron, Point position, int circleRadius)
    {
      Canvas.SetLeft(canvas, position.X);
      Canvas.SetRight(canvas, position.Y);
      var ellipse = new Ellipse
      {
        Width = circleRadius*2,
        Height = circleRadius*2,
        Fill = new SolidColorBrush(233232)
      };

      canvas.Children.Add(ellipse);
    }
  }
}