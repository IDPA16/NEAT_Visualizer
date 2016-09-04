using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public class GenerationLoader : IGenerationLoader
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

    public Generation LoadGeneration(FileInfo fileName)
    {
      string json = File.ReadAllText(fileName.FullName);
      var jsonRepresentation = JsonConvert.DeserializeObject<JsonRepresentation.Rootobject>(json);
      int generation = jsonRepresentation.generationsPassed;
      
      return null;
    }

    public List<Generation> LoadAllGenerations(DirectoryInfo directory)
    {
      throw new NotImplementedException();
    }
  }
}