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
            
            try
            {
                
                // Connect to the server.
                TcpClient client = new TcpClient("localhost", 8080);
                Console.WriteLine("Connected to the server.");

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                // Send a request to the server.
                byte[] buffer = Encoding.ASCII.GetBytes("Hello, server! je suis le client et je te parle");
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Sent: Hello, server!");

                while (true)
                {
                    
                    //Read the response from the server.
                    buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    var data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: {0}", data);
                }

            }
            catch (Exception ex)
            {
             
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }

}

































