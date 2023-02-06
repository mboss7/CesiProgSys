using System;

namespace CesiProgSys.LOG
{
    //interface for Logs 
    public interface ILogs
    {
        public void startLog();
        public void logInfo(string toPrint);
        public void logError(string toPrint);
    }
    
}