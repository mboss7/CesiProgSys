using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using CesiProgSys.ToolsBox;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        public static List<Info> listInfo; 

        public static void ListInfo()
        {
        }


        public static bool flagRtl = true;
        
       // start new thread when listInfo is not null  
        public static void startThread()
        {
              
            // print current thread ID 
            //   Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
           
                RealTimeLogs rtl = new RealTimeLogs();
                rtl.startLog();

            
        }

        public RealTimeLogs()
        {
            listInfo = new List<Info>();
        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 

       
        
        public async void  startLog()
        {
            // Loop who print text with current Thread Id for testing thread. 
            while (flagRtl)
                {
                        RealTimeLogs li = new RealTimeLogs();
                        li.logInfo();
                        
              
                        RealTimeLogs le = new RealTimeLogs();
                        le.logError();
                       
                }
            
        }

        public async Task logInfo()
        {
            
                    using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
                   // create JSON (need to add variable name to replace infos in JSON !) 
                    JsonLog backup = new JsonLog("--- LOG INFO ---",DateTime.Now, "Sample_log.txt [txt]", @".\\LOGS\RealTimeLogs.json", @".\\Sample_log.txt", 10000, 500);
                    string json = JsonConvert.SerializeObject(backup);
                    await file.WriteLineAsync(json);

                
            
        }


        public async Task logError()
        {
                    using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
                    // create JSON (need to add variable name to replace infos in JSON !) 
                    JsonLog backup = new JsonLog("--- LOG ERROR ---",DateTime.Now, "Sample_log.txt [txt]", @".\\LOGS\RealTimeLogs.json", @".\\Sample_log.txt", 10000, 500);
                    string json = JsonConvert.SerializeObject(backup);
                    await file.WriteLineAsync(json);
                  
            }
        }

   
}
