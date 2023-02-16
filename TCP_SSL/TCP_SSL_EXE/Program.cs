using System;
using System.Net.Security;
using System.Net.Sockets;
using Tcp_Ssl.SRV_TCP_SSL;


// certif chiffrement  asymétrique en aes : https://learn.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2?view=net-7.0
//

// https://learn.microsoft.com/fr-fr/dotnet/api/system.net.security.sslstream?view=net-7.0

namespace Tcp_Ssl
{
    public class program
    {
        static void Main(string[] args)

        {

            while (true)
            {
                TcpServer SslSrv = new TcpServer();
            
                SslSrv.SslTcpServerConnection(); 
            }
            


        }
    }
}
