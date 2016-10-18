using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NEAT_Visualizer.Business.GenerationProvider;

namespace NEAT_Visualizer.Business.DataLoaders
{
  public class MetatdataLoader : IMetatdataLoader
  {
    public IList<GenerationMetadata> LoadMetadata(FileInfo fileName)
    {
      string json = File.ReadAllText(fileName.FullName);
      dynamic data = JsonConvert.DeserializeObject(json);
      dynamic generationInfo = data.generations;
      var metaDatas = new List<GenerationMetadata>();

      for (int i = 0; i < generationInfo.Count; i++)
      {
        decimal maxFitness = generationInfo[i].max_fitness;
        metaDatas.Add(new GenerationMetadata(i + 1, maxFitness));
      }

      return metaDatas;
    }
  }
}