namespace CesiProgSys.Backups
{
    public sealed class BackupManager
    {
        private BackupManager()
        {
            listBackupCheckingAuth = new List<Backup>();
            listBackupReady = new List<Backup>();
            listBackupStarted = new List<Backup>();
            listBackupStoped = new List<Backup>();
        }

        private static BackupManager instance;

        public static BackupManager Instance()
        {
            if (instance == null)
            { 
                instance = new BackupManager(); 
            }
            return instance;
        }

        public List<Backup> listBackupCheckingAuth;
        public List<Backup> listBackupReady;
        public List<Backup> listBackupStarted;
        public List<Backup> listBackupStoped;
        
        public void instantiate(string name, string source, string target, bool type)
        {
            Backup backup;
            if (type)
                backup = new FullBackup(name, source, target);
            else
                backup = new DifferentialBackup(name, source, target);
            
            listBackupReady.Add(backup);
            Thread b = new Thread(startThread);
            b.Start(backup);
        }

        public void startBackup(Backup b)
        {
            listBackupReady.Remove(b);
            b.wait.Set();
            listBackupStarted.Add(b);
        }

        private void finish()
        {
        }

        private static void startThread(object obj)
        {
            Backup backup = (Backup)obj;
            backup.startCheckAuthorizations();
            
            backup.wait.Wait();
            backup.backup();
        }
        
    }
}