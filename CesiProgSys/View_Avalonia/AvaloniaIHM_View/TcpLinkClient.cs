using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace AvaloniaIHM_View
{
    // Tcp client 
    internal class TcpLinkClient
    {
        string ipAddress;
        int port;
        


        // Constructor 
        public TcpLinkClient()
        {
         ipAddress = "127.0.0.1";
         port = 0;
        }


        public async void TcpClientLink(string ipAddress, int port)
        {
            Console.WriteLine(ipAddress, port);
            using TcpClient client = new();
            await client.ConnectAsync(ipAddress, port);
            await using NetworkStream stream = client.GetStream();

            var buffer = new byte[1_024];
            int received = await stream.ReadAsync(buffer);

            var message = Encoding.UTF8.GetString(buffer, 0, received);
            Console.WriteLine($"Message received: \"{message}\"");
         }
    }
}    

