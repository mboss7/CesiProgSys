using System;

namespace CesiProgSys.LOG
{
    //interface for Logs 
    public interface ILogs
    {
        public void startLog(string json);
        public void logInfo();
        public void logError();
    }
}