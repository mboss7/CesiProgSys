
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;

namespace AvaloniaIHM_View
{

    public class Program
    {

        static void Main()
        {

            // run TCP CLIENT : 
            TcpLinkClient tcpLinstenok = new TcpLinkClient();

            tcpLinstenok.TcpClientLink("127.0.0.1", 8080);

            Console.WriteLine("It's Works ! ");
            Console.ReadLine();


            // Run Avalonia 






        }
    }
}





