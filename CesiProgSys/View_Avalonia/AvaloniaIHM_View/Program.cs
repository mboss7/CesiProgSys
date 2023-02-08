using System;

namespace AvaloniaIHM_View
{

    public class Program
    {

        static void Main()
        {
            TcpLinkClient tcpLinstenok = new TcpLinkClient();

            tcpLinstenok.TcpClientLink("127.0.0.1", 8080);

            Console.WriteLine("It's Works ! ");
            Console.ReadLine();

        }
    }
}







//using Avalonia;
//using Avalonia.Controls;
//using Avalonia.Controls.ApplicationLifetimes;
//using System;

//namespace AvaloniaIHM_View
//{
//    internal class Program
//    {
//        // Initialization code. Don't use any Avalonia, third-party APIs or any
//        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
//        // yet and stuff might break.
//        [STAThread]
//        public static void Main(string[] args) => BuildAvaloniaApp()
//            .StartWithClassicDesktopLifetime(args);

//        // Avalonia configuration, don't remove; also used by visual designer.
//        public static AppBuilder BuildAvaloniaApp()
//            => AppBuilder.Configure<App>()
//                .UsePlatformDetect()
//                .LogToTrace();
//    }
//}
