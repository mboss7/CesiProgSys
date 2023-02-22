namespace Tcp_Ssl
{
    public class ThreadForTcp
    {
      
       /// <summary>
       /// Run Client TCP SSL Thread
       /// </summary>
       /// <param name="IpPort"></param>
      public void ClientTcpThreadRun(string[] IpPort)
      {
          // run thread for run client
          Thread tcpClientModel = new Thread(TcpClientSsl.RunClient);
          tcpClientModel.Start(IpPort);
      }

       /// <summary>
       /// Run Server Tcp SSL Thread
       /// </summary>
       /// <param name="IpPort"></param>
      public void ServerTcpThreadRun(string[] IpPort)
      {
          
          //string[] IpPort = { "localhost", "1234" };  // it was for test 
          int port = int.Parse(IpPort[1]);

          // run thread for run server
          Thread tcpServerModel = new Thread(TcpServer.RunSrv);
          tcpServerModel.Start(port);
      }
    
    }  
}

