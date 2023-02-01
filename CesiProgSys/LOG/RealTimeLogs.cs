using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using Programm.ToolsBox;

namespace CesiprogSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        // create list of info object who trigg the thread methode  
        static List<Info> listInfo = new List<Info>();
        public static bool flag = true;


        // start new thread when listInfo is not null  
        public static void startThread()
        {
         //   Console.Write("ON EST LAAAAAAAAAAAAAAAAA\n");
            Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            //if (listInfo != null)
            //{
                // instantiate threadRealTimeLogs = new instantiate();
                // threadRealTimeLogs.start();
            //}
            //else 
            //{
              
            //}
            while (flag)
            {
                
                //if (listInfo.Any())
                if(true)
                {
                    Console.Write("RealTimeLogs {0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                }
            }
        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 
        public void startLog()
        {
            // if (RealTimeLogs == null)
            // {
            //     //Pass the filepath and filename to the StreamWriter Constructor
            //     StreamWriter sw = new StreamWriter("C:\\RealTimeLogs.txt");  // change in Json file (when it will be ok). 
            //     //Write a line of text
            //     sw.WriteLine("Hello World!!");
            //     //Write a second line of text
            //     sw.WriteLine("From the StreamWriter class");
            //     //Close the file
            //     sw.Close();
            // }
            // else 
            // { 
            //
            // }
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
