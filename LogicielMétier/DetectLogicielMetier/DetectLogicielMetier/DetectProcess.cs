using System.Diagnostics;

namespace DetectLogicielMetier;

public class DetectProcess
{

    public static bool LogicielMetierRunning;

    public DetectProcess()
    {
        LogicielMetierRunning = false;
    }
    
    public bool ProcessDetector()
    {
        // Récupérer tous les processus actifs
        Process[] processes = Process.GetProcesses();

        // Afficher le nom de chaque processus actif
        foreach (Process p in processes) {
            Console.WriteLine(p.ProcessName);
            if (p.ProcessName == "notepad")
            {
                LogicielMetierRunning = true;
                
                break;
            }
        }


        if (LogicielMetierRunning)
        {
            Console.WriteLine("\n *** Logiciel Metier is running !!! STOP *** \n " + LogicielMetierRunning);
            return true;
        }
        else
        {
            Console.WriteLine("\n *** Logiciel Metier is not running *** \n " + LogicielMetierRunning);
            return false;
        }
        
    }
}