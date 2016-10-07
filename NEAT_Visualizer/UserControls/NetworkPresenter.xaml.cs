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
      var geometry = StreamGeometry.Parse("M10 10 H 90 V 90 H 10 Z");

      context.DrawGeometry(new SolidColorBrush(new Color(255,25,0,0)), new Pen(123123),  geometry);
      base.Render(context);
    }
  }
}
