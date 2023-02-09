
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Collections.Generic;

namespace AvaloniaIHM_View
{

    public class Program
    {

        static void Main()
        {
            Console.WriteLine("It's Works ? ");
          
            // run TCP CLIENT : 
            TcpLinkClient tcpLinstenok = new TcpLinkClient();

            tcpLinstenok.tcpClient();

            Console.WriteLine("It's Works ! ");
            Console.ReadLine();


            // Run Avalonia 






        }
    }
}





