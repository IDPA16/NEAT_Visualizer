using System.Collections.Generic;

namespace NEAT_Visualizer.Model
{
  public class NeuralNetwork
  {
    public NeuralNetwork() : this(new List<Neuron>()) { }

    public NeuralNetwork(IList<Neuron> neurons)
    {
      Neurons = neurons;
    }

    public IList<Neuron> Neurons { get; set; }

    public float Fitness { get; set; }

    public float FitnessModifier { get; set; }
  }
}