namespace CesiProgSys.Backup
{
    public class BackupManager
    {

        private List<Thread> threadList { get; set; }

        public BackupManager()
        {
            threadList = new List<Thread>();
        }
        
        public void instantiate(string name)
        {
            Thread temp = new Thread(FullBackup.startThread);
            temp.Name = name;
            
            threadList.Add(temp);
            temp.Start();
        }

        private void finish()
        {
            
        }
    }
}