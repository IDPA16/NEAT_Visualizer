﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Views;

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
      AppBuilder.Configure<App>()
          .UseWin32()
          .UseDirect2D1()
          .Start<MainWindow>();
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
