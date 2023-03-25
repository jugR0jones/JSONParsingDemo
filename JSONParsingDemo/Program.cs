using System;
using System.IO;

using Newtonsoft.Json.Linq;

namespace JSONParsingDemo
{
    internal static class Program
    {
        private const string FileName = "settings.json";
            
        public static void Main(string[] args)
        {
            if (!File.Exists(FileName))
            {
                Console.WriteLine("ERROR: File '" + FileName + "' does not exist.");
                return;
            }
            
            string json = File.ReadAllText(FileName);
            
            JObject settingsJOBject = JObject.Parse(json);
            
            JToken nodesToken = settingsJOBject["nodes"];
            
            foreach (JProperty property in ((JObject) nodesToken).Properties())
            { 
                Console.WriteLine(property.Name);  
                Console.WriteLine(property.Value);
            }
            
            foreach (JProperty property in settingsJOBject.Properties())
            {
                Console.WriteLine(property.Name);
            }
        }
    }
}