using System; 
using System.Net; 
using System.Net.Sockets; 
using System.Text; 


namespace Tcp_Ssl
{
    public class TcpServer {
        
            public  void  RunServer()
            {
                // Récupérer le nom de l'hôte
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName()); 
                IPAddress ip = host.AddressList[0]; 
                IPEndPoint endPoint = new IPEndPoint(ip, 9999); 
                // Création du socket TCP/IP
                Socket listener = new Socket(ip.AddressFamily, 
                    SocketType.Stream, ProtocolType.Tcp); 
                try { 
                    // Associer une adresse réseau au socket serveur
                    listener.Bind(endPoint); 
      
                    // Liste de clients qui voudront se connecter au serveur
                    listener.Listen(10); 
                    while (true) { 
                        Console.WriteLine("En attente connexion...");  
                        // accepter la connexion du client
                        Socket client = listener.Accept(); 
      
                        // Data buffer 
                        byte[] bytes = new Byte[1024]; 
                        string data = null; 
      
                        while (true) { 
                            int b = client.Receive(bytes);   
                            data += Encoding.ASCII.GetString(bytes, 0, b); 
                           
                            if (data.IndexOf("<eof>") > -1) 
                                break; 
                        }
      
                        Console.WriteLine("Texte reçu -> {0} ", data); 
                        byte[] message = Encoding.ASCII.GetBytes("Welcome to WayToLearnX"); 
      
                        // Envoyer un message au client 
                        client.Send(message); 
      
                        client.Shutdown(SocketShutdown.Both); 
                        client.Close(); 
                    }
                }catch (Exception e) { 
                    Console.WriteLine(e.ToString()); 
                } 
            } 
        }
    }
