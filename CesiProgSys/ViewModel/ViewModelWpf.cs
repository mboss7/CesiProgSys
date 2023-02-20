using System.Net.Security;
using CesiProgSys.ToolsBox;
using Tcp_Ssl;

namespace CesiProgSys.ViewModel
{
    public class ViewModelWpf
    {
        private TcpServer tcpServer;
        public ViewModelWpf()
        {
               
        }

        public void setEventInfo(Info inf)
        {
            inf.PropertyChanged += tcpServer.OnSendMessage;
        }
        
        public void ViewModelWpf_RunSslSrv()
        {
            tcpServer = TcpServer.Instance();

            // Thread t = new Thread(TcpServer.RunSrv);
            // t.Start(tcpServer);

            
            
        }
    }
}

