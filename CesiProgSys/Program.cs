
using CesiProgSys.ToolsBox;
using CesiProgSys.LOG;

namespace CesiProgSys
{
   
        
        public class LOGS
        {
            public static void Main()
            {
                // run new LogsManager Thread
                LogsManager l = new LogsManager();
                l.instantiate();
                l.finish();
           
                static void MainC(string[] args)
                {
                    Zip z = new Zip();
                    z.compressed(args[0], args[1]);
               }

            }
        }
    }




  
