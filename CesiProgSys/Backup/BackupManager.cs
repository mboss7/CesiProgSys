namespace CesiProgSys.Backup
{
    public sealed class BackupManager
    {
        private BackupManager()
        {
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
        
        public Thread instantiate(bool typeBackup)
        {
            Thread temp;
            if (typeBackup)
            {
                temp = new Thread(DifferentialBackup.startThread);
            }
            else
            {
                temp = new Thread(FullBackup.startThread);
            }

            temp.Start();

            return temp;
        }

        public void start(IBackup b)
        {
            b.setFlagAuth();
            b.setFlagStart();
        }
        private void finish(Thread t)
        {
            t.Interrupt();
        }
    }
}