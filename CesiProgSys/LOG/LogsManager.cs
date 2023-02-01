using System;
using System.Diagnostics;
using System.Threading;

namespace CesiprogSys.LOG
{
	//mother class for Logs 
	public class LogsManager // : IManager
	{
		// thread list, for managing Thread
		public string threadList;


		// methode for create new thread 
		public void instantiate(string instance)
		{
			// create thread for RealTimeLogs Object
            Thread realTimeLogsThreadStart = new Thread(new ThreadStart(instance.startThread));

            instance.Start();
		}

		// methode for end current thread
		public void finish()
		{
            Thread.Sleep(0);
        }
	}
}


// voir gestion des événements avec OBSERVER !! 