using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

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
        private void OpenDialogButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Include_Backup();
            dialog.ShowDialog(this);
        }


    }
   

}