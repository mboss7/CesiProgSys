using System;

namespace CesiProgSys.LOG
{
    //interface for Logs 
    public interface ILogs
    {
        public void startLog();
        public void logInfo();
        public void logError();
    }
}