using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.UserInteractions;

namespace NEAT_Visualizer.Views.Dialogs
{
  public class DialogWindow : Window
  {
    private IUserInteraction interaction;

    private IPanel root;

    public DialogWindow(IUserInteraction interaction)
    {
      this.interaction = interaction;
      this.DataContext = interaction.Content;
      this.InitializeComponent();
      root = this.Find<IPanel>("Root");
      App.AttachDevTools(this);
      AddButtons(interaction.UserInteractionOptions);
    }

    private void AddButtons(UserInteractionOptions options)
    {
      var buttonBar = root.FindControl<IPanel>("ButtonBar");

      // create all the buttons
      foreach (var option in GetFlags(options))
      {
        var button = new Button { Content = Enum.GetName(typeof(UserInteractionOptions), option) };
        buttonBar.Children.Add(button);
        button.Click += (sender, e) =>
        {
          interaction.UserInteractionResult = (UserInteractionOptions) option;
          this.Close();
        };
      }
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    private static IEnumerable<Enum> GetFlags(Enum input)
    {
      foreach (Enum value in Enum.GetValues(input.GetType()))
      {
        if (input.HasFlag(value)) yield return value;
      }
    }

  }
}
