using System.Net.Sockets;
using CesiProgSys.Backup;
using CesiProgSys.LOG;
using CesiProgSys.ViewCli;
using CesiProgSys.ViewModel.TcpIp;

    namespace CesiProgSys
    {

        public class Program
        {

            static void Main()
            {
                TcpLink tcpSRV = new TcpLink();

                tcpSRV.ServerTCP();
                
                NetworkStream returnServerTCP = tcpSRV.ServerTCP();

                tcpSRV.SendJsonToClient(returnServerTCP);

                Console.WriteLine("It's Works ! ");
                Console.ReadLine();

            }
        }
    }

