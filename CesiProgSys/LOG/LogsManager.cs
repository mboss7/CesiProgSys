namespace CesiProgSys.LOG
{
	//mother class for Logs 
	public class LogsManager //: IManager
	{
		private LogsManager(){}
		private static LogsManager instance;

		public static LogsManager Instance()
		{
			if (instance == null)
			{
				instance = new LogsManager();
			}

			return instance;
		}

		// methode for create new thread 
		public void instantiate()
		{
            Thread threadRtl = new Thread(startThread);
            threadRtl.Start(RealTimeLogs.Instance());
            
            Thread threadDl = new Thread(startThread);
            threadDl.Start(DailyLogs.Instance());
		}

		// methode for end current thread
		public void finish()
		{
			
		}

		private static void startThread(object obj)
		{
			Logs logs = (Logs)obj;
			logs.startLog();
			while(true)
			{
				logs.wait.Wait();
				logs.writeLogs();
				logs.wait.Reset();
			}
		}
	}
}