using System;

namespace CesiprogSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        List<info> listInfo = new List<info>(); 

        public static void  startThread()
        {
            instanciate threadRealTimeLogs = new instanciate();
            threadRealTimeLogs.start();
        }
        public void startLog()
        {
            
        }
        public void logInfo()
        {

        }
        public void logError()
        {

        }
    }
}
