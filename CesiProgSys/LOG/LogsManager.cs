using System;
using System.Diagnostics;
using System.Threading;

namespace CesiprogSys.LOG
{
	public class LogsManager // : IManager
	{

		public string threadList;

		public void instantiate()
		{
			// create thread for RealTimeLogs Object
            Thread realTimeLogsThreadStart = new Thread(new ThreadStart(RealTimeLogs.startThread));

            realTimeLogsThreadStart.Start();

            //create thread for DailyLogs Object
            Thread dailyLogsThreadStart = new Thread(new ThreadStart(DailyLogs.startThread));

			dailyLogsThreadStart.Start();
		}

		public void finish()
		{
		
		}
	}
}
