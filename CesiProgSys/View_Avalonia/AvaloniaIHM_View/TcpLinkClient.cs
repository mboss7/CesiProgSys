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

    class TcpLinkClient
    {
        public void tcpClient()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 12345;
            TcpClient client = new TcpClient();

            client.Connect(ipAddress, port);
            Console.WriteLine("Connexion établie avec le serveur.");

            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("Bonjour serveur");
            stream.Write(data, 0, data.Length);

            data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string message = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Message reçu : " + message);

            client.Close();
        }
    }

}

































