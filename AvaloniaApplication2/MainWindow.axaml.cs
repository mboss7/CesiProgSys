using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

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

        private async void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.AllowMultiple = false;
            dialog.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var result = await dialog.ShowAsync(this);

            if (result != null && result.Length == 1)
            {
                string filePath = result[0];
                // Do something with the file path...
            }
        }

        private async void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFolderDialog();
            dialog.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var result = await dialog.ShowAsync(this);

            if (result != null)
            {
                string folderPath = result;
                // Do something with the folder path...
            }

        }

    }
   

}