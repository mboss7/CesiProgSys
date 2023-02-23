
using Newtonsoft.Json;
using ViewAvalonia.Network;

namespace ViewAvalonia.ToolBox
{
// Tool convert string to Json
    public class Json
    {
        public static string objectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static Packet JsonToPacket(string json)
        {
            return JsonConvert.DeserializeObject<Packet>(json);
            
        }
    }
}