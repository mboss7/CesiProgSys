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
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        private void Clickexit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}