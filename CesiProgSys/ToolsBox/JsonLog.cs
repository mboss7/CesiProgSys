using System;
using CesiProgSys.LOG;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

// Tool convert string to Json
public class JsonLog
{

    public static string stringToJson(object obj)
    {
        //JsonLog backup = new JsonLog("LogType", DateTime.Now, "Sample_log.pdf [pdf]", @"\\server\source\Sample_log.pdf", @"\\server\destination\Sample_log.pdf", 10000, 500);
        string json = JsonConvert.SerializeObject(obj);
        // Console.WriteLine(json);
        return json;
    }
}
