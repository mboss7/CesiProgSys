using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CesiProgSys.ToolsBox

{ public class Config
    {
        // Properties for the configuration data
        public static Language language { get; set; }
        public static string defaultSaveSource { get; set; }
        public static string defaultSaveTarget { get; set; }
        public static List<string> recentSaveSource { get; set; }
        public static List<string> recentSaveTarget { get; set; }
        public static int retentionTime { get; set; }

        public static string TypeLogs = "xml"; // true json false xml

        // Method to write the configuration data to a JSON file
        
        public static void writeConfig(string filePath, string data)
        {
            // Serialize the configuration object to a JSON string
            string json = JsonConvert.SerializeObject(data);
            //Write the JSON string to the specified file
            File.WriteAllText(filePath, json);
        }
        
        

        // Method to read the configuration data from a JSON file
        public static Config readConfig(string filePath)
        {
            // Read the contents of the specified file as a string
            string json = File.ReadAllText(filePath);
            Console.WriteLine(json);
            // Deserialize the JSON string into a Config object and return it
           return JsonConvert.DeserializeObject<Config>(json);

        }
        
        // Method to reset the recentSaveSource, recentSaveTarget, and retentionTime properties to default values
        public static void cleanConfig()
        {
            recentSaveSource.Clear();
            recentSaveTarget.Clear();
        }
        

        public static void resetConfig()
        {
            language = Language.English;
            defaultSaveSource = @"\\BACKUP\test";
            defaultSaveTarget = @"\\BACKUP\bck";
            recentSaveSource = new List<string>();
            recentSaveTarget = new List<string>();
            retentionTime = 0;
        }
    }
}
