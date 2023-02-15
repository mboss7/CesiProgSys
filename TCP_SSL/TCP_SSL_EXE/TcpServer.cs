using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class TcpServer
{
    private TcpListener listener;
    private X509Certificate2 serverCertificate;

    public TcpServer(string ipAddress, int port, string certificatePath, string certificatePassword)
    {
        IPAddress address = IPAddress.Parse(ipAddress);
        listener = new TcpListener(address, port);
        serverCertificate = new X509Certificate2(certificatePath, certificatePassword);
    }

    public void Start()
    {
        listener.Start();
        Console.WriteLine("Server started");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            SslStream sslStream = new SslStream(client.GetStream(), false);

            try
            {
                sslStream.AuthenticateAsServer(serverCertificate, false, SslProtocols.Tls, true);

                byte[] buffer = new byte[2048];
                int bytes = sslStream.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytes);
                Console.WriteLine("Received: " + data);

                byte[] message = Encoding.UTF8.GetBytes("Hello from server");
                sslStream.Write(message);
                sslStream.Flush();

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                client.Close();
            }
        }
    }
}