using System;
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

      if (IsWindows() && !UseGtkOnWindows())
      {
        new Bootstrapper().InitializeApplication();

        AppBuilder.Configure<App>()
            .UseWin32()
            .UseDirect2D1()
            .Start<MainWindow>();
      }
      else
      {
        // on mac, unix, and if chosen on windows, use Gtk
        AppBuilder.Configure<App>()
            .UseGtk()
            .UseCairo()
            .Start<MainWindow>();
      }
    }

    private static bool UseGtkOnWindows()
    {
      // change this to true if gtk should be used
      return false;
    }

    private static bool IsWindows()
    {
      return Environment.OSVersion.Platform == PlatformID.Win32Windows ||
             Environment.OSVersion.Platform == PlatformID.Win32NT ||
             Environment.OSVersion.Platform == PlatformID.Win32S ||
             Environment.OSVersion.Platform == PlatformID.WinCE;
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
