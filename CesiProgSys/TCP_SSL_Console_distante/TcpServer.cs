using System.ComponentModel;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tcp_Ssl
{
    public class TcpServer
    {


        public SslStream sslStream;
        
        /// <summary>
        /// For Run SRV SSL main Method
        /// </summary>
        public void RunSrv()
        {
            while (true)
            {
                TcpServer SslSrv = new TcpServer();

                SslSrv.SslTcpServerConnection();
            }

        }

        /// <summary>
        /// Connect the server in listen mode in SSL 
        /// </summary>
        public async Task<SslStream> SslTcpServerConnection()
        {

            bool FlagA = true;
            bool FlagB = true;

            while (FlagA)
            {

                X509Certificate serverCertificate = new X509Certificate(@"cert.pfx", "P@ssw0rd");
                TcpListener listener = new TcpListener(IPAddress.Any, 1234);
                listener.Start();
                Console.WriteLine("Waiting for a client to connect...");
                // Application blocks while waiting for an incoming connection.
                // Type CNTL-C to terminate the server.
                using TcpClient client = listener.AcceptTcpClient();
                SslStream sslStream = new SslStream(client.GetStream(), false);
                sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, true);
                Console.WriteLine("*** Client Connected ***");

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
                        SslTcpServerConnection().Dispose();
                        FlagB = false;
                    }

                    Console.WriteLine("Received: {0}", messageData);

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
                        SslTcpServerConnection().Dispose();
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
            public void SendMessage(SslStream sslStream, string messageOnpropertyChange)
            {
                
                
                // Write a message to the client.
                byte[] message = Encoding.UTF8.GetBytes(messageOnpropertyChange);
                Console.WriteLine("Sending :"+ messageOnpropertyChange);
                try
                {
                    sslStream.Write(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        
    }
}
    

       



