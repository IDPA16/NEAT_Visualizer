using System.Collections.Generic;
using System.Linq;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public static class JsonToModelMapper
  {
    public static Generation ToModel(this JsonRepresentation.Rootobject jsonRoot)
    {
      var generation = new Generation();
      generation.GenerationsPassed = jsonRoot.generationsPassed;
      generation.PopulationSize = jsonRoot.populationSize;

      foreach (var organism in jsonRoot.species)
      {
        generation.Species.Add(organism.ToModel());
      }


      return generation;
    }

    private static Species ToModel(this JsonRepresentation.Species representation)
    {
      var species = new Species();

      foreach (var population in representation.population)
      {
        var neuralNetwork = new NeuralNetwork
        {
          Neurons = population.network.neurons.ToModel(),
          Fitness = population.fitness,
          FitnessModifier = population.fitnessModifier
        };

        species.Networks.Add(neuralNetwork);
      }

      return species;
    }

    private static List<Neuron> ToModel(this JsonRepresentation.Neuron1[] network)
    {
      //network.Select(neuron => neuron.layer))
      return null;
    }

    //private static -> create connections from genoms-....
  }
}