using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Tcp_Ssl
{
    public class TcpServer
    {
        public void SslTcpServerConnection()
        {
        
            X509Certificate serverCertificate = new X509Certificate(@"cert.pfx", "P@ssw0rd");
            TcpListener listener = new TcpListener(IPAddress.Any, 1234);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            SslStream sslStream = new SslStream(client.GetStream(), false);
            sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, true);
        }
    }
 
}

