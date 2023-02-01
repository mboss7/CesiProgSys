using System;

namespace CesiprogSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        List<info> listInfo = new List<info>(); 
        

        public void  startThread()
        {
            if (listInfo != null)
            {
                instanciate threadRealTimeLogs = new instanciate();
                threadRealTimeLogs.start();
            }
            else
            {
                finish a = new finish ();
            }
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
