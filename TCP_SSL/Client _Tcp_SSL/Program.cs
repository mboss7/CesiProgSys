﻿using System;
using System.Net.Sockets;


// certif chiffrement  asymétrique en aes : https://learn.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2?view=net-7.0
//

namespace Tcp_Ssl
{
    public class program
    {
        static void Main(string[] args)

        {
            while (true)
            {
                TcpClientSsl tcpClientSsl = new TcpClientSsl();
            
                tcpClientSsl.SslTcpClientConnection();
            }
            
        }
    }
}