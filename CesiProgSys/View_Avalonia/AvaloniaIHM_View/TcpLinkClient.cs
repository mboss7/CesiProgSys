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
    // Tcp client 
    internal class TcpLinkClient
    {
        public string ipAddress;
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


        public async void TcpClientLinkSocket(string ipAddress, int port)
        {
            // second part 

            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
           // using var client = new TcpClient(endPoint);                  

            using Socket client1 = new(endPoint.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
                    



           // await client.ConnectAsync(ipAddress,port);
            while (true)
            {
                // Send message.
                var message1 = "Hi friends 👋!<|EOM|>";
                var messageBytes1 = Encoding.UTF8.GetBytes(message1);
                _ = await client1.SendAsync(messageBytes1, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message1}\"");

                // Receive ack.
                var buffer1 = new byte[1_024];
                var received1 = await client1.ReceiveAsync(buffer1, SocketFlags.None);
                var response1 = Encoding.UTF8.GetString(buffer1, 0, received1);
                if (response1 == "<|ACK|>")
                {
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response1}\"");
                    break;
                }
                // Sample output:
                //     Socket client sent message: "Hi friends 👋!<|EOM|>"
                //     Socket client received acknowledgment: "<|ACK|>"
            }

           // client.Shutdown(SocketShutdown.Both);
        


        }
    }
}    

