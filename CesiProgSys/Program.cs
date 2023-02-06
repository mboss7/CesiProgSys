using System;  
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading;
using CesiProgSys.Backup;

using CesiProgSys.ToolsBox;
using CesiProgSys.LOG;

namespace CesiProgSys
{
   
        
        class Program
        {
            static void Main(string[] args)
            {
                // run new LogsManager Thread
               LogsManager l = new LogsManager();
               l.startLogManager();
               //
               //  static void MainC(string[] args)
               //  {
               //      Zip z = new Zip();
               //      z.compressed(args[0], args[1]);
               // }
            //   BackupManager b = new BackupManager();
           //    b.instantiate("truc");
           //    Console.ReadLine();

            }
        }
    }




  
