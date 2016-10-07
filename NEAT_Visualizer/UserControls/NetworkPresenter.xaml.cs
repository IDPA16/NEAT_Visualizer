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
      AffectsRender(DisplayedNetworkProperty);
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public static readonly DirectProperty<NetworkPresenter, NeuralNetwork> DisplayedNetworkProperty =
      AvaloniaProperty.RegisterDirect<NetworkPresenter, NeuralNetwork>(
        nameof(DisplayedNetwork),
        o => o.DisplayedNetwork,
        (o, v) => o.DisplayedNetwork = v);

    public NeuralNetwork DisplayedNetwork { get; set; }

    public override void Render(DrawingContext context)
    {
      if (DisplayedNetwork != null || true)
#warning REMOVE TRUE ON FINISH
      {      
        var geometry = GetNeuronCircle(100, 100);

        context.DrawGeometry(new SolidColorBrush(new Color(255, 102, 255, 102)), new Pen(0x000000), geometry);
      }


      base.Render(context);
    }

    private static EllipseGeometry GetNeuronCircle(double x, double y)
    {
      return new EllipseGeometry(new Rect(x, y, NEURON_CIRCLE_RADIUS * 2, NEURON_CIRCLE_RADIUS * 2));
    }
  }
}
