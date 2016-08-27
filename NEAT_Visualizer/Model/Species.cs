using System.Collections;
using System.Collections.Generic;

namespace JNF_NEAT_Visualizer.Model
{
    public class Species
    {
        public IList<NeuralNetwork> Networks { get; } = new List<NeuralNetwork>();
    }
}