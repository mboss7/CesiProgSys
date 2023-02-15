using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Clickexit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}