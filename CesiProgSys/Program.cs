using Avalonia;
using CesiProgSys.Backups;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;
using CesiProgSys.ViewCli;
using CesiProgSys.ViewAvalonia;

namespace CesiProgSys
{

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            bool result;
            new Mutex(true, "ID", out result);
            if (!result) return;

            BackupManager.Instance();
            LogsManager l = LogsManager.Instance();
            l.instantiate();

            Config c = Config.Instance();
            c.setConfig();
            c.checkTimeRecentSave();

            if(args.Any())
                if (args[0] == "cli")
                {
                    Console.WriteLine("\n -----Welcome to the application !----- \n");

                    Console.ReadKey();

                    if (c.language == Language.English)
                    {
                        ViewCli.ViewCli objEn = new ViewCliEn();
                        objEn.menu();
                    }
                    else if (c.language == Language.French)
                    {
                        ViewCli.ViewCli objFr = new ViewCliFr();
                        objFr.menu();
                    }
                    else
                    {
                        ViewCli.ViewCli objEn = new ViewCliEn();
                        objEn.menu();
                    }
                }
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}