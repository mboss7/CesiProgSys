using CesiProgSys.Backup;

using CesiProgSys.LOG;

namespace CesiProgSys
{
   
        
        class Program
        {
            static void Main(string[] args)
            {
                // run new LogsManager Thread
                DateTime date = DateTime.Now;
                BackupManager b = new BackupManager();
                b.instantiate("truc");
                b.instantiate("machin");
               LogsManager l = new LogsManager();
               l.startLogManager();
               //
               //  static void MainC(string[] args)
               //  {
               //      Zip z = new Zip();
               //      z.compressed(args[0], args[1]);
               // }
                
                // Console.ReadLine();
                Thread.Sleep(500);
                l.finish();
                DateTime date2 = DateTime.Now;
                Console.WriteLine(date2 - date);
            }
        }
    }




  
