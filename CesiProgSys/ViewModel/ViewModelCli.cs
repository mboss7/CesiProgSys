using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using CesiProgSys.Backups;

namespace CesiProgSys.ViewModel
{
    public class ViewModelCli
    {
        // public static List<Tuple<Thread, string[]>> ouahMonCerveauEstPartiLoin;
        // public static List<Tuple<Thread, IBackup>> marre;
        
        // public static Mutex mutex = new Mutex();

        // public static List<string[]> targetAndSource;
        
        public ViewModelCli()
        {
            bManager = BackupManager.Instance();
            // ouahMonCerveauEstPartiLoin = new List<Tuple<Thread, string[]>>();
            // marre = new List<Tuple<Thread, IBackup>>();
            // targetAndSource = new List<string[]>();
        }

        private BackupManager bManager;

        public string? name;
        public string? sourceDir;
        public string? targetDir;
        
        public void instantiateFullBackup()
        {
            FullBackup fullBackup = new FullBackup(name, sourceDir, targetDir);
            bManager.instantiate(fullBackup);
            bManager.check(fullBackup);
            // mutex.WaitOne(); 
            // Tuple<Thread, string[]> temp = new Tuple<Thread, string[]>(bManager.instantiate(false), new[] { name, sourceDir, targetDir });
            // ouahMonCerveauEstPartiLoin.Add(temp);
            // Thread.Sleep(50);
            // marre.Find(tuple => tuple.Item1 == temp.Item1).Item2.blockMutex();
            // mutex.ReleaseMutex();
            //
            //
            name = null;
            sourceDir = null;
            targetDir = null;
        }

        public List<Backup> getBackups()
        {
            return bManager.listBackup;
        }

        public void startBackup(Backup backup)
        {
            bManager.start(backup);
            
            // IBackup b = marre.Find(tuple => tuple.Item1.Name == name).Item2;
            //
            // bManager.start(b);
        }
        
        public void instantiateDiffBackup()
        {
            // mutex.WaitOne(); 
            // Tuple<Thread, string[]> temp = new Tuple<Thread, string[]>(bManager.instantiate(true), new[] { name, sourceDir, targetDir });
            // ouahMonCerveauEstPartiLoin.Add(temp);
            // Thread.Sleep(50);
            // marre.Find(tuple => tuple.Item1 == temp.Item1).Item2.blockMutex();
            // mutex.ReleaseMutex();
            //
            // name = null;
            // sourceDir = null;
            // targetDir = null;
        }

        // public List<string> getThreadsNames()
        // {
        //     List<string> toReturn = new List<string>();
        //     // foreach (Tuple<Thread, IBackup> t in marre)
        //     // {
        //     //     toReturn.Add(t.Item1.Name);
        //     // }
        //     //
        //     return toReturn;
        // }


    }  
}