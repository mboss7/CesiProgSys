namespace Tcp_Ssl
{
    public class ThreadForTcp
    {
      /// <summary>
      /// Run two thread, one client and one server for the model or the view depend exeptation 
      /// </summary>
      /// <param name="IpPort : string[] ip and port"></param>
        public void ThreadForTcpSTART(string[] IpPort)
        {
            //tableau de string Ip et Port 
            //string[] IpPort = { "localhost", "1234" };  // it was for test 
            int port = int.Parse(IpPort[1]);

            // run thread for run server
            Thread tcpServerModel = new Thread(TcpServer.RunSrv);
            tcpServerModel.Start(port);
            // run thread for run client
            Thread tcpClientModel = new Thread(TcpClientSsl.RunClient);
            tcpClientModel.Start(IpPort);
        }
    
    }  
}

