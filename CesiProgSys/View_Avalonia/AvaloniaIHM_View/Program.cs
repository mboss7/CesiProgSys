
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Collections.Generic;
using System.IO;

namespace AvaloniaIHM_View
{

    public class Program
    {
       // public static extern int SetStdHandle(int device, IntPtr handle); 

        static void Main()
        {
            Console.WriteLine("It's Works ? ");
           // Console.Out.Flush(); 
            // run TCP CLIENT : 
            //TcpLinkClient tcpLinstenok = new TcpLinkClient();

           // tcpLinstenok.tcpClient();

           
           
           // test sortie standard
          // FileStream fileStream = new FileStream("logfile.txt", FileMode.Create);
          // StreamWriter streamwriter = new StreamWriter(fileStream);
           
          // Console.SetOut(streamwriter);

          // IntPtr handle;
          // handle = fileStream.Handle;

          // int status = SetStdHandle(-11, handle);
           

           Console.WriteLine("It's Works ! ");
            Console.ReadLine();


            // Run Avalonia 






        }
    }
}





