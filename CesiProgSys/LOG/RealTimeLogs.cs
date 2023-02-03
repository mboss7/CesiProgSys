using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using Programm.ToolsBox;

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
         
            // Loop who print text with current Thread Id for testing thread. 
            while (flagRtl)
            {
                
                // if (listInfo.Any(true))  // need to be use for trigg loop
                if(true)
                {
                   
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(@".\\RealTimeLogs.txt");  // change in Json file (when it will be ok). 
                    //Write a line of text
                    sw.WriteLine("Real Time Logs File");
                    //Write a second line of text
                    sw.WriteLine("RealTimeLogs Run : OK");
                    //Close the file
                    sw.Close();
                }
            }
        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 
        public void startLog()
        {
      
        }

        // write new logs infos 
        public void logInfo()
        {

        }
        // write new log errors 
        public void logError()
        {

        }
    }
}
