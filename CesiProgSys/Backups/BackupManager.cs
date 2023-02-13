namespace CesiProgSys.Backups
{
    public sealed class BackupManager
    {
        private BackupManager()
        {
            listBackup = new List<Backup>();
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

        public List<Backup> listBackup;
        
        public void instantiate(Backup backup)
        {
            listBackup.Add(backup);
            backup.initiateBackup();
            // Thread b = new Thread(startThread);
            // b.Start(backup);
        }

        public void check(Backup b)
        {
            b.OnCheckAuth();
        }

        public void start(Backup b)
        {
            b.OnStartBackup();
        }
        
        private void finish(Thread t)
        {
            // t.Interrupt();
        }

        // private static void startThread(object o)
        // {
            
        // }
        
    }
}