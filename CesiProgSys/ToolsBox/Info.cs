using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CesiProgSys.ToolsBox;
public sealed class Info : INotifyPropertyChanged
{
        public string typeBackup;

        private TimeSpan _timeLaps;

        public TimeSpan TimeLaps
        {
            get => _timeLaps;
            set
            {
                if (_timeLaps != value)
                {
                    _timeLaps = value;
                    OnPropertyChanged("_timeLaps");
                }
            }
        }
        
        private string _sourceDir;
        public string SourceDir
        {
            get => _sourceDir;
            set
            {
                if (_sourceDir != value)
                {
                    _sourceDir = value;
                    OnPropertyChanged("_sourceDir");
                }
            }
        }
        
        private string _destDir;
        public string DestDir
        {
            get => _destDir;
            set
            {
                if (_destDir != value)
                {
                    _destDir = value;
                    OnPropertyChanged("_destDir");
                }
            }
        }
        private string _currentSource;
        public string CurrentSource
        {
            get => _currentSource;
            set
            {
                if (_currentSource != value)
                {
                    _currentSource = value;
                    OnPropertyChanged("_currentSource");
                }
            }
        }
        private string _currentDest;
        public string CurrentDest
        {
            get => _currentDest;
            set
            {
                if (_currentDest != value)
                {
                    _currentDest = value;
                    OnPropertyChanged("_currentDest");
                }
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("_date");
                }
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("_name");
                }
            }
        }
        private int _totalFilesToCopy;
        public int TotalFilesToCopy
        {
            get => _totalFilesToCopy;
            set
            {
                if (_totalFilesToCopy != value)
                {
                    _totalFilesToCopy = value;
                    OnPropertyChanged("_totalFilesToCopy");
                }
            }
        }
        private long _totalFilesSize;
        public long TotalFilesSize
        {
            get => _totalFilesSize;
            set
            {
                if (_totalFilesSize != value)
                {
                    _totalFilesSize = value;
                    OnPropertyChanged("_totalFilesSize");
                }
            }
        }
        private int _nbFilesLeftToDo;
        public int NbFilesLeftToDo
        {
            get => _nbFilesLeftToDo;
            set
            {
                if (_nbFilesLeftToDo != value)
                {
                    _nbFilesLeftToDo = value;
                    OnPropertyChanged("_nbFilesLeftToDo");
                }
            }
        }
        private State _state;
        public State State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("_state");
                }
            }
        }
        private float _progression;
        public float Progression
        {
            get => _progression;
            set
            {
                if (_progression != value)
                {
                    _progression = value;
                    OnPropertyChanged("_progression");
                }
            }
        }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
