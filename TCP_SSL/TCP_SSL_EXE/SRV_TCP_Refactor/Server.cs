using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


// certif chiffrement  asymétrique en aes : https://learn.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2?view=net-7.0
//

// https://learn.microsoft.com/fr-fr/dotnet/api/system.net.security.sslstream?view=net-7.0

namespace Tcp_Ssl.SRV_TCP_SSL
{
    public class Server
    {
       public async Task RunServer()
        {
            EndPoint ipEndPoint = null;
            using Socket listener = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);

            var handler = await listener.AcceptAsync();
            while (true)
            {
                // Receive message.
                var buffer = new byte[1_024];
                var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
    
                var eom = "<|EOM|>";
                if (response.IndexOf(eom) > -1 /* is end of message */)
                {
                    Console.WriteLine(
                        $"Socket server received message: \"{response.Replace(eom, "")}\"");

                    var ackMessage = "<|ACK|>";
                    var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    await handler.SendAsync(echoBytes, 0);
                    Console.WriteLine(
                        $"Socket server sent acknowledgment: \"{ackMessage}\"");

                    break;
                }
                // Sample output:
                //    Socket server received message: "Hi friends 👋!"
                //    Socket server sent acknowledgment: "<|ACK|>"
            }

        }
    }
}