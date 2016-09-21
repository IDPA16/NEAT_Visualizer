using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NEAT_Visualizer.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string aPropertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
    }
  }
}