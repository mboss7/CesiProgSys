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

    class TcpLink
    {

        public void ServerTCP()
        {

            int port = 12345;

            TcpListener server = null;
            try
            {
                // Set the TcpListener on the specified port.
                server = new TcpListener(IPAddress.Any, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data.
                byte[] buffer = new byte[1024];
                
              
                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    // Get a stream object for reading and writing.
                    NetworkStream stream = client.GetStream();

                    int length;
                    // Read incoming stream into buffer.
                    try
                    {
                        while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            var data = Encoding.ASCII.GetString(buffer, 0, length);
                            Console.WriteLine("Received: {0}", data);
                            
                            // write return in doc
                            //Open the File
                            StreamWriter sw = new StreamWriter(@".\\ServerReception.txt", true, Encoding.ASCII);
                            //Write out the numbers 1 to 10 on the same line.
                            sw.Write(data);
                            //close the file
                            sw.Close();

                            // Send back a response.
                           // byte[] sendBuffer = Encoding.ASCII.GetBytes("ACK");
                          //  stream.Write(sendBuffer, 0, sendBuffer.Length);
                          //  Console.WriteLine("Sent: ACK");
                            
                            // Send a Json to the server :
                
                            string text = System.IO.File.ReadAllText(@".\\ServerReception.txt");
                
                            byte[] bufferJson = Encoding.ASCII.GetBytes(text);
                            stream.Write(bufferJson, 0, bufferJson.Length);
                            Console.WriteLine("Sent:{0}", bufferJson);
                            
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}






