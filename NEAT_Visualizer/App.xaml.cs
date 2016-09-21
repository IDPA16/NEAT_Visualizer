using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Business.DataLoaders;
using NEAT_Visualizer.Views;
using Serilog;

namespace NEAT_Visualizer
{
  internal class App : Application
  {
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
      base.Initialize();
    }

    static void Main(string[] args)
    {
      InitializeLogging();
      var bootstrapper = new Bootstrapper();
      var app = new App();

      AppBuilder.Configure(app)
      .UsePlatformDetect()
      .SetupWithoutStarting();

      bootstrapper.InitializeApplication();
      app.Start(bootstrapper.StartupWindow);
    }

    public void Start(Window startupWindow)
    {
      startupWindow.Show();
      Run(startupWindow);
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
