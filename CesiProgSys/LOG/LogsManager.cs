using System;
using System.Diagnostics;
using System.Threading;

namespace CesiprogSys.LOG
{
	//mother class for Logs 
	public class LogsManager // : IManager
	{
		// thread list, for managing Thread
		public List<Thread> threadList;
		// constructor
		public LogsManager() {
			threadList = new List<Thread>();
		}
		// methode for create new thread 
		public void instantiate()
		{
			// create thread for RealTimeLogs Object
            Thread instance = new Thread(RealTimeLogs.startThread);
			
            instance.Start();

			threadList.Add(instance);
		}

		// methode for end current thread
		public void finish()
		{
            // Thread.Stop(0);
        }
	}
}


// voir gestion des événements avec OBSERVER !! 