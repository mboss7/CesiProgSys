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
        int port;
        long ipAddress;
       // private static object client;


        //string Client;

        public TcpLink(int port, long ipAddress) 
        {
            port = 0;
            ipAddress = "127.0.0.1";
        }


        public async void TcpListenerLink()
        {

            var ipEndPoint = new IPEndPoint(ipAddress, 13);

            using TcpClient client = new();
            await client.ConnectAsync(ipEndPoint);
            await using NetworkStream stream = client.GetStream();

            var buffer = new byte[1_024];
            int received = await stream.ReadAsync(buffer);

            var message = Encoding.UTF8.GetString(buffer, 0, received);
            Console.WriteLine($"Message received: \"{message}\"");
            
        }
    }
}

