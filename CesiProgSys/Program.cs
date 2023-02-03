
using CesiProgSys.ToolsBox;
using CesiProgSys.LOG;

namespace CesiProgSys
{
    class Program
    {
        
        
        public class LOGS
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
        static void MainC(string[] args)
        {
            Zip z = new Zip();
            z.compressed(args[0], args[1]);
            // JsonLog test = new JsonLog();
            
        }
        
    }
}



  
