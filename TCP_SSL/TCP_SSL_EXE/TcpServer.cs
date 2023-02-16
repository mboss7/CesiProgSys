using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

X509Certificate serverCertificate = new X509Certificate("chemin/vers/le/certificat.pfx", "mot de passe");
TcpListener listener = new TcpListener(IPAddress.Any, 1234);
listener.Start();
TcpClient client = listener.AcceptTcpClient();
SslStream sslStream = new SslStream(client.GetStream(), false);
sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, true);