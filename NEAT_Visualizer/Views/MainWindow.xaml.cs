using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.Services;
using NEAT_Visualizer.Interaction.UserInteractions;
using NEAT_Visualizer.ViewModels;

namespace NEAT_Visualizer.Views
{
  public class MainWindow : Window
  {
    private IPanel rootPanel;

    public MainWindow()
    {
      this.InitializeComponent();
      App.AttachDevTools(this);

      var button  = new Button();
      button.Content = "Wew lad";
      button.Width = 60;
      button.Height = 60;
      rootPanel = this.Find<Panel>("Root");
      rootPanel.Children.Add(button);
      button.Click += ButtonOnClick; 
      //obv, this should be handled in the viewmodel, not in an eventhandler.
      //this is just for testing/trying out.
      this.DataContext = new MainWindowViewModel();
    }

    private void ButtonOnClick(object sender, RoutedEventArgs e)
    { 
      (sender as Button).Content = "Wehew!";
      MainWindowViewModel.ShowInfoInteractionRequest.Raise(new UserInteraction()
      {
        Title = "wuwuuw",
        Content = "Some text that is important",
        UserInteractionOptions = UserInteractionOptions.Ok
      });

    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
