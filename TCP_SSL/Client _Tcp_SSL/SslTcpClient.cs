namespace Tcp_Ssl;

using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class SslTcpClient
{
    public static void RunClient(string machineName, int port)
    {
        TcpClient client = new TcpClient(machineName, port);
        Console.WriteLine("Client connected.");
        SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
        try
        {
            sslStream.AuthenticateAsClient(machineName);
            Console.WriteLine("Client authenticated.");
            byte[] buffer = Encoding.UTF8.GetBytes("Hello, server!");
            sslStream.Write(buffer);
            sslStream.Flush();
        }
        catch (AuthenticationException e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
            if (e.InnerException != null)
            {
                Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
            }
            Console.WriteLine("Authentication failed - closing the connection.");
            client.Close();
            return;
        }
        client.Close();
        Console.WriteLine("Client closed.");
    }

    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;
        }
        Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
        return false;
    }
}
