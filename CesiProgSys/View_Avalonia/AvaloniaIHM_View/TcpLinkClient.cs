﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace AvaloniaIHM_View
{
    // Tcp client 
    internal class TcpLinkClient
    {

        // Constructor 
        public TcpLinkClient() { }

         try {
                // on se connecte au service
                using (TcpClient tcpClient = new TcpClient(serveur, port)) {
                    using (NetworkStream networkStream = tcpClient.GetStream()) {
                        using (StreamReader reader = new StreamReader(networkStream)) {
                            using (StreamWriter writer = new StreamWriter(networkStream)) {
                                // flux de sortie non bufferisé
                                writer.AutoFlush = true;
                                // boucle demande - réponse
                                while (true) {
                                    // la demande vient du clavier
                                    Console.Write("Demande (bye pour arrêter) : ");
                                    demande = Console.ReadLine();
                                    // fini ?
                                    if (demande.Trim().ToLower() == "bye")
                                        break;
                                    // on envoie la demande au serveur
                                    writer.WriteLine(demande);
                                    // on lit la réponse du serveur
                                    réponse = reader.ReadLine();
                                    // on traite la réponse
                                    ...
                                }
}
                        }
                    }
                }
            } catch (Exception e)
            {
                // erreur
   
       }
}



    }
}
