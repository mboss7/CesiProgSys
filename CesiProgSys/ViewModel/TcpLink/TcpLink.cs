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

    //TCP SERVER LASTONE 

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class TcpLink
    {
        public void ServerTCP()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 12345;
            TcpListener server = new TcpListener(ipAddress, port);

            server.Start();
            Console.WriteLine("Serveur en écoute sur le port " + port);

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Un client s'est connecté.");

            NetworkStream stream = client.GetStream();
            while (true)
            {
                byte[] data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);
                string message = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Message reçu : " + message);

                byte[] responseData = Encoding.ASCII.GetBytes("Bonjour client");
                stream.Write(responseData, 0, responseData.Length);
            }
        }
    }

}