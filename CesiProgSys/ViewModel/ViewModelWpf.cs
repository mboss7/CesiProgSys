using System.Net.Security;
using Tcp_Ssl;

namespace CesiProgSys.ViewModel
{
    public class ViewModelWpf
    {
        private SslStream sslStream;
        private string messageOnpropertyChange;
        

        public void ViewModelWpf_RunSslSrv()
        {
            TcpServer tcpServer = new TcpServer();
            tcpServer.RunSrv();

           
            tcpServer.SendMessage(sslStream, messageOnpropertyChange);
            
        }
    }
}

