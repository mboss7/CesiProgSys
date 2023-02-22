using System;
using System.Diagnostics;


namespace DetectLogicielMetier;

public class ExplorerExecute
{

    public void  ExplorerLaunch()
    {

       
            // Créer un objet ProcessStartInfo pour configurer le processus
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "explorer.exe";
            startInfo.Arguments = "/select";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            // Lancer le processus
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();


            bool explorerIsRunning = true;

            while (explorerIsRunning)
            {
                // Récupérer la sortie
                string output = process.StandardOutput.ReadToEnd();

                // Afficher la sortie dans la console
                Console.WriteLine("output :"+output);
            
                // Récupérer tous les processus actifs
                Process[] processes = Process.GetProcesses();
                
                foreach (Process p in processes) 
                {
                    Console.WriteLine(p.ProcessName);
                    if (p.ProcessName.Contains("explorer"))
                    {
                        explorerIsRunning = true;
                
                        break;
                    }
                    else
                    {
                        explorerIsRunning = false;
                        
                        
                    }
                }
            }
    }
}
