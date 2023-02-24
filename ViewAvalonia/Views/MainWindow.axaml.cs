using System.Collections.ObjectModel;
using Avalonia.Controls;
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
}

public sealed class MainWindowViewModel : ViewModel
{
    private ObservableCollection<Backup> _backups = new();

    public ObservableCollection<Backup> Backups
    {
        get => _backups;
        set
        {
            _backups = value;
            OnPropertyChanged();
        }
    }

    private bool _visible = true;
    public bool Visible
    {
        get => _visible;
        set
        {
            _visible = value;
            OnPropertyChanged();
        }
    }
    
    private bool _buttonVisible = true;

    public bool ButtonVisible
    {
        get => _buttonVisible;
        set
        {
            _buttonVisible = value;
            OnPropertyChanged();
        }
    }

    private Backup _selectedBackup;

    public Backup SelectedBackup
    {
        get => _selectedBackup;
        set
        {
            _selectedBackup = value;
            OnPropertyChanged();
            if (_selectedBackup != null && _selectedBackup.Etat == State.INACTIVE)
            {
                StartAuth = true;
                StopAuth = false;
                RestartAuth = false;
                ButtonVisible = true;
            }
            else if (_selectedBackup != null && _selectedBackup.Etat == State.ACTIVE)
            {
                StartAuth = false;
                StopAuth = true;
                RestartAuth = false;
                ButtonVisible = true;
            }
            else if(_selectedBackup != null && _selectedBackup.Etat == State.PAUSED)
            {
                StartAuth = false;
                StopAuth = false; 
                RestartAuth = true;
                ButtonVisible = false;
            }
            else
            {
                StartAuth = false;
                StopAuth = false; 
                RestartAuth = false;
            }
        }
    }

    private bool _startAuth;

    public bool StartAuth
    {
        get => _startAuth;
        set
        {
            _startAuth = value;
            OnPropertyChanged();
        }
    }
    
    private bool _stopAuth;

    public bool StopAuth
    {
        get => _stopAuth;
        set
        {
            _stopAuth = value;
            OnPropertyChanged();
        }
    }
    
    private bool _restartAuth;

    public bool RestartAuth
    {
        get => _restartAuth;
        set
        {
            _restartAuth = value;
            OnPropertyChanged();
        }
    }

    private string _welcomeText = "Welcome";

    public string WelcomeText
    {
        get => _welcomeText;
        set
        {
            _welcomeText = value;
            OnPropertyChanged();
        }
    }

    private string _startText = "Launch Backup";

    public string StartText
    {
        get => _startText;
        set
        {
            _startText = value;
            OnPropertyChanged();
        }
    }

    private string _configurationText = "Configuration";

    public string ConfigurationText
    {
        get => _configurationText;
        set
        {
            _configurationText = value;
            OnPropertyChanged();
        }
    }

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

    private string _dataGridName = "Name";
    public string DataGridName
    {
        get => _dataGridName;
        set
        {
            _dataGridName = value;
            OnPropertyChanged();
        }
    }
    
    private string _dataGridSource = "Source";
    public string DataGridSource
    {
        get => _dataGridSource;
        set
        {
            _dataGridSource = value;
            OnPropertyChanged();
        }
    }
    private string _dataGridTarget = "Target";
    public string DataGridTarget
    {
        get => _dataGridTarget;
        set
        {
            _dataGridTarget = value;
            OnPropertyChanged();
        }
    }
    private string _dataGridType = "Type";
    public string DataGridType
    {
        get => _dataGridType;
        set
        {
            _dataGridType = value;
            OnPropertyChanged();
        }
    }
    private string _dataGridState = "State";
    public string DataGridState
    {
        get => _dataGridState;
        set
        {
            _dataGridState = value;
            OnPropertyChanged();
        }
    }
    private string _dataGridProgression = "Progress";
    public string DataGridProgression
    {
        get => _dataGridProgression;
        set
        {
            _dataGridProgression = value;
            OnPropertyChanged();
        }
    }
    public MainWindowViewModel()
    {
        NetworkHandler n = NetworkHandler.Instance();
        n.stateBackup += updateBackup;
        HeaderViewModel.LanguageEvent += LanguagesChanges;
        
        
        ListTypeBackup = new List<string>()
        {
            "FullBackup", "DiffBackup"
        };
    }

    public List<string> ListTypeBackup { get; set; }

    public void LanguagesChanges(object sender, EventArgs e)
    {
        string s = (string)sender;

        if (s == "French")
        {
            WelcomeText = "Bienvenue";
            StartText = "Sauvegardes";
            DataGridName = "Nom";
            DataGridSource = "Source";
            DataGridTarget = "Cible";
            DataGridType = "Type";
            DataGridState = "Etat";
            DataGridProgression = "Progression";
            ConfigurationText = "Configuration";
        }
        else
        {
            WelcomeText = "Welcome";
            StartText = "Launch Backup";
            DataGridName = "Name";
            DataGridSource = "Source";
            DataGridTarget = "Target";
            DataGridType = "Type";
            DataGridState = "State";
            DataGridProgression = "Progress";
            ConfigurationText = "Configuration";
        }
    }
    public void modifyVisible() => Visible = !Visible;
    public void modifyButtonVisible() => ButtonVisible = !ButtonVisible;

    public void updateBackup(object sender, EventArgs eventArgs)
    {
        Backup b = (Backup)sender;

        Backup temp = Backups.Where(backup => backup.Name == b.Name).ElementAt(0);

        temp.Progression = b.Progression;
        temp.Etat = b.Etat;
    }

    public void addNewBackup()
    {
        Backup b = new(Name, Source, Target, TypeBackup);
        Backups.Add(b);

        string s = "0&" + TypeBackup + "&" + Name + "&" + Source + "&" + Target;

        Client.packets.Enqueue(s);
        Client.wait.Set();

        modifyVisible();
        TypeBackup = "";
        Name = "";
        Source = "";
        Target = "";
    }

    public void startBackup()
    {
        StartAuth = false;
        StopAuth = true;
        string s = "1&start&" + SelectedBackup.Name;
        Client.packets.Enqueue(s);
        Client.wait.Set();
    }

    public void stopBackup()
    {
        StopAuth = false;
        RestartAuth = true;
        modifyButtonVisible();
        string s = "1&stop&" + SelectedBackup.Name;
        Client.packets.Enqueue(s);
        Client.wait.Set();
    }
    public void restartBackup()
    {
        StopAuth = true;
        RestartAuth = false;
        modifyButtonVisible();
        string s = "1&restart&" + SelectedBackup.Name;
        Client.packets.Enqueue(s);
        Client.wait.Set();
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