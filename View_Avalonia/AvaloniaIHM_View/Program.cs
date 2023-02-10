
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
      
        static void Main()
        {
            Console.WriteLine("It's Works ? ");
           // run TCP CLIENT : 
            TcpLinkClient tcpLinstenok = new TcpLinkClient();
            tcpLinstenok.tcpClient("localhost", 12345);

            Console.WriteLine("It's Works ! ");
            Console.ReadLine();


            // Run Avalonia 
        }
    }
}





