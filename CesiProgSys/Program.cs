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

            if (!result)
            {
                return;
            }
            
            BackupManager.Instance();
            LogsManager l = LogsManager.Instance();
            l.instantiate();

            Console.WriteLine("\n -----Welcome to the application !----- \n");

            Console.ReadKey();

            Config.language = Language.English;
            
            if (Config.language == Language.English)
            {
                ViewCli.ViewCli objEn = new ViewCliEn();
                objEn.menu();
            }
            else if (Config.language == Language.French)
            {
                // ViewCli.ViewCli objFr = new ViewCliFr();
                // objFr.menu();
            }
            else
            {
                ViewCli.ViewCli objEn = new ViewCliEn();
                objEn.menu();
            }
        }
    }
}