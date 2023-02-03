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
            Console.Write("BackupManager, Backgound : {0} Thread Pool  : {1} Thread ID : {2} \n", Thread.CurrentThread.IsBackground, Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
            threadList[0].Start();
        }

        private void finish()
        {
            
        }
    }
}