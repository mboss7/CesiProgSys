﻿using System;
using Newtonsoft.Json;

namespace CesiProgSys.ToolsBox

{
    public class Config
    {
        // Enumeration for the supported languages
        public enum Language
        {
            French,
            English,
        }

        // Properties for the configuration data
        public Language language { get; set; }
        public string defaultSaveSource { get; set; }
        public string defaultSaveTarget { get; set; }
        public Dictionary<string, string> recentSaveSource { get; set; }
        public Dictionary<string, string> recentSaveTarget { get; set; }
        public int retentionTime { get; set; }

        // Method to write the configuration data to a JSON file
        public void writeConfig(string filePath)
        {
            // Serialize the configuration object to a JSON string
            string json = JsonConvert.SerializeObject(this);
            
            // Write the JSON string to the specified file
            System.IO.File.WriteAllText(filePath, json);
        }

        // Method to read the configuration data from a JSON file
        public Config readConfig(string filePath)
        {
            // Read the contents of the specified file as a string
            string json = System.IO.File.ReadAllText(filePath);
            
            // Deserialize the JSON string into a Config object and return it
            return JsonConvert.DeserializeObject<Config>(json);
        }

        // Method to reset the configuration data to default values
        public void cleanConfig()
        {
            language = Language.English;
            defaultSaveSource = "";
            defaultSaveTarget = "";
            recentSaveSource = new Dictionary<string, string>();
            recentSaveTarget = new Dictionary<string, string>();
            retentionTime = 0;
        }
    }
}
