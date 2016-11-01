using System;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public class LazyCache<T> where T : class 
  {
    private readonly Func<T> valueFactory;

    private T temp;

    public LazyCache(Func<T> valueFactory)
    {
      if (valueFactory == null)
      {
        throw new ArgumentException(nameof(valueFactory));
      }

      this.temp = null;
      this.valueFactory = valueFactory;
    }

    public T Value => temp ?? (temp = valueFactory.Invoke());

    public void ResetCache() => temp = null;

    public bool IsLoaded => temp != null;
  }
}