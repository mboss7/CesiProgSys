using System.Collections;
using CesiProgSys.Backups;
using CesiProgSys.LOG;
using CesiProgSys.Network;
using CesiProgSys.ToolsBox;
using CesiProgSys.ViewCli;

namespace CesiProgSys
{

    public class Program
    {
        public static bool cli = true;
        
        static void Main(string[] args)
        {

            string[] ipport = new string[2]{"localhost","1234"};

            ThreadForTcp threadForTcp = new ThreadForTcp();
            threadForTcp.ServerTcpThreadRun(ipport);
            threadForTcp.ClientTcpThreadRun(ipport);

            /*
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

            cli = false;
            Thread server = new Thread(Server.startServer);
            server.Start();
            c.SendConfig();
            Thread networkHandler = new Thread(NetworkHandler.threadNetworkHandler);
            networkHandler.Start();
            */

        }
    }
}