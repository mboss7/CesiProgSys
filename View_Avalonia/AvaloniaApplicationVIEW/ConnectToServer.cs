using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace AvaloniaIHM_View
{
    public class ConnectToServer
    {
        public void ConnectionServer()
        {
            // Connect to the server.
            TcpClient client = new TcpClient("localhost", 12345);
            Console.WriteLine("Connected to the server.");

            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();
        }
     
    }
}