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
            using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
            await file.WriteLineAsync(toPrint);

        }


        public async Task logError(string toPrint)
        {
                    using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
                    await file.WriteLineAsync(toPrint);
                  
            }
        }

   
}
