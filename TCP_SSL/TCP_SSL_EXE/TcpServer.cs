using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;


namespace TCP_SSL_EXE
{
    public class TcpServer
    
    {

        public void ServerRun()
        {
            // Charger le certificat SSL/TLS
            X509Certificate2 certificate = new X509Certificate2("cert.pfx", "password");

            // Créer une socket TCP et la configurer pour écouter les connexions entrantes
            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            // Boucle infinie pour accepter les connexions entrantes
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                // Créer un stream SSL/TLS sécurisé
                SslStream sslStream = new SslStream(client.GetStream(), false);
                sslStream.AuthenticateAsServer(certificate, false, SslProtocols.Tls, true);

                // Recevoir le nom de fichier à partir du client
                byte[] filenameBuffer = new byte[1024];
                int filenameLength = sslStream.Read(filenameBuffer, 0, filenameBuffer.Length);
                string filename = Encoding.ASCII.GetString(filenameBuffer, 0, filenameLength);

                // Ouvrir le fichier et le lire
                byte[] fileData = File.ReadAllBytes(filename);

                // Envoyer les données du fichier au client
                sslStream.Write(fileData, 0, fileData.Length);

                // Fermer la connexion sécurisée
                sslStream.Close();
                client.Close();
            }
        }
    }
}

}


