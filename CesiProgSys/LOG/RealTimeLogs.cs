using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using CesiProgSys.ToolsBox;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : ILogs
    {
      
            
        public static void ListInfo()
        {
            // Créer une liste 
            List<string> listInfo = new List<string>();
            // Ajouter des éléments à la liste 
            listInfo.Add("Java");
            listInfo.Add("Python");
            listInfo.Add("C#");
            listInfo.Add("PHP");
            listInfo.Add("C++");
            listInfo.Add("SQL");
            Console.WriteLine("Parcourir la liste avec la boucle for-each:");
            foreach (string item in listInfo)
            {
                Console.WriteLine(item);
            }
        }


        public static bool flagRtl = true;
        
       // start new thread when listInfo is not null  
        public static void startThread()
        {
              
            // print current thread ID 
            //   Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
           
                RealTimeLogs rtl = new RealTimeLogs();
                rtl.startLog();

                RealTimeLogs li = new RealTimeLogs();
                li.logInfo();

                RealTimeLogs le = new RealTimeLogs();
                le.logError();
            
        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 
        public async void  startLog()
        {
            // Loop who print text with current Thread Id for testing thread. 
            while (flagRtl)
            {


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
