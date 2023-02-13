using System.ComponentModel;
using System.Runtime.CompilerServices;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backups
{
    public abstract class Backup : INotifyPropertyChanged
    {
        public event EventHandler? checkAuth;
        public event EventHandler? start;
        
        public void initiateBackup()
        {
            checkAuth += startCheck;
            start += startBackup;
        }

        private void startCheck(object? sender, EventArgs eventArgs)
        {
            State = State.CHECKINGAUTH;
            checkAuthorizations(SourceDir);
        }
        protected abstract void checkAuthorizations(string directory);
        public void OnCheckAuth()
        {
            checkAuth.Invoke(null, EventArgs.Empty);
        }
        
        private void startBackup(object? sender, EventArgs eventArgs)
        {
            State = State.ACTIVE;
            backup();
        }

        protected abstract void backup();

        public void OnStartBackup()
        {
            start.Invoke(null, EventArgs.Empty);
        }

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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    RealTimeLogs.OnWriteLog(this);
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
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(_progression)));
                    RealTimeLogs.OnWriteLog(this);
                }
            }
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}