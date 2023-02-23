using CesiProgSys.Network;
using CesiProgSys.Network.Packets;

namespace CesiProgSys.ToolsBox;

public class Config
{
    private Config()
    {
        recentSaveSource = new HashSet<string>();    
        recentSaveTarget = new HashSet<string>();   
        retentionTime = 30;
        language = Language.English;
    }

    private static Config instance;

    public static Config Instance()
    {
        if (instance == null)
        {
            instance = new Config();
        }

        return instance;
    }

    // Properties for the configuration data
    public Language language;
    public string defaultSaveSource;
    public string defaultSaveTarget;
    public HashSet<string> recentSaveSource;
    public HashSet<string> recentSaveTarget;
    public int retentionTime;   //en jours
    public string typeLogs = "json";

    // Method to write the configuration data to a JSON file
    public void writeConfig()
    {
        // Serialize the configuration object to a JSON string
        string json = Json.objectToJson(this);
        //Write the JSON string to the specified file
        using StreamWriter file = new("./config.json", append: false);
        file.WriteLine(json);
    }


    // Method to read the configuration data from a JSON file
    public void setConfig()
    {
        if (!File.Exists("./config.json"))
        {
            File.Create("./config.json");
            return;
        }
            
        
        // Read the contents of the specified file as a string
        using StreamReader file = new("./config.json");
        
        string json = file.ReadToEnd();
        // Deserialize the JSON string into a Config object and return it
        Config conf = Json.JsonToConfig(json);

        if (conf == null)
        {
            return;
        }
        
        language = conf.language;
        defaultSaveSource = conf.defaultSaveSource;
        defaultSaveTarget = conf.defaultSaveTarget;
        recentSaveSource = conf.recentSaveSource;
        recentSaveTarget = conf.recentSaveTarget;
        retentionTime = conf.retentionTime > 0 ? conf.retentionTime : 30;
        typeLogs = conf.typeLogs is "xml" or "json" ? conf.typeLogs : "json";
    }

    // Method to reset the recentSaveSource, recentSaveTarget, and retentionTime properties to default values
    public void resetConfig()
    {
        typeLogs = "json";
        language = Language.English;
        retentionTime = 30;
        recentSaveSource.Clear();
        recentSaveTarget.Clear();
    }

    public void addToSet(string toAdd, HashSet<string> hashSet)
    {
        bool flag = false;
        foreach (string s in hashSet)
        {
            if (toAdd == s)
                flag = true;
        }

        if (!flag)
            hashSet.Add(toAdd);
    }
    
    public void checkTimeRecentSave()
    {
    }

    public void SendConfig()
    {
        PacketConfigs p = new PacketConfigs()
        {
            language = language,
            defaultSource = defaultSaveSource,
            defautlTarget = defaultSaveTarget,
            recentSource = recentSaveSource,
            recentTarget = recentSaveTarget,
            typeLogs = typeLogs
        };
        
        Client.packets.Enqueue(Json.objectToJson(p));
        Client.wait.Set();
    }
}