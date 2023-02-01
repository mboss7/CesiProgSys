namespace CesiProgSys.Backup
{
    public class FullBackup : IBackup
    {
        public static void startThread()
        {
            Console.Write("FullBackup, Backgound : {0} Thread Pool  : {1} Thread ID : {2} \n", Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.ManagedThreadId);
        }

    }
}