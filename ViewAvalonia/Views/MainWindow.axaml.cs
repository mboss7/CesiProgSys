using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ViewAvalonia.Views;

public class MainWindow : Window
{
    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = new MainWindowViewModel();
    }

    private void OpenDialogButton_Click(object sender, RoutedEventArgs e)
    {
        // var dialog = new NewBackup();
        // dialog.ShowDialog(this);
    }
    //
    // private async void OpenFile_Click(object sender, RoutedEventArgs e)
    // {
    //     var dialog = new OpenFileDialog();
    //     dialog.AllowMultiple = false;
    //     dialog.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //
    //     var result = await dialog.ShowAsync(this);
    //
    //     if (result != null && result.Length == 1)
    //     {
    //         string filePath = result[0];
    //         // Do something with the file path...
    //     }
    // }

    // private async void OpenFolder_Click(object sender, RoutedEventArgs e)
    // {
    //     var dialog = new OpenFolderDialog();
    //     dialog.Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    //
    //     var result = await dialog.ShowAsync(this);
    //
    //     if (result != null)
    //     {
    //         string folderPath = result;
    //         // Do something with the folder path...
    //     }
    //
    // }
}

public sealed class MainWindowViewModel : ViewModel
{
    
    private bool _visible;
    public bool Visible
    {
        get => _visible;
        set
        {
            _visible = value; 
            OnPropertyChanged();
        }
    }
    

    private string _welcomeText;
    public string WelcomeText 
    {
        get => _welcomeText;
        set
        {
            _welcomeText = value;
            OnPropertyChanged();
        } 
    }
    
    public void modifyVisible() => Visible = !Visible;

    public MainWindowViewModel()
    {
        Visible = true;
        
        WelcomeText = "Welcome";
        StartText = "Launch Backup";
        ConfigText = "Config Backup";
        ConfigurationText = "Configuration";

        Backups = new()
        {
            new()
            {
                Name = "Backup1",
                Source = "PathSource",
                Target = "PathTarget",
                Progression = 30,
                Type = "FullBackup",
                Etat = false
            },
            new()
            {
                Name = "Backup2",
                Source = "PathSource2",
                Target = "PathTarget2",
                Progression = 90,
                Type = "DiffBackup",
                Etat = true
            },
        };

    }

    public List<Backup> Backups { get; set; }
    public string ConfigText { get; set; }
    public string StartText { get; set; }
    public string ConfigurationText { get; set; }
}