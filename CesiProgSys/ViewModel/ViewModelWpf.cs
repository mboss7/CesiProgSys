using Tcp_Ssl;

namespace CesiProgSys.ViewModel
{
    public class ViewModelWpf
    { 
      

        public void ViewModelWpf_RunSslSrv()
        {
            TcpServer tcpServer = new TcpServer();
            
            tcpServer.RunSrv();
        }
    }
}

