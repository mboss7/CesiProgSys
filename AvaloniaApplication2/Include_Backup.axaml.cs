using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

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
