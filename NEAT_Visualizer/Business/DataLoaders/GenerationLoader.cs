using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NEAT_Visualizer.Model;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public class GenerationLoader : IGenerationLoader
  {
    public Generation LoadGeneration(FileInfo fileName)
    {
      string json = File.ReadAllText(fileName.FullName);
      var jsonRepresentation = JsonConvert.DeserializeObject<JsonRepresentation.Rootobject>(json);
      
      return jsonRepresentation.ToModel();
    }

    public List<Generation> LoadAllGenerations(DirectoryInfo directory)
    {
      return directory.GetFiles().Select(LoadGeneration).ToList();
    }
  }
}