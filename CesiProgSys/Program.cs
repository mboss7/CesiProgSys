using CesiProgSys.LOG;


namespace Programm
{
    public class Program
    {
        public static void Main()
        {
            // run new LogsManager Thread
            LogsManager l = new LogsManager();
            l.instantiate();
            
            // sleep 10 sec et finish le Thread LogsManager
            Thread.Sleep(10000);
            l.finish();
           
        }
    }
}


