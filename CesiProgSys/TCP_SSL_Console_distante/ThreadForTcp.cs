namespace Tcp_Ssl
{
    public class ThreadForTcp
    {
        public void ThreadForTcpSTART()
        {
            //tableau de string Ip et Port 
            string[] IpPort = { "localhost", "1234" };


            Thread tcpServerModel = new Thread(TcpServer.RunSrv);
            tcpServerModel.Start(1234);

            Thread tcpClientModel = new Thread(TcpClientSsl.RunClient);
            tcpClientModel.Start(IpPort);
        }
    
    }  
}

