using System.Diagnostics;

namespace DetectLogicielMetier;

public class DetectProcess
{

    public static bool LogicielMetierRunning;
    public static string processName;

    public DetectProcess()
    {
        LogicielMetierRunning = false;
        processName = "notepad";

    }
    
    public bool ProcessDetector(string processName)
    {
        // Récupérer tous les processus actifs
        Process[] processes = Process.GetProcesses();

        // Afficher le nom de chaque processus actif
        foreach (Process p in processes) {
            Console.WriteLine(p.ProcessName);
            if (p.ProcessName == processName)
            {
                LogicielMetierRunning = true;
                
                break;
            }
        }


        if (LogicielMetierRunning)
        {
            Console.WriteLine("\n *** Logiciel Metier is running !!! STOP *** \n " + LogicielMetierRunning);
            
        }
        else
        {
            Console.WriteLine("\n *** Logiciel Metier is not running *** \n " + LogicielMetierRunning);
            
        }

        return LogicielMetierRunning;
    }
}