using Newtonsoft.Json;
using PlayFab;
using PlayFab.AdminModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            AddServerBuildRequest request = new AddServerBuildRequest();
            request.BuildId = "4546";
            request.ActiveRegions = new List<Region> { Region.Australia, Region.Brazil };
            request.MaxGamesPerHost = 2;

            var serializer = JsonSerializer.Create(PlayFabSettings.JsonSettings);

            StringWriter jsonString = new StringWriter();
            var writer = new JsonTextWriter(jsonString) { Formatting = PlayFabSettings.JsonFormatting };
            serializer.Serialize(writer, request);
            String bodyString = jsonString.ToString();

            AddServerBuildRequest resultData = serializer.Deserialize<AddServerBuildRequest>(new JsonTextReader(new StringReader(bodyString)));

            Console.WriteLine("ta da!");

        }
    }
}
