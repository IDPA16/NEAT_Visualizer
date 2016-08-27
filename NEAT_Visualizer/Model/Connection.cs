using System;
using JNF_NEAT_Visualizer.Model;

namespace JNF_NEAT_Visualizer
{
    public class Connection
    {
        public Connection(Neuron neuron, float weight, ulong historicalMarking = 0)
        {
            Neuron = neuron;
            Weight = weight;
            HistoricalMarking = historicalMarking;
        }

        public Neuron Neuron { get; }

        public float Weight { get; }

        public ulong HistoricalMarking { get; }

        public override string ToString()
        {
            return $"[IncomingConnection: Neuron={Neuron}, Weight={Weight}]";
        }
    }
}

