using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli;

public class ViewCliEn : ViewCli
{
    public ViewCliEn()
    {
        vmCLI = new ViewModelCli();
        dico = new Dictionary<string, string>()
        {
            {
                "textMenu",
                "1. Configure a backup\n2. Start a backup\n3. Show configurations\n4. Change configurations\n5. Help\n6. Exit"
            },
            { "textConfigBackup", "1. Full backup\n2. Differential backup\n3. Return\n4. Exit" },
            {"textSource", "1. Use the default save source\n2. Use a recent save source\nElse write the path :"},
            {"textTarget", "1. Use the default save target\n2. Use a recent save target\nElse write the path :"},
            { "textStartBackup", "1. Validation of the start of a backup\n2. Return\n3. Exit" },
            { "textShowConfig", "1. Validation of the display of configurations\n2. Return\n3. Exit" },
            {
                "textChangeConfig",
                "1. Change language\n2. Default save source\n3. Default save target\n4.Reset config\n5.Change retention time\n6. Return\n7. Exit"
            },
            {
                "textHelp", " .----------------.\n" +
                            "| .--------------. |\n" +
                            "| |    ______    | |\n" +
                            "| |   / _ __ `.  | |\n" +
                            "| |  |_/____) |  | |\n" +
                            "| |    /  ___.'  | |\n" +
                            "| |    |_|       | |\n" +
                            "| |    (_)       | |\n" +
                            "| |              | |\n" +
                            "| '--------------' |\n" +
                            "'----------------' \n" +
                            "To set up a full backup: Type 1. Then 1.\nTo set up a differential backup: Type 1. Then 2.\nTo start a backup: Type 2. Then press 1.\n" +
                            "To display the settings: Type 3. Then 1.\nTo change the language: Type 4. Then 1.\nTo change the default backup source: Type 4. Then 2. Then 1.\n" +
                            "To clean up the default backup source: Type 4. Then 2. Then 2.\nTo change the default backup target: Type 4. Then 3. Then 1.\nTo clean up the default backup target: Type 4. Then 3. Then 2.\n" +
                            "To clean up the recent source of backups: Type 4. Then 4. Then 1.\nTo clean up the recent target of the backups: Type 4. Then 5. Then 1.\nTo change the retention time: Type 4. Then 6. Then 1." +
                            "To fully clean up the settings: Type 4. Then 7. Then 1. \n1. Return\n2. Exit"
            },
            { "textChooseLanguage", "1. Choose French\n2. Choose English\n3. Return\n4. Exit" },
            { "textChooseNameFullBackup", "Choose a name for your fullbackup :" },
            { "textChooseNameDiffBackup", "Choose a name for your differential backup :" },
            {
                "textShowContentConfig",
                "Language : {0}\nDefault save source : {1}\nDefault save target : {2}\nRecent save source : {3}\nRecent save target : {4}\nRetention time : {5}\nType logs : {6}"
            },
            { "textChangeLanguage", "You should restart to see the changes" },
            { "textChangeDefaultSaveSource", "Give a path to a new default save source" },
            { "textChangeDefaultSaveTarget", "Give a path to a new default save target" },
            { "textRetentionTime", "Give a new retention time (in days)" },
            { "askChoice", "Enter your choice : " },
            { "exit", "Exiting the program..." },
            { "invalid", "Invalid choice. Try again." }
        };
    }
}