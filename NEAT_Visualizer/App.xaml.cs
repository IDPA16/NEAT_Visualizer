using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Views;
using Serilog;

namespace NEAT_Visualizer
{
  class App : Application
  {
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
      base.Initialize();
    }

    static void Main(string[] args)
    {
      InitializeLogging();

      #if __WINAPI
      AppBuilder.Configure<App>()
          .UseWin32()
          .UseDirect2D1()
          .Start<MainWindow>();
      #else
      AppBuilder.Configure<App>()
          .UseGtk()
          .UseCairo()
          .Start<MainWindow>();
      #endif
    }

    public static void AttachDevTools(Window window)
    {
#if DEBUG
      DevTools.Attach(window);
#endif
    }

    private static void InitializeLogging()
    {
#if DEBUG
      SerilogLogger.Initialize(new LoggerConfiguration()
          .MinimumLevel.Warning()
          .WriteTo.Trace(outputTemplate: "{Area}: {Message}")
          .CreateLogger());
#endif
    }
  }
}
