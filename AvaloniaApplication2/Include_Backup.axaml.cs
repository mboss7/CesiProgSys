using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication2
{
    public partial class Include_Backup : Window
    {
        public Include_Backup()
        {
            InitializeComponent();
        }

        private void CloseDialogButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }



}
