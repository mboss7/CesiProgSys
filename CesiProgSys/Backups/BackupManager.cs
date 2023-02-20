namespace CesiProgSys.Backups
{
    public sealed class BackupManager
    {
        private BackupManager()
        {
            listBackupInstantiated = new List<Backup>();
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

        public List<Backup> listBackupInstantiated;
        public List<Backup> listBackupStarted;
        public List<Backup> listBackupStoped;
        
        public Backup instantiate(string name, string source, string target, bool type)
        {
            Backup backup;
            if (type)
                backup = new FullBackup(name, source, target);
            else
                backup = new DifferentialBackup(name, source, target);
            
            listBackupInstantiated.Add(backup);
            Thread b = new Thread(startThread);
            b.Start(backup);

            return backup;
        }

        public void startBackup(Backup b)
        {
            listBackupInstantiated.Remove(b);
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