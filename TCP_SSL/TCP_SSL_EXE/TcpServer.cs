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
                    Console.WriteLine("En attente connexion...");  
                    // accepter la connexion du client
                    Socket client = listener.Accept(); 
                    
                    while (true) 
                    {
                        // Data buffer 
                        byte[] bytes = new Byte[1024]; 
                        string data = null; 
      
                        while (true) { 
                            
                            int b = client.Receive(bytes);   
                            data = Encoding.ASCII.GetString(bytes, 0, b); 
                            Console.WriteLine("Texte reçu -> {0} ", data);
                            
                            switch (data)
                            {
                                case "Exit":
                                    byte[] message = Encoding.ASCII.GetBytes("Server OFF");
                                    // Envoyer un message au client 
                                    client.Send(message);
                                    client.Close(); 
                                    break;

                               default:
                                    
                                    break;
                            }
                            
                            byte[] message1 = Encoding.ASCII.GetBytes("Welcome to the easy save app"); 
      
                            //Envoyer un message au client 
                             client.Send(message1);

                            //if (data.IndexOf("<eof>") > -1) 
                             //break; 
                        }
      
                       
      
                        //client.Shutdown(SocketShutdown.Both); 
                        //client.Close(); 
                    }
                    
                    
                }catch (Exception e) { 
                    Console.WriteLine(e.ToString()); 
                } 
            } 
        }
    }
