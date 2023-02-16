using System;
using System.Net;
using System.Net.Sockets;


// certif chiffrement  asymétrique en aes : https://learn.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.X509Certificate2?view=net-7.0
//

// https://learn.microsoft.com/fr-fr/dotnet/api/system.net.security.sslstream?view=net-7.0

namespace Tcp_Ssl.SRV_TCP_SSL
{
    public class program
    {
        
        // attributs 
        static bool seConnecterStatus = false;
        
        
        
        // MAIN 
        static void Main(string[] args)

        {
            SeConnecter();
            Console.WriteLine(seConnecterStatus);

        }

        
        
        // Fonction Se Connecter 
        private static async Task<Socket> SeConnecter()
        {
            
            IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipEndPoint = new(ipAddress, 11_000);
            using Socket client = new(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            await client.ConnectAsync(ipEndPoint);
            seConnecterStatus = client.Connected.Equals(true);


            return seConnecterStatus;
        }


        private static Socket AccepterConnexion(Socket socket)
        {

            return null;
        }
    }
}