
using Newtonsoft.Json;

namespace CesiProgSys.ToolsBox
{
// Tool convert string to Json
    public class JsonLog
    {

        public static string stringToJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }
    }
}