
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;


namespace AvaloniaIHM_View
{

    public class Program
    {
      
        static void Main()
        {
           
            
            
            
                // run TCP CLIENT : 
            TcpLinkClient tcpClientCo = new TcpLinkClient();
            
            tcpClientCo.tcpClient("localhost", 12345);
            
            
            
            
            
            Tuple<NetworkStream, byte[]> ReturnTcpClient = tcpClientCo.tcpClient("localhost", 12345);


            string PathFile1 = @".\\ClientReception.txt";
            
            tcpClientCo.tcpClientSend(ReturnTcpClient, PathFile1);   
            
          


            // Run Avalonia 
        }
    }
}





