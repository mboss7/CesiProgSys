namespace Tcp_Ssl
{
    public class ThreadForTcp
    {
        /// <summary>
        /// Run two thread, one client and one server for the model or the view depend exeptation 
        /// </summary>
        public void ThreadForTcpSTART()
        {
            //tableau de string Ip et Port 
            string[] IpPort = { "localhost", "1234" };

            // run thread for run server
            Thread tcpServerModel = new Thread(TcpServer.RunSrv);
            tcpServerModel.Start(1234);
            // run thread for run client
            Thread tcpClientModel = new Thread(TcpClientSsl.RunClient);
            tcpClientModel.Start(IpPort);
        }
    
    }  
}

