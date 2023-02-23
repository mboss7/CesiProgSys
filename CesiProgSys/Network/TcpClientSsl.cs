using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CesiProgSys.Network
{
    public class TcpClientSsl
    {
        private int port;
        string ipAddress;
        /// <summary>
        /// FOR Run the client ssl main Method
        /// </summary>
        public static void RunClient(object objIpPort)
        {
            string [] ipPort = (string[]) objIpPort;
            string ipAddress = ipPort[0];
            int port = int.Parse(ipPort[1]);
            
            while (true)
            {
                TcpClientSsl tcpClientSsl = new TcpClientSsl();
            
                tcpClientSsl.SslTcpClientConnection(ipAddress, port);
            }
        }
        /// <summary>
        /// Connect Client to the Server in SSl 
        /// </summary>
        public async Task SslTcpClientConnection(string ipAddress, int port)
        {

            bool FlagA = true;
            bool FlagB = true;

            
                X509Certificate2Collection clientCertificates = new X509Certificate2Collection();
                clientCertificates.Add(new X509Certificate2(@"cert.pfx", "P@ssw0rd"));
            
            while (FlagA)
            {
                
                TcpClient client = new TcpClient(ipAddress, port);
               SslStream sslStream = new SslStream(client.GetStream(), false, (sender, certificate, chain, errors) => true);
               sslStream.AuthenticateAsClient(ipAddress, clientCertificates, SslProtocols.Tls, true);
                   
                   
                
                
                while (FlagB)
                {

                    // Encode a test message into a byte array.
                    // Signal the end of the message using the "<EOF>".
                    Console.WriteLine("Please Enter Message for the Server :");
                    string msg = Console.ReadLine();
                    byte[] messsage = Encoding.UTF8.GetBytes(msg + "<EOF>");
                    // Send message to the server.
                    try
                    {
                        sslStream.Write(messsage);
                        sslStream.Flush();
                        // Read message from the server.
                        string serverMessage = ReadMessage(sslStream);
                        Console.WriteLine("Server says: {0}", serverMessage);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("-- Connection server lost --");
                        client.Close();
                        SslTcpClientConnection(ipAddress,port).Dispose();
                        FlagB = false;
                    }
                }         
            }
                
        }

        static string ReadMessage(SslStream sslStream)
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            byte [] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer,0,bytes)];
                decoder.GetChars(buffer, 0, bytes, chars,0);
                messageData.Append (chars);
                // Check for EOF.
                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
            } while (bytes != 0);

            return messageData.ToString();
        }
    }
}


