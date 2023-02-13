using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using Avalonia.Rendering;
using System.Security.Cryptography;

namespace AvaloniaIHM_View
{

    class TcpLinkClient
    {
        //attributs
        string SrvHostname;
        int Port;
        private string FilePath;
        private NetworkStream stream;
        public byte[] buffer;
        bool LoopTcpClient;

        //constructor
        public TcpLinkClient()
        {
            SrvHostname = "localhost";
            Port = 12345;
            FilePath = @".\\ClientReception.txt";
            stream = null;
            buffer = null;
            LoopTcpClient = true;


        }

        // Methode to connect client to server. Return a tuple with stream and buffer var
        public void tcpClient(string SrvHostname, int Port)
        {
            // Connect to the server.
            TcpClient client = new TcpClient(SrvHostname, Port);
            Console.WriteLine("Connected to the server.");

            // tcp encrypt aes 
            using (NetworkStream stream = client.GetStream())
            {
                // Génération de la clé de cryptage
                Aes aes = Aes.Create();
                byte[] key = aes.Key;

                // Envoi de la clé au serveur
                stream.Write(key, 0, key.Length);

                // Cryptage du message
                byte[] message = System.Text.Encoding.UTF8.GetBytes("Bonjour serveur");
                byte[] encryptedMessage = Encrypt(message, aes.Key, aes.IV);

                // Envoi du message crypté
                stream.Write(encryptedMessage, 0, encryptedMessage.Length);
            }


            static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(),
                                   CryptoStreamMode.Write))
                        {
                            cs.Write(data, 0, data.Length);
                        }

                        return ms.ToArray();
                    }
                }
            }
        }
    }
}
    



































