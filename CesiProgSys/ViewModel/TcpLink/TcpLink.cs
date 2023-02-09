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

            Console.Write("Listen port : ");
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



        public void TcpListenerLinkSocket(int port)
            {
                // TcpListener Socket : https://learn.microsoft.com/fr-fr/dotnet/fundamentals/networking/sockets/tcp-classes

                //var listener = new TcpListener(IPAddress.Loopback, 5000);
                //var ep = new IPEndPoint(IPAddress.Loopback, 5000);
                //using var socket = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Console.Write("Listen port : ");
                Console.Write(port);
                Console.Write("\n ----------------------------- \n");
                
                var listener = new TcpListener(IPAddress.Loopback, port);
                listener.Start(10);

                var endPoint = new IPEndPoint(IPAddress.Loopback, 5000);
                using var socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(endPoint);
                try
                {
                    socket.Listen(10);
                   
                }
                catch (SocketException)
                {
                    socket.Dispose();
                }



            }
        }
    }



