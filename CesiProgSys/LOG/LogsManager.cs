using System;
using System.Diagnostics;
using System.Threading;

namespace CesiprogSys.LOG
{
	public class LogsManager // : IManager
	{

		public string threadList;

		public void instantiate(string instance)
		{
			// create thread for RealTimeLogs Object
            Thread realTimeLogsThreadStart = new Thread(new ThreadStart(instance.startThread));

            instance.Start();
		}

		public void finish()
		{
            Thread.Sleep(0);
        }
	}
}
