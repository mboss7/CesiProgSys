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
                while (true)
                {
                    
                 // Connect to the server.
                TcpClient client = new TcpClient("localhost", 12345);
                Console.WriteLine("Connected to the server.");

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                // Send a request to the server.
                byte[] buffer = Encoding.ASCII.GetBytes("Hello, server! Je me connect !");
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Sent: Hello, server!");
                
                // Send a Json to the server :
                
                string text = System.IO.File.ReadAllText(@"Test1.txt");
                
                byte[] bufferJson = Encoding.ASCII.GetBytes(text);
                stream.Write(bufferJson, 0, bufferJson.Length);
                
                //Read the response from the server.
                buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                var data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: {0}", data);
                    
                // write return in doc
                //Open the File
                StreamWriter sw = new StreamWriter(@".\\Test1.txt", true, Encoding.ASCII);
                //Write out the numbers 1 to 10 on the same line.
                sw.Write("\nReceived: {0}", data);
                //close the file
                sw.Close();

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

































