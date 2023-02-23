
using CesiProgSys.Network;
using Newtonsoft.Json;

namespace CesiProgSys.ToolsBox
{
// Tool convert string to Json
    public class Json
    {
        public static string objectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static Config? JsonToConfig(string json)
        {
            return JsonConvert.DeserializeObject<Config>(json);
        }

        public static Packet JsonToPacket(string json)
        {
            return JsonConvert.DeserializeObject<Packet>(json);
            
        }
    }
}