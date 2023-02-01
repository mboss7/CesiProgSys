using System;
using System.Text.Json.Nodes;
using System.Threading;

namespace CesiprogSys.LOG
{
    public class DailyLogs : ILogs
    {
      
        public void startThread()
        {
            instanciate daylyLogsThread = new instanciate();
            daylyLogsThread.start();
        }
        public void startLog()
        {
            //create log file
            // write start Log info in Json log file. 
            
        }
        public void logInfo()
        {
            // write log info in Json Log file
        }
        public void logError()
        {
            // write log error in Json Log file
        }
    }
}