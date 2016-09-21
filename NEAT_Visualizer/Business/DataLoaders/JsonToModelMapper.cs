using System.Collections.Generic;
using System.Linq;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public static class JsonToModelMapper
  {
    public static Generation ToModel(this JsonRepresentation.Rootobject jsonRoot)
    {
      var generation = new Generation
      {
        GenerationsPassed = jsonRoot.generationsPassed,
        PopulationSize = jsonRoot.populationSize,
      };

      foreach (var species in jsonRoot.species)
      {
        generation.Species.Add(species.ToModel());
      }

      generation.FitnessHighscore = generation.Species.Select(n => n.FitnessHighscore).Max();

      return generation;
    }

    private static Species ToModel(this JsonRepresentation.Species speciesRepresentation)
    {
      var species = new Species();

      foreach (var population in speciesRepresentation.population)
      {
        species.Networks.Add(CreateNetworkFromData(population));
      }

      return species;
    }

    private static NeuralNetwork CreateNetworkFromData(this JsonRepresentation.Population organism)
    {
      var network = new NeuralNetwork
      {
        Fitness = organism.fitness,
        FitnessModifier = organism.fitnessModifier
      };

      var neurons = organism.network.neurons.Select(n => new Neuron() { Layer = n.layer }).ToList();

      // creates the connections from the genomes
      foreach (var genome in organism.network.genome.genes)
      {
        if (genome.isEnabled)
        {
          neurons[genome.to].IncomingConnections.Add(
            new Connection(neurons[genome.from], genome.weight, genome.historicalMarking));
        }
      }

      network.Neurons = neurons;
      return network;
    }
  }
}