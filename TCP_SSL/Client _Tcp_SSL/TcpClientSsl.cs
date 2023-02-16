using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tcp_Ssl
{
    public class TcpClientSsl
    {
        public void SslTcpClientConnection()
        {

            bool FlagA = true;
            bool FlagB = true;

            
                X509Certificate2Collection clientCertificates = new X509Certificate2Collection();
                clientCertificates.Add(new X509Certificate2(@"cert.pfx", "P@ssw0rd"));
            
            while (FlagA)
            {
              
               TcpClient client = new TcpClient("localhost", 1234);
               SslStream sslStream = new SslStream(client.GetStream(), false, (sender, certificate, chain, errors) => true);
               sslStream.AuthenticateAsClient("localhost", clientCertificates, SslProtocols.Tls, true);
                   
                   
                
                
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
                        Console.WriteLine("Connection lost : " +e);
                        client.Close();

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


