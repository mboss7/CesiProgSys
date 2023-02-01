using System;

namespace CesiprogSys.LOG
{
    //interface for Logs 
    public interface ILogs
    {
        public void startThread();
        public void startLog();
        public void logInfo();
        public void logError();
    }
}