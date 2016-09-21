using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using NEAT_Visualizer.Interaction.UserInteractions;
using PropertyChanged;

namespace NEAT_Visualizer.Views.Dialogs
{
  [DoNotNotify]
  public class DialogWindow : Window
  {
    private readonly IUserInteraction interaction;

    private readonly IPanel root;

    public DialogWindow(IUserInteraction interaction)
    {
      this.interaction = interaction;
      DataContext = interaction;

      InitializeComponent();

      root = this.Find<IPanel>("Root");
      App.AttachDevTools(this);

      AddButtons(interaction.UserInteractionOptions);
    }

    private void AddButtons(UserInteractionOptions options)
    {
      const int buttonWidth = 100;
      var buttonBar = root.FindControl<IPanel>("ButtonBar");

      // create all the buttons
      foreach (var option in GetFlags(options))
      {
        var button = new Button { Content = Enum.GetName(typeof(UserInteractionOptions), option), Width = buttonWidth };
        buttonBar.Children.Add(button);
        button.Click += (sender, e) =>
        {
          interaction.UserInteractionResult = (UserInteractionOptions)option;
          Close();
        };
      }

      int buttonCount = buttonBar.Children.Count;
      // this has to be changed if the ButtonBar isnt a StackPanel anymore!
      var bar = buttonBar as StackPanel;
      bar.Width = buttonWidth * buttonCount;
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
