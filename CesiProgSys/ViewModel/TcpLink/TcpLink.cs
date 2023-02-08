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

namespace CesiProgSys.ViewModel.TcpIp
{
    // TCP SRV in TCP Listener 
    internal class TcpLink
    {
        int port;
       // private static object client;
       

        //string Client;

        public TcpLink() 
        {
            port = 0;
            //client = "127.0.0.1";
            //Client= "127.0.0.1";
        }


        public void TcpListenerLink()
        {        


        // on crée le service d'écoute
        TcpListener ecoute = null;
            try {
                // on crée le service - il écoutera sur toutes les interfaces réseau de la machine
                ecoute = new TcpListener(IPAddress.Any, port);
        // on le lance
        ecoute.Start();
                // boucle de service
                TcpClient tcpClient = null;
                // boucle infinie - sera arrêtée par Ctrl-C
                while (true) {
                    // attente d'un client
                    tcpClient = ecoute.AcceptTcpClient();
                    // le service est assuré par une autre tâche
                    ThreadPool.QueueUserWorkItem(Service, tcpClient);
                    // client suivant
                }
                } 
            catch (Exception ex)
            {
         // on signale l'erreur
    
            }
            finally
            {
           // fin du service
             ecoute.Stop();
            }
        }

         // -------------------------------------------------------
            // assure le service à un client
        public static void Service(Object infos)
        {
         // on récupère le client qu'il faut servir
         Client client = infos as Client;
        // exploitation liaison TcpClient
            try
            {
                using (TcpClient tcpClient = client.CanalTcp)
                {
                    using (NetworkStream networkStream = tcpClient.GetStream())
                    {
                        using (StreamReader reader = new StreamReader(networkStream))
                        {
                            using (StreamWriter writer = new StreamWriter(networkStream))
                            {
                                // flux de sortie non bufferisé
                                writer.AutoFlush = true;
                                // boucle lecture demande/écriture réponse
                                bool fini = false;
                                while (!fini) // Correct problem ???  
                                {
                                    string demande;
                                    string reponse;
                                // attente demande client - opération bloquante
                                demande = reader.ReadLine();
                                // préparation réponse
                                reponse = "";
                                // envoi réponse au client
                                writer.WriteLine(reponse);
                                // demande suivante
                                }
                            }
                        }
                    }
                }
        
            }
            catch (Exception e)
             {
            // erreur
   
             }
             finally
            {
            // fin client
    
            }
        }
    }
}

