using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ViewAvalonia.Network;
using ViewAvalonia.ToolBox;

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
    
    public MainWindowViewModel()
    {
        Visible = true;
        
        WelcomeText = "Welcome";
        StartText = "Launch Backup";
        ConfigText = "Config Backup";
        ConfigurationText = "Configuration";

        NetworkHandler n = NetworkHandler.Instance();

        n.stateBackup += updateBackup;

        Backups = new ObservableCollection<Backup>();
        
        ListTypeBackup = new List<string>()
        {
            "FullBackup", "DiffBackup"
        };
    }

    private ObservableCollection<Backup> _backups;

    public ObservableCollection<Backup> Backups
    {
        get => _backups;
        set
        {
            _backups = value;
            OnPropertyChanged();
        }
    }

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

    public void modifyVisible() => Visible = !Visible;

    public void updateBackup(object sender, EventArgs eventArgs)
    {
        Backup b = (Backup)sender;

        Backup temp = Backups.Where(backup => backup.Name == b.Name).ElementAt(0);

        temp.Progression = b.Progression;
        temp.Etat = b.Etat;
    }

    private Backup _selectedBackup;

    public Backup SelectedBackup
    {
        get => _selectedBackup;
        set
        {
            _selectedBackup = value;
            OnPropertyChanged();
            if (_selectedBackup != null)
            {
                StartAuth = true;
            }
            else
            {
                StartAuth = false;
            }
            
        }
    }
    
    public void addNewBackup()
    {
        Backup b = new(Name, Source, Target, TypeBackup);
        Backups.Add(b);

        string s = "0&"+ TypeBackup+"&" + Name+"&" + Source+"&" +Target;
        
        Client.packets.Enqueue(s);
        Client.wait.Set();
        
        modifyVisible();
    }

    public void startBackup()
    {
        Console.WriteLine("On est la ?");
        string s = "1&start&" + SelectedBackup.Name;
        Client.packets.Enqueue(s);
        Client.wait.Set();
    }

    private bool _startAuth = false;

    public bool StartAuth
    {
        get => _startAuth;
        set
        {
            _startAuth = value;
            OnPropertyChanged();
        }
    }
    
    public string WelcomeText { get; set; }
    public string ConfigText { get; set; }
    public string StartText { get; set; }
    public string ConfigurationText { get; set; }
    
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    
    private string _source;
    public string Source
    {
        get => _source;
        set
        {
            _source = value;
            OnPropertyChanged();
        }
    }
    private string _target;
    public string Target
    {
        get => _target;
        set
        {
            _target = value;
            OnPropertyChanged();
        }
    }
    
    public List<string> ListTypeBackup { get; set; }

    private string _typeBackup;

    public string TypeBackup
    {
        get => _typeBackup;
        set
        {
            _typeBackup = value;
            OnPropertyChanged();
        }
    }

    public void leaveNewBackup()
    {
        Name = "";
        Source = "";
        Target = "";
        TypeBackup = "";
        modifyVisible();
    }
}