using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;

namespace CesiprogSys.LOG
{
    public class DailyLogs : ILogs
    {

        // start new thread
        public void startThread()
        {
            instanciate daylyLogsThread = new instanciate();
            daylyLogsThread.start();
        }

        // Create new start log info 
        public void startLog()
        {
            //create log file
            // write start Log info in Json log file. 
            
        }
        // write new logs infos 
        public void logInfo()
        {
            // write log info in Json Log file
        }
        // write new logs errors 
        public void logError()
        {
            // write log error in Json Log file
        }
    }
}