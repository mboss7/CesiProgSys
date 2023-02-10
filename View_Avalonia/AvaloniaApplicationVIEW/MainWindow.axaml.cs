using Avalonia.Controls;
using AvaloniaApplicationVIEW;

namespace AvaloniaApplicationVIEW
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void OnClickCommand()
        {
            TcpLinkClient tcpClientCo = new TcpLinkClient();

            tcpClientCo.tcpClient("localhost", 12345);
        }
    }
}
