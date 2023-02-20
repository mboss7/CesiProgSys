using CesiProgSys.Backups;

namespace CesiProgSys.ViewModel
{
    public class ViewModelCli
    {
        private BackupManager bManager;
        private List<Backup> backups;
        public ViewModelCli()
        {
            bManager = BackupManager.Instance();
            backups = bManager.listBackupInstantiated;
        }
        
        public void instantiateBackup(string name, string sourceDir, string targetDir, bool type)
        {
            bManager.instantiate(name, sourceDir, targetDir, type);

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
    }  
}