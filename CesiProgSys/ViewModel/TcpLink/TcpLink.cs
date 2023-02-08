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
            Console.WriteLine(ipAddress, port);
            using tcpclient client = new();
            await client.connectasync(ipaddress, port);
            await using networkstream stream = client.getstream();

            var buffer = new byte[1_024];
            int received = await stream.readasync(buffer);

            var message = encoding.utf8.getstring(buffer, 0, received);
            console.writeline($"message received: \"{message}\"");

        }
    }
}
