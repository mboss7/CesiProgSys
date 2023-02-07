using System;
//using CesiProgSys.ViewModelCli;

namespace CesiProgSys.ViewCli
{
    public interface IViewCli
    {
        //public void startProgram();
        
        public void menu();
        
        public void configBackup();
        
        public void startBackup();
        
        public void showConfig();
        
        public void changeConfig();
        
        public void help();
        
        public void fullBackup();
        
        public void diffBackup();

        public void startBackupValid();
        
        public void showConfigValid();
    }  
}
