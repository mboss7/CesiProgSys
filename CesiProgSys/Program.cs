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
            BackupManager b = new BackupManager();
            b.instantiate("truc");
            Console.ReadLine();
        }
    }
}