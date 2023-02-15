using System;
using System.Net.Sockets;


// certif chiffrement  asymétrique en aes : https://learn.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2?view=net-7.0
//

namespace Tcp_Ssl
{
    public class program
    {
        static void Main(string[] args)

        {
            TcpSslCom tcpSslCom = new TcpSslCom();
            
            tcpSslCom.RunClient("localhost","localhost");
            
            
            TcpClientSsl tcpClient = new TcpClientSsl();


            Console.WriteLine("\n ***Start Client*** \n");
           
            tcpClient.TcpClientRun();

        }
    }
}