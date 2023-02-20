
using System.Diagnostics;

namespace DetectLogicielMetier
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ExplorerExecute explorerExecute = new ExplorerExecute();
            
            explorerExecute.ExplorerLaunch();
            
            
            
           /* string processName = "notepad";

            DetectProcess detectProcess = new DetectProcess();
            
            detectProcess.ProcessDetector(processName);*/
            
          
        }
    }
}