using CesiProgSys.Backup;
using CesiProgSys.LOG;
using CesiProgSys.ViewCli;
using CesiProgSys.ViewModel.TcpIp;

    namespace CesiProgSys
    {

        public class Program
        {

            static void Main()
            {




                TcpLink tcpLinstenok = new TcpLink();

                tcpLinstenok.TcpListenerLink("127.0.0.1", 8080);

                Console.WriteLine("It's Works ! ");
                Console.ReadLine();

            }
        }
    }

    //public class Program
    //{

    //    static void Main(string[] args)
    //    {
    //        BackupManager.Instance();
    //        LogsManager l = new LogsManager();
    //        l.startLogManager();

    //        Console.WriteLine("\n -----Welcome to the application !----- \n");

    //        Console.ReadKey();

    //        Console.WriteLine("Choose your language:");
    //        Console.WriteLine("1. for English");
    //        Console.WriteLine("2. for French");

    //        Console.Write("Enter your choice : ");
    //        int language;
    //        try
    //        {
    //            language = Convert.ToInt32(Console.ReadLine());
    //        }
    //        catch (FormatException)
    //        {
    //            language = 1;
    //        }

    //        if (language == 2)
    //        {
    //            IViewCli objFr = new ViewCliFr();
    //            objFr.menu();
    //        }
    //        else
    //        {
    //            IViewCli objEn = new ViewCliEn();
    //            objEn.menu();
    //        }
