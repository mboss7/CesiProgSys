using Newtonsoft.Json;

namespace CesiProgSys.ToolsBox

{
    public class Config
    {
        // Properties for the configuration data
        public Language language { get; set; }
        public string defaultSaveSource { get; set; }
        public string defaultSaveTarget { get; set; }
        public Dictionary<string, string> recentSaveSource { get; set; }
        public Dictionary<string, string> recentSaveTarget { get; set; }
        public int retentionTime { get; set; }

        public static string TypeLogs = "xml"; // true json false xml

        // Method to write the configuration data to a JSON file
        public static void writeConfig(string filePath)
        {
            // Serialize the configuration object to a JSON string
            string json = JsonConvert.SerializeObject(filePath);
            
            StreamWriter file = new(filePath, append: true);
            file.WriteLine(json);
            file.Close();
            resetConf();


            // Write the JSON string to the specified file
            //System.IO.File.WriteAllText(filePath, json);


        }

        public static void resetConf()
        {
            List<InfoConf> confList = new List<InfoConf>();
            string json = JsonConvert.SerializeObject(confList);
            StreamWriter file = new(@".\\CONF\conf.json", append: false);
            file.WriteLine(json);
            file.Close();
        }
        // Method to reset the configuration data to default values

        public class InfoConf
        {
           
            public  string defaultSaveSource { get; set; }
            public string defaultSaveTarget { get; set; }
            
        }

        public void creatConfList()
        {
            
            
            language = Language.English;
            defaultSaveSource = @"\\BACKUP\test";
            defaultSaveTarget = @"\\BACKUP\bck";
            recentSaveSource = new Dictionary<string, string>();
            recentSaveTarget = new Dictionary<string, string>();
            retentionTime = 0;

       
        }
    }
}
