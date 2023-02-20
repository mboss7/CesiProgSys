﻿using CesiProgSys.Backups;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.ViewModel
{
    public class ViewModelCli
    {
        private BackupManager bManager;
        private List<Backup> backups;
        private Config config;
        public ViewModelCli()
        {
            bManager = BackupManager.Instance();
            backups = bManager.listBackupInstantiated;
            config = Config.Instance();
        }
        
        public void instantiateBackup(string name, string sourceDir, string targetDir, bool type)
        {
            bManager.instantiate(name, sourceDir, targetDir, type);
            config.recentSaveSource.Add(sourceDir);
            config.recentSaveTarget.Add(targetDir);
        }

        public List<string[]> getBackups()
        {
            List<string[]> toReturn = new List<string[]>();

            foreach (Backup b in backups)
            {
                string[] s = {b.name, b.source, b.target};
                toReturn.Add(s);
            }
            
            return toReturn;
        }

        public void startBackup(string name)
        {
            bManager.startBackup(backups.Find(backup => backup.name == name));
        }

        public void stopBackup(string name)
        {
            
        }

        public void restartBackup(string name)
        {
            
        }

        public void killBackup(string name)
        {
            
        }

        public void writeConfig()
        {
            config.writeConfig();
        }

        public string[] getConfig()
        {
            return new []{config.language.ToString(), 
                config.defaultSaveSource, 
                config.defaultSaveTarget, 
                string.Join("\n",config.recentSaveSource), 
                string.Join("\n",config.recentSaveTarget), 
                config.retentionTime.ToString(), 
                config.typeLogs};
        }

        public void changeLanguage(Language l)
        {
            config.language = l;
        }

        public void changeDefaultSaveSource(string s)
        {
            config.defaultSaveSource = s;
        }

        public void changeDefaultSaveTarget(string s)
        {
            config.defaultSaveTarget = s;
        }

        public void resetConfig()
        {
            config.resetConfig();
        }

        public void changeRetentionTime(int i)
        {
            config.retentionTime = i;
        }

        public string getDefaultSource()
        {
            return config.defaultSaveSource;
        }

        public string getDefaultTarget()
        {
            return config.defaultSaveTarget;
        }
    }  
}