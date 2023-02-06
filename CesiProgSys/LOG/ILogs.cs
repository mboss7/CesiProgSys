using System;

namespace CesiProgSys.LOG
{
    //interface for Logs 
    public interface ILogs
    {
        public void startLog();
        public Task logInfo();
        public Task logError();
    }
}