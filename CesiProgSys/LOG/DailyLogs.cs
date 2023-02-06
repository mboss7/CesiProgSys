using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using CesiProgSys.ToolsBox;
using Newtonsoft.Json;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs : ILogs
     {
        // create list of info object who trigg the thread methode  
        static List<Info> listInfo = new List<Info>();
        public static bool flagDl = true;



        // start new thread when listInfo is not null  
        public static void startThread()
        {
            DailyLogs dl = new DailyLogs();
            dl.startLog();
        }

        
        public async void  startLog()
        {
            while (flagDl)
            {
                foreach (Info inf in listInfo)
                {
                    string json = JsonLog.stringToJson(inf);
                    Console.WriteLine(json);

                    if (inf.LogType)
                    {
                        await logInfo(json);
                    }
                    else
                    {
                        await logError(json);
                    }
                }
            }
        }

        public async Task logInfo(string toPrint)
        {
            
                    using StreamWriter file = new(@".\\LOGS\DailyLogs.json", append: true);
                    await file.WriteLineAsync(toPrint);

                
            
        }


        public async Task logError(string toPrint)
        {
                    using StreamWriter file = new(@".\\LOGS\DailyLogs.json", append: true);
                    await file.WriteLineAsync(toPrint);
                  
        }
     }
}
