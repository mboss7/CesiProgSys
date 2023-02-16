using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Tcp_Ssl
{
    public class TcpClientSsl
    {
        public void SslTcpClientConnection()
        {
            X509Certificate2Collection clientCertificates = new X509Certificate2Collection();
            clientCertificates.Add(new X509Certificate2(@"cert.pfx", "P@ssw0rd"));
            TcpClient client = new TcpClient("localhost", 1234);
            SslStream sslStream = new SslStream(client.GetStream(), false, (sender, certificate, chain, errors) => true);
            sslStream.AuthenticateAsClient("adresse IP ou nom de domaine du serveur", clientCertificates, SslProtocols.Tls, true);
        }
    }
}


