﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using CesiProgSys.Backup;
using CesiProgSys.ViewCli;

namespace CesiProgSys.ViewModel
{
    public class ViewModelCli : INotifyPropertyChanged
    {

        public static List<Tuple<Thread, string[]>> ouahMonCerveauEstPartiLoin;
        public static List<Tuple<Thread, IBackup>> marre;
        public static Mutex mutex = new Mutex();

        public static List<string[]> targetAndSource;
        
        public ViewModelCli()
        {
            bManager = BackupManager.Instance();
            ouahMonCerveauEstPartiLoin = new List<Tuple<Thread, string[]>>();
            marre = new List<Tuple<Thread, IBackup>>();
            targetAndSource = new List<string[]>();
        }

        private BackupManager bManager;

        public string? name;
        public string? sourceDir;
        public string? targetDir;
        
        public void instantiateFullBackup()
        {
            mutex.WaitOne(); 
            Tuple<Thread, string[]> temp = new Tuple<Thread, string[]>(bManager.instantiate(false), new[] { name, sourceDir, targetDir });
            ouahMonCerveauEstPartiLoin.Add(temp);
            Thread.Sleep(50);
            marre.Find(tuple => tuple.Item1 == temp.Item1).Item2.blockMutex();
            mutex.ReleaseMutex();
            
            
            name = null;
            sourceDir = null;
            targetDir = null;
        }

        public void startBackup(string name)
        {
            IBackup b = marre.Find(tuple => tuple.Item1.Name == name).Item2;
            
            bManager.start(b);
        }
        
        public void instantiateDiffBackup()
        {
            mutex.WaitOne(); 
            Tuple<Thread, string[]> temp = new Tuple<Thread, string[]>(bManager.instantiate(true), new[] { name, sourceDir, targetDir });
            ouahMonCerveauEstPartiLoin.Add(temp);
            Thread.Sleep(50);
            marre.Find(tuple => tuple.Item1 == temp.Item1).Item2.blockMutex();
            mutex.ReleaseMutex();

            name = null;
            sourceDir = null;
            targetDir = null;
        }

        public List<string> getThreadsNames()
        {
            List<string> toReturn = new List<string>();
            foreach (Tuple<Thread, IBackup> t in marre)
            {
                toReturn.Add(t.Item1.Name);
            }

            return toReturn;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }  
}