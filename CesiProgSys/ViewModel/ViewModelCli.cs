using System.ComponentModel;
using System.Runtime.CompilerServices;
using CesiProgSys.Backup;
using CesiProgSys.ViewCli;

namespace CesiProgSys.ViewModel
{
    public class ViewModelCli
    {

        public static List<Tuple<Thread, string[]>> ouahMonCerveauEstPartiLoin;
        public static List<Tuple<Thread, IBackup>> marre;
        public static Mutex mutex = new Mutex();
        
        
        public ViewModelCli()
        {
            bManager = BackupManager.Instance();
            ouahMonCerveauEstPartiLoin = new List<Tuple<Thread, string[]>>();
            marre = new List<Tuple<Thread, IBackup>>();
        }

        private BackupManager bManager;

        public string? name;
        public string? sourceDir;
        public string? targetDir;
        
        public void instantiateFullBackup()
        {
            
            ouahMonCerveauEstPartiLoin.Add(new Tuple<Thread, string[]>(bManager.instantiate(false), new[]{name, sourceDir, targetDir}));
            name = null;
            sourceDir = null;
            targetDir = null;
        }

        public void startBackup(string name)
        {
            IBackup b = marre.Find(tuple => tuple.Item1.Name == name).Item2;
            
            bManager.start(b);
        }
        
        public void instantiateDiffBackup()
        {
            mutex.WaitOne();
            ouahMonCerveauEstPartiLoin.Add(new Tuple<Thread, string[]>(bManager.instantiate(true), new[]{name, sourceDir, targetDir}));
            mutex.ReleaseMutex();
            name = null;
            sourceDir = null;
            targetDir = null;
        }

        public List<string> getThreadsNames()
        {
            List<string> toReturn = new List<string>();
            foreach (Tuple<Thread, IBackup> t in marre)
            {
                toReturn.Add(t.Item1.Name);
            }

            return toReturn;
        }
    }  
}