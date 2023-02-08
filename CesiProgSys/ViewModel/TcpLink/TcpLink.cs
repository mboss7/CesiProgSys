using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Reflection.PortableExecutable;

namespace CesiProgSys.ViewModel.TcpIp
{
    // TCP SRV in TCP Listener 
    public class TcpLink
    {
        // Attributs
        int port;
        string ipAddress;



        // Constructor
        public TcpLink()
        {
            port = 0;
            ipAddress = "127.0.0.1";

        }

        // Methodes 
        public async void TcpListenerLink(string ipAddress, int port)
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            TcpListener listener = new(ipEndPoint);

            Console.Write("Listen port : " );
            Console.Write(port);
            Console.Write("\n ----------------------------- \n");
            
            try
            {
                listener.Start();

                using TcpClient handler = await listener.AcceptTcpClientAsync();
                await using NetworkStream stream = handler.GetStream();

                var message = $"📅 {DateTime.Now} 🕛";
                var dateTimeBytes = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(dateTimeBytes);

                
                Console.WriteLine($"Sent message: \"{message}\"");
                // Sample output:
                //     Sent message: "📅 8/22/2022 9:07:17 AM 🕛"
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}


