using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplicationVIEW;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows.Input;


namespace AvaloniaApplicationVIEW
{


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Connection(object sender, RoutedEventArgs e)
        {
            
            // do something
            TcpLinkClient tcpClientCo = new TcpLinkClient();
            tcpClientCo.tcpClient("localhost", 12345);

            // VOIR GESTION EVENT HANDLER !!! (coté server et client !!) asynchone, gestion pour faire plusieurs taches en même temps 
            
        }
        private void Send(object sender, RoutedEventArgs e)
        {
            // do something

            // do something
            TcpLinkClient tcpClientCo = new TcpLinkClient();
            tcpClientCo.tcpClient("localhost", 12345);
            Tuple<NetworkStream, byte[]> ReturnTcpClient = tcpClientCo.tcpClient("localhost", 12345);


            string PathFile1 = @".\\ClientReception.txt";

            tcpClientCo.tcpClientSend(ReturnTcpClient, PathFile1);   
        }
    }    
}
