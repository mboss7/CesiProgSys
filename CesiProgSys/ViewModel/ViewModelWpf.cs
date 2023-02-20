using System.Net.Security;
using Tcp_Ssl;

namespace CesiProgSys.ViewModel
{
    public class ViewModelWpf
    { 
      

        public async void ViewModelWpf_RunSslSrv()
        {
            TcpServer tcpServer = new TcpServer();
            
            tcpServer.RunSrv();

           
            
        }
    }
}

