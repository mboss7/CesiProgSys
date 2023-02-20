using CesiProgSys.Backups;
using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli
{
    public class ViewCliEn : ViewCli
    {
        public ViewCliEn()
        {
            vmCLI = new ViewModelCli();
            textMenu = "1. Configure a backup\n2. Start a backup\n3. Show configurations\n4. Change configurations\n5. Help\n6. Exit";
            textConfigBackup = "1. Full backup\n2. Differential backup\n3. Return\n4. Exit";
            textStartBackup = "1. Validation of the start of a backup\n2. Return\n3. Exit";
            textShowConfig = "1. Validation of the display of configurations\n2. Return\n3. Exit";
            textChangeConfig = "1. Change langue\n2. Default save source\n3. Default save target\n4. Clean recent save source\n5. Clean recent save target\n6. Change retention time\n7. Reset config\n8. Return\n9. Exit"; 
            
            askChoice = "Enter your choice : ";
            exit = "Exiting the program...";
            invalid = "Invalid choice. Try again.";
        }

    }
}