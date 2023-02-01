using System;
using System.Diagnostics;
using System.Threading;

namespace CesiProgSys.LOG
{
	//mother class for Logs 
	public class LogsManager // : IManager
	{
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
            Thread instance = new Thread(RealTimeLogs.startThread);
            Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            instance.Start();
            //Console.Write("Le premier QUI CONTINUE {0}\n", Thread.CurrentThread.ManagedThreadId);
			threadList.Add(instance);
		}

		// methode for end current thread
		public void finish()
		{
			RealTimeLogs.flag = false;
		}
	}
}


// voir gestion des événements avec OBSERVER !! 