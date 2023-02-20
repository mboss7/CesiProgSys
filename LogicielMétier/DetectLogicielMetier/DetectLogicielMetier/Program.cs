
namespace DetectLogicielMetier
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string processName = "notepad";

            DetectProcess detectProcess = new DetectProcess();
            
            detectProcess.ProcessDetector(processName);
        }
    }
}