using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using Avalonia.Rendering;

namespace AvaloniaIHM_View
{

    class TcpLinkClient
    {
        //attributs
        string SrvHostname;
        int Port;
        private string FilePath;
        private NetworkStream stream;
        public byte[] buffer;
        bool LoopTcpClient;

        //constructor
        public TcpLinkClient()
        {
            SrvHostname = "localhost";
            Port = 12345;
            FilePath = @".\\ClientReception.txt";
            stream = null;
            buffer = null;
            LoopTcpClient = true;


        }
        // Methode to connect client to server. Return a tuple with stream and buffer var
        public Tuple<NetworkStream, byte[]>  tcpClient(string SrvHostname, int Port)
        {
            

            try
            {
                while (LoopTcpClient)
                {

                    // Connect to the server.
                    TcpClient client = new TcpClient(SrvHostname, Port);
                    Console.WriteLine("Connected to the server.");

                    // Get a client stream for reading and writing.
                    NetworkStream stream = client.GetStream();

                    // Send a Json to the server :

                    string text = System.IO.File.ReadAllText(@".\\Test1.txt");

                    byte[] bufferJson = Encoding.ASCII.GetBytes(text);
                    stream.Write(bufferJson, 0, bufferJson.Length);



                    // Send a request to the server. For connection
                    byte[] buffer = Encoding.ASCII.GetBytes($"\n Hello, server!");
                    stream.Write(buffer, 0, buffer.Length);


                    try
                    {
                        while (true)
                        {
                            //Read the response from the server.
                            buffer = new byte[1024];
                            int bytesRead = 0;
                            var data = string.Empty;


                            bytesRead = stream.Read(buffer, 0, buffer.Length);
                            data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                            Console.WriteLine("Received: {0}", data);

                            // write return in doc
                            //Open the File
                            StreamWriter sw = new StreamWriter(@".\\ClientReception.txt", true, Encoding.ASCII);
                            //Write out the numbers 1 to 10 on the same line.
                            sw.Write("\nReceived: {0}", data);
                            // close the file
                            sw.Close();
                        }
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                   


                    // Send a request to the server. For connection
                    byte[] bufferEnd = Encoding.ASCII.GetBytes($"\n Bye, server!");
                    stream.Write(bufferEnd, 0, bufferEnd.Length);


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.Message);
            }
            
            
            
            
            return new Tuple<NetworkStream, byte[]>(stream, buffer);
        }

        
        
        
        //tcp sender, to send somthing to the server
        public void tcpClientSend(Tuple<NetworkStream, byte[]> streamAndBuffer,  string FilePath)
        {
            NetworkStream stream = streamAndBuffer.Item1;
            // Send a Json to the server :
                
            string text = System.IO.File.ReadAllText(FilePath);
                
            byte[] bufferJson = Encoding.ASCII.GetBytes(text);
            stream.Write(bufferJson, 0, bufferJson.Length);
        }
       
    }

}

































