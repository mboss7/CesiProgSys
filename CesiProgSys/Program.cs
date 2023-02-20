using CesiProgSys.Backups;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;
using CesiProgSys.ViewCli;

namespace CesiProgSys
{

    public class Program
    {

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
    }
}