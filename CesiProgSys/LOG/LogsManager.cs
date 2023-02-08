

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
		
		// methode for create new thread 
		public void instantiate()
		{
			// create thread for RealTimeLogs Object
            Thread instanceRtl = new Thread(RealTimeLogs.startThread);
            //  Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            instanceRtl.Start();
            
            // create thread for DailyLogs Object
            Thread instanceDl = new Thread(DailyLogs.startThread);
            //  Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            instanceDl.Start();
		}

		// methode for end current thread
		public void finish()
		{
			RealTimeLogs.flagRtl = false;
			
			DailyLogs.flagDl = false;
		}
	}
}


