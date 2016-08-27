using System.Collections;
using System.Collections.Generic;

namespace JNF_NEAT_Visualizer.Model
{
  public class NeuralNetwork
  {
    public NeuralNetwork(IList<Neuron> neurons)
    {
      Neurons = neurons;
    }

    public NeuralNetwork()
    {

    }

    public IList<Neuron> Neurons { get; set; }
  }
}