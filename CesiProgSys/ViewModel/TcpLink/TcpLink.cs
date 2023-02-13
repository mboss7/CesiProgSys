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
    // Not forget to crypt : https://learn.microsoft.com/fr-fr/dotnet/api/system.net.security.sslstream?view=net-7.0 

    class TcpLink
    {
        int NbConnection;
        string NbConnectionstring;
        public int port;
        private NetworkStream stream; 

        public TcpLink()
        {
            NbConnection = 0;
            NbConnectionstring = "";
            port = 12345;
            stream = null;
        }

        public NetworkStream ServerTCP()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on the specified port.
                server = new TcpListener(IPAddress.Any, port);

                // Start listening for client requests.
                server.Start();
                Console.WriteLine($"\n_____________________________________\n *| Server START on port : {port} |* \n_____________________________________\n");

                // Buffer for reading data.
                byte[] buffer = new byte[1024];
                
              
                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    NbConnection = ++NbConnection;
                    NbConnectionstring = Convert.ToString(NbConnection);
                    
                    Console.WriteLine($" *** Connection number : {NbConnectionstring}***");

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
                           byte[] sendBuffer = Encoding.ASCII.GetBytes("ACK");
                           stream.Write(sendBuffer, 0, sendBuffer.Length);
                           Console.WriteLine("Sent: ACK");

                           
                            //send txt
                            string text = System.IO.File.ReadAllText(@".\\Test1.txt");
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
            return stream; 
        }
        
        
        // Send a Json to the server :
        public void SendJsonToClient(NetworkStream stream)
        {
            string text = System.IO.File.ReadAllText(@".\\ServerReception.txt");
                        
            byte[] bufferJson = Encoding.ASCII.GetBytes(text);
            stream.Write(bufferJson, 0, bufferJson.Length);
            Console.WriteLine("Sent:{0}", bufferJson);
        }                
                                    
    }
}






