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

            // print current thread ID 
            Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);

            DailyLogs dl = new DailyLogs();
            dl.startLog();
            
            DailyLogs li = new DailyLogs();
            li.logInfo();

            DailyLogs le = new DailyLogs();
            le.logError();

        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 
        public async void  startLog()
        {
            // Loop who print text with current Thread Id for testing thread. 
            while (flagDl)
            {

                // if (listInfo.Any(true))  // need to be use for trigg loop
                if (true)
                {
                    await using StreamWriter file = new(@".\\LOGS\DailyLogs.json", append: true);
                    // create JSON (need to add variable name to replace infos in JSON !) 
                    JsonLog backup = new JsonLog("--- LOGS START ---",DateTime.Now, "Daily_log.json [json]", @".\\LOGS\DailyLogs.json", @".\\Daily_log.json", 10000, 500);
                    string json = JsonConvert.SerializeObject(backup);
                    await file.WriteLineAsync(json);
                    //Close the file
                    file.Close();
                }
                else
                {

                }

            }
        }

        public async Task logInfo()
        {
            
                    using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
                   // create JSON (need to add variable name to replace infos in JSON !) 
                    JsonLog backup = new JsonLog("--- LOG INFO ---",DateTime.Now, "Sample_log.txt [txt]", @".\\LOGS\RealTimeLogs.json",
                        @".\\Sample_log.txt", 10000, 500);
                    string json = JsonConvert.SerializeObject(backup);
                    await file.WriteLineAsync(json);

                
            
        }


        public async Task logError()
        {
                    using StreamWriter file = new(@".\\LOGS\DailyLogs.json", append: true);
                    // create JSON (need to add variable name to replace infos in JSON !) 
                    JsonLog backup = new JsonLog("--- LOG ERROR ---",DateTime.Now, "Daily_log.txt [txt]", @".\\LOGS\DailyLogs.json",
                        @".\\Daily_log.txt", 10000, 500);
                    string json = JsonConvert.SerializeObject(backup);
                    await file.WriteLineAsync(json);
                  
            }
        }
}
