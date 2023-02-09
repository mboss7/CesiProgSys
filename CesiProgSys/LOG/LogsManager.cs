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
		}
		
		// methode for create new thread 
		public void instantiate()
		{
            Thread instanceRtl = new Thread(RealTimeLogs.startThread);
            instanceRtl.Start();
            
            Thread instanceDl = new Thread(DailyLogs.startThread);
            instanceDl.Start();
		}

		// methode for end current thread
		public void finish()
		{
		}
	}
}