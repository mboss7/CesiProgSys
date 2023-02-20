using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CesiProgSys.ToolsBox

{ public class Config
    {
        // Properties for the configuration data
        public static Language language { get; set; }
        public string defaultSaveSource { get; set; }
        public string defaultSaveTarget { get; set; }
        public Dictionary<string, string> recentSaveSource { get; set; }
        public Dictionary<string, string> recentSaveTarget { get; set; }
        public int retentionTime { get; set; }

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
        public void cleanConfig()
        {
            /*List<InfoConf> confList = new List<InfoConf>();
            string json = JsonConvert.SerializeObject(confList);
            StreamWriter file = new(@".\\CONF\conf.json", append: false);
            file.WriteLine(json);
            file.Close();*/
            recentSaveSource = new Dictionary<string, string>();
            recentSaveTarget = new Dictionary<string, string>();

        }
        // Method to reset the configuration data to default values

       /* public class InfoConf
        {
           
            public  string defaultSaveSource { get; set; }
            public string defaultSaveTarget { get; set; }
            
        }*/

        public void resetConfig()
        {
            
            
            language = Language.English;
            defaultSaveSource = @"\\BACKUP\test";
            defaultSaveTarget = @"\\BACKUP\bck";
            //recentSaveSource = new Dictionary<string, string>();
            //recentSaveTarget = new Dictionary<string, string>();
            retentionTime = 0;

       
        }
    }
}
