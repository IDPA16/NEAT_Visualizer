using System;
using System.Windows.Input;

namespace NEAT_Visualizer.Interaction.Commands
{
  public class DelegateCommand : ICommand
  {
    private readonly Action execute;
    private readonly Func<bool> canExecute;

    public DelegateCommand(Action execute, Func<bool> canExecute)
    {
      this.execute = execute;
      this.canExecute = canExecute;
    }

    public DelegateCommand(Action execute) : this(execute, null) { }

    public bool CanExecute(object parameter)
    {
      return this.canExecute == null || this.canExecute();
    }

    public event EventHandler CanExecuteChanged;

    public void RaiseCanExecuteChanged()
    {
      this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Execute(object parameter)
    {
      this.execute?.Invoke();
    }
  }

  public class DelegateCommand<T> : ICommand
  {
    private readonly Action<T> execute;
    private readonly Func<bool> canExecute;

    public DelegateCommand(Action<T> execute, Func<bool> canExecute)
    {
      this.execute = execute;
      this.canExecute = canExecute;
    }

    public DelegateCommand(Action<T> execute) : this(execute, null) { }

    public bool CanExecute(object parameter)
    {
      return this.canExecute == null || this.canExecute();
    }

    public event EventHandler CanExecuteChanged;

    public void RaiseCanExecuteChanged()
    {
      this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Execute(object parameter)
    {
      this.execute?.Invoke((T)parameter);
    }
  }
}