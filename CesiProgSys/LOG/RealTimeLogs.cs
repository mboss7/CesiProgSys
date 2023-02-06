using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using CesiProgSys.ToolsBox;
using Newtonsoft.Json;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        // create list of info object who trigg the thread methode  
        static List<Info> listInfo = new List<Info>();
        public static bool flagRtl = true;

       

        // start new thread when listInfo is not null  
        public static void startThread()
        {
        
            // print current thread ID 
           Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);

           RealTimeLogs rtl = new RealTimeLogs();
           rtl.startLog();
           
           RealTimeLogs li = new RealTimeLogs(); 
           li.logInfo();

           RealTimeLogs le = new RealTimeLogs(); 
           le.logError();
           
        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 
        public void startLog()
        {
            // Loop who print text with current Thread Id for testing thread. 
            while (flagRtl)
            {

                // if (listInfo.Any(true))  // need to be use for trigg loop
                if (true)
                {
                    // value Date time
                    DateTime today = DateTime.Now;
                    //Pass the filepath and filename to the StreamWriter Constructor

                    StreamWriter
                        sw = new StreamWriter(
                            @".\\LOGS\RealTimeLogs.json"); // change in Json file (when it will be ok). 
                    //Write a line of text
                    sw.WriteLine("Real Time Logs File");
                    // write date and time in Logs file
                    sw.WriteLine(today);
                    //Write a second line of text
                    sw.WriteLine("RealTimeLogs Run : OK");


                    // create JSON (need to add variable name to replace infos in JSON !) 
                    JsonLog backup = new JsonLog(DateTime.Now, "Sample_log.txt [txt]", @".\\LOGS\RealTimeLogs.json",
                        @".\\Sample_log.txt", 10000, 500);
                    string json = JsonConvert.SerializeObject(backup);
                    sw.WriteLine(json);


                    //Close the file
                    sw.Close();
                }
                else
                {
                    
                }
            
        }
        }

      public async Task logInfo()
      {
         using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
         await file.WriteLineAsync("Fourth line");
      }
      

        public void logError()
        {

        }
    }
}
