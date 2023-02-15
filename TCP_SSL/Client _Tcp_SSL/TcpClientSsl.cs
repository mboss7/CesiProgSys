using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tcp_Ssl
{
    public class TcpClientSsl
    {
        public void TcpClientRun()
        {
            try
            {
                // Établir une connexion sur le Port 9999 
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ip = host.AddressList[0];
                IPEndPoint endPoint = new IPEndPoint(ip, 9999);

                // Créer une socket TCP/IP 
                Socket client = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    
                        // Connect Socket 
                        client.Connect(endPoint);
                        
                        while (true)
                        {
                        // le message à envoyer au serveur
                        Console.WriteLine("Please enter text for the server :");
                        string messageForServer = Console.ReadLine();

                        byte[] msg = Encoding.ASCII.GetBytes(messageForServer);
                        int byteSent = client.Send(msg);



                        // Data buffer 
                        byte[] messageReceived = new byte[1024];

                        // Recevoir le message 
                        int byteRecv = client.Receive(messageReceived);
                        Console.WriteLine("Message du serveur -> {0}",
                            Encoding.ASCII.GetString(messageReceived, 0, byteRecv));
                        //client.Shutdown(SocketShutdown.Both); 
                        //client.Close(); 
                    }
                }
                catch (SocketException e1)
                {
                    Console.WriteLine("SocketException : {0}", e1.ToString());
                }
                catch (ArgumentNullException e2)
                {
                    Console.WriteLine("ArgumentNullException : {0}", e2.ToString());
                }
                catch (Exception e3)
                {
                    Console.WriteLine("Unexpected exception : {0}", e3.ToString());
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}