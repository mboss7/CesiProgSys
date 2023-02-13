using System;
using System.Net.Sockets;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace TCP_SSL_EXE
{
    public class TcpClient
    {
        public void ClientRun()
        {
            // Charger le certificat SSL/TLS
            X509Certificate2 certificate = new X509Certificate2("cert.pfx", "password");

            // Créer une socket TCP et la configurer pour se connecter au serveur
            TcpClient client = new TcpClient("localhost", 12345);

            // Créer un stream SSL/TLS sécurisé
            SslStream sslStream = new SslStream(client.GetStream(), false);
            sslStream.AuthenticateAsClient("localhost", new X509Certificate2[] { certificate }, SslProtocols.Tls, true);

            // Envoyer le nom de fichier au serveur
            string filename = "example.txt";
            byte[] filenameBuffer = Encoding.ASCII.GetBytes(filename);
            sslStream.Write(filenameBuffer, 0, filenameBuffer.Length);

            // Recevoir les données du fichier à partir du serveur
            byte[] fileData = new byte[1024];
            MemoryStream memoryStream = new MemoryStream();
            int bytesRead;
            while ((bytesRead = sslStream.Read(fileData, 0, fileData.Length)) > 0)
            {
                memoryStream.Write(fileData, 0, bytesRead);
            }

            // Écrire les données du fichier dans un fichier local
            File.WriteAllBytes(filename, memoryStream.ToArray());

            // Fermer la connexion sécurisée
            sslStream.Close();
            client.Close();
        }
    }
    }
}

