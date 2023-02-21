using System;
using System.Diagnostics;
using System.ComponentModel;
using DetectLogicielMetier;

namespace TestDetectLogicielMetier
{
    public class TestsDetectProcess
    {
        [Test]
        public void TestProcessDetectorNotRun()
        {
            string processName = "notepad";

            DetectProcess detectProcess = new DetectProcess();

            bool LogicielMetierRunning;
            LogicielMetierRunning = detectProcess.ProcessDetector(processName);




            Assert.That(LogicielMetierRunning.Equals(false));
        }

        [Test]
        public void TestProcessDetectorRun()
        {
            string processName = "notepad";

            Process notePad = Process.Start("notepad");
            DetectProcess detectProcess = new DetectProcess();

            bool LogicielMetierRunning;
            LogicielMetierRunning = detectProcess.ProcessDetector(processName);                    


            Assert.That(LogicielMetierRunning.Equals(true));

            // clean Close notepad: 

            // Nom du processus à rechercher
           
            // Recherche du processus
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                // Terminaison du processus
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
            notePad.Dispose();
        }       
    }
}