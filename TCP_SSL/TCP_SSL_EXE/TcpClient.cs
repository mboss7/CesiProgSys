using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Client
{
    private string serverIpAddress;
    private int serverPort;
    private X509Certificate2 clientCertificate;

    public Client(string ipAddress, int port, string certificatePath, string certificatePassword)
    {
        serverIpAddress = ipAddress;
        serverPort = port;
        clientCertificate = new X509Certificate2(certificatePath, certificatePassword);
    }

    public void Connect()
    {
        TcpClient client = new TcpClient(serverIpAddress, serverPort);
        SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

        try
        {
            sslStream.AuthenticateAsClient("localhost", new X509Certificate2Collection(clientCertificate), SslProtocols.Tls, false);

            byte[] message = Encoding.UTF8.GetBytes("Hello from client");
            sslStream.Write(message);
            sslStream.Flush();

            byte[] buffer = new byte[2048];
            int bytes = sslStream.Read(buffer, 0, buffer.Length);
            string data = Encoding.UTF8.GetString(buffer, 0, bytes);
            Console.WriteLine("Received: " + data);

            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            client.Close();
        }
    }

    private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true;
        }

        Console.WriteLine("Certificate error: " + sslPolicyErrors);
        return false;
    }
}