using System;
using System.Collections.Generic;
using System.IO;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public class NetworkLoader : INetworkLoader
  {
    private class JsonRepresentation
    {
      public class Rootobject
      {
        public int populationSize { get; set; }
        public int generationsPassed { get; set; }
        public Species[] species { get; set; }
      }

      public class Species
      {
        public float fitnessHighscore { get; set; }
        public int numberOfStagnantGenerations { get; set; }
        public Representative representative { get; set; }
        public Population[] population { get; set; }
      }

      public class Representative
      {
        public float fitness { get; set; }
        public float fitnessModifier { get; set; }
        public Network network { get; set; }
      }

      public class Network
      {
        public Neuron[] neurons { get; set; }
        public Genome[] genome { get; set; }
      }

      public class Neuron
      {
        public int layer { get; set; }
        public float lastActionPotential { get; set; }
      }

      public class Genome
      {
        public int historicalMarking { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public float weight { get; set; }
        public bool isEnabled { get; set; }
        public bool isRecursive { get; set; }
      }

      public class Population
      {
        public float fitness { get; set; }
        public float fitnessModifier { get; set; }
        public Network1 network { get; set; }
      }

      public class Network1
      {
        public Neuron1[] neurons { get; set; }
        public Genome1[] genome { get; set; }
      }

      public class Neuron1
      {
        public int layer { get; set; }
        public float lastActionPotential { get; set; }
      }

      public class Genome1
      {
        public int historicalMarking { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public float weight { get; set; }
        public bool isEnabled { get; set; }
        public bool isRecursive { get; set; }
      }
    }

    public NeuralNetwork GetNetwork(FileInfo fileName)
    {
      string json = File.ReadAllText(fileName.FullName);
      //JsonRepresentation.Rootobject;

      return null;
    }

    public Species LoadSpecies(DirectoryInfo directory)
    {
      throw new NotImplementedException();
    }

    public List<Species> LoadFullNeatData(DirectoryInfo rootDirectory)
    {
      throw new NotImplementedException();
    }
  }
}