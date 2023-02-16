using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;



X509Certificate2Collection clientCertificates = new X509Certificate2Collection();
clientCertificates.Add(new X509Certificate2("chemin/vers/le/certificat.pfx", "mot de passe"));
TcpClient client = new TcpClient("adresse IP ou nom de domaine du serveur", 1234);
SslStream sslStream = new SslStream(client.GetStream(), false, (sender, certificate, chain, errors) => true);
sslStream.AuthenticateAsClient("adresse IP ou nom de domaine du serveur", clientCertificates, SslProtocols.Tls, true);

