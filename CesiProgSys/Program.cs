using System;  
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading;
using CesiProgSys.Backup;

namespace CesiProgSys
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Main, Backgound : {0} Thread Pool  : {1} Thread ID : {2} \n", Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.ManagedThreadId);
            BackupManager b = new BackupManager();
            b.instantiate("truc");
            // b.instantiate();
            // Console.ReadLine();
        }
    }
}