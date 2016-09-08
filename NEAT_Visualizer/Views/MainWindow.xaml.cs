using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels;
using PropertyChanged;

namespace NEAT_Visualizer.Views
{
  [DoNotNotify]
  public class MainWindow : Window
  {
    public MainWindow(MainWindowViewModel viewModel)
    {
      DataContext = viewModel;

      InitializeComponent();
      App.AttachDevTools(this);

      //var button = new Button();
      //button.Content = "Wew lad";
      //button.Width = 60;
      //button.Height = 60;
      //var rootPanel = this.Find<Panel>("Root");
      //rootPanel.Children.Add(button);
      //button.Click += ButtonOnClick;
      //Canvas canvas = this.Find<Canvas>("Canvas");
    }

    //private void ButtonOnClick(object sender, RoutedEventArgs e)
    //{
    //  (sender as Button).Content = "Wehew!";
    //  MainWindowViewModel.ShowInfoInteractionRequest.Raise(new UserInteraction()
    //  {
    //    Title = "wuwuuw",
    //    Content = "Some text that is important",
    //    UserInteractionOptions = UserInteractionOptions.Ok
    //  });

    //}

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
