using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;

namespace CesiprogSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        // create list of info object who trigg the thread methode  
        static List<info> listInfo = new List<info>(); 
        


        // start new thread when listInfo is not null  
        public void  startThread()
        {
            if (listInfo != null)
            {
                instanciate threadRealTimeLogs = new instanciate();
                threadRealTimeLogs.start();
            }
            else 
            {
              
            }
        }

        // Create new start log info  // Morever when need to call a Json methode to factor data in JSON. 
        public void startLog()
        {
            if (RealTimeLogs == null)
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\RealTimeLogs.txt");  // change in Json file (when it will be ok). 
                //Write a line of text
                sw.WriteLine("Hello World!!");
                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");
                //Close the file
                sw.Close();
            }
            else 
            { 

            }
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
