

namespace CesiProgSys.LOG
{
	//mother class for Logs 
	public class LogsManager //: IManager
	{

		public void startLogManager()
		{
			// run new LogsManager Thread
			LogsManager l = new LogsManager();
			l.instantiate();
			// l.finish();
		}
		
		// thread list, for managing Thread
		public List<Thread> threadList;
		// constructor : for thread list
		public LogsManager() {
			threadList = new List<Thread>();
		}
		// methode for create new thread 
		public void instantiate()
		{
			// create thread for RealTimeLogs Object
            Thread instanceRtl = new Thread(RealTimeLogs.startThread);
            //  Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            instanceRtl.Start();
            threadList.Add(instanceRtl);
            
            // create thread for DailyLogs Object
            Thread instanceDl = new Thread(DailyLogs.startThread);
            //  Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            instanceDl.Start();
            threadList.Add(instanceDl);
            
            Thread.Sleep(10);
		}

		// methode for end current thread
		public void finish()
		{
			RealTimeLogs.flagRtl = false;
			
			DailyLogs.flagDl = false;
		}
	}
}


