using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplicationVIEW;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;


namespace AvaloniaApplicationVIEW
{


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnClickHandler(object sender, RoutedEventArgs e)
        {
            // do something
            TcpLinkClient tcpClientCo = new TcpLinkClient();
            tcpClientCo.tcpClient("localhost", 12345);
        }
    }    
}
