using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace CesiProgSys.ViewModel.TcpIp
{
    // Not forget to crypt : https://learn.microsoft.com/fr-fr/dotnet/api/system.net.security.sslstream?view=net-7.0 

    class TcpLink
    {
        int NbConnection;
        string NbConnectionstring;
        public int port;
        private NetworkStream stream;

        public TcpLink()
        {
            NbConnection = 0;
            NbConnectionstring = "";
            port = 12345;
            stream = null;
        }

        public NetworkStream ServerTCP()
        {
          
               
             
                    $"\n_____________________________________\n *| Server START on port : {port} |* \n_____________________________________\n");

                // Buffer for reading data.
                byte[] buffer = new byte[1024];

                TcpListener server = new TcpListener(8080);
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();

                    using (NetworkStream stream = client.GetStream())
                    {
                        // Réception de la clé de cryptage
                        Aes aes = Aes.Create();
                        byte[] key = new byte[aes.KeySize / 8];
                        int bytesRead = stream.Read(key, 0, key.Length);

                        // Décryptage du message
                        byte[] encryptedMessage = new byte[1024];
                        bytesRead = stream.Read(encryptedMessage, 0, encryptedMessage.Length);
                        byte[] decryptedMessage = Decrypt(encryptedMessage, key, aes.IV);

                        Console.WriteLine("Message reçu : " + System.Text

                    }



                }
            }
        }
    }







