using System.ComponentModel;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Reflection.Metadata;
using CesiProgSys.ToolsBox;

namespace Tcp_Ssl
{
    public class TcpServer
    {
        
        public static bool isRunning = false;
        public SslStream sslStream;
        
        /// <summary>
        /// For Run SRV SSL main Method
        /// </summary>
        public void RunSrv(int port)
        {
            TcpServer tcpServer = new TcpServer();
            isRunning = true;
            tcpServer.SslTcpServerConnection(port);
            

        }

        /// <summary>
        /// Connect the server in listen mode in SSL 
        /// </summary>
        public SslStream SslTcpServerConnection(int port)
        {

            bool FlagA = true;
            bool FlagB = true;

            while (FlagA)
            {

                X509Certificate serverCertificate = new X509Certificate(@"cert.pfx", "P@ssw0rd");
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Waiting for a client to connect...");
                // Application blocks while waiting for an incoming connection.
                // Type CNTL-C to terminate the server.
                using TcpClient client = listener.AcceptTcpClient();
                sslStream = new SslStream(client.GetStream(), false);
                sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, true);
                Console.WriteLine("*** Client Connected ***");
                // Write a message to the client.
                byte[] message1 = Encoding.UTF8.GetBytes("*** Server Connected ***");
                
                try
                {
                    sslStream.Write(message1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }



                // boucle d'écoute du serveur
                while (FlagB)
                {

                    string messageData = null;

                    try
                    {
                        messageData = ReadMessage(sslStream);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("-- Connection Aborted --");
                        listener.Stop();
                        SslTcpServerConnection(port).Dispose();
                        FlagB = false;
                    }

                    Console.WriteLine("Received: {0}", messageData);


                    // condition for event to send message to client : EventHAndler : 
                    // Write a message to the client.
                    byte[] message = Encoding.UTF8.GetBytes("Hello from the server.<EOF>");
                    Console.WriteLine("Sending hello message.");
                    try
                    {
                        sslStream.Write(message);
                    }
                    // If problem of connection End the Listener and Dispose the SslTcp fct for free the RAM Memory
                    catch (IOException e)
                    {
                        Console.WriteLine("-- Connection aborted --");
                        listener.Stop();
                        SslTcpServerConnection(port).Dispose();
                        FlagB = false;
                    }               

                }
            }
            return sslStream;
        }


        static string ReadMessage(SslStream sslStream)
            {
                // Read the  message sent by the client.
                // The client signals the end of the message using the
                // "<EOF>" marker.
                byte[] buffer = new byte[2048];
                StringBuilder messageData = new StringBuilder();
                int bytes = -1;
                do
                {

                    // Read the client's test message.
                    bytes = sslStream.Read(buffer, 0, buffer.Length);



                    // Use Decoder class to convert from bytes to UTF8
                    // in case a character spans two buffers.
                    Decoder decoder = Encoding.UTF8.GetDecoder();
                    char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                    decoder.GetChars(buffer, 0, bytes, chars, 0);
                    messageData.Append(chars);
                    // Check for EOF or an empty message.
                    if (messageData.ToString().IndexOf("<EOF>") != -1)
                    {
                        break;
                    }
                } while (bytes != 0);

                return messageData.ToString();
            }
            


        /// <summary>
        /// Send to the client the infos when change is notify with property change
        /// </summary>
        /// <param name="sslStream"></param>
        /// <param name="messageOnpropertyChange"></param>
            public void OnSendMessage(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
            {
            // Récupération de l'objet qui a déclenché l'événement
                Info info = (Info)sender;


            // Récupération des données de l'événement
                string messageOnpropertyChange = info.Name + info.CurrentSource + info.SourceDir + info.Progression;
                // Autres cas pour récupérer les données de l'événement...
                   
                Console.WriteLine(messageOnpropertyChange);

                // Write a message to the client.
                // byte[] message = Encoding.UTF8.GetBytes(messageOnpropertyChange);
                // Console.WriteLine("Sending :"+ messageOnpropertyChange);
                // try
                // {
                //     sslStream.Write(message);
                // }
                // catch (Exception e1)
                // {
                //     Console.WriteLine(e1);
                //     throw;
                // }
            }
        
    }
}
    

       



