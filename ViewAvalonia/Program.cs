using Avalonia;
using ViewAvalonia.Network;
using ViewAvalonia.Views;

namespace ViewAvalonia;

public class Program
{


    
    [STAThread]
    static void Main(string[] args)
    {
        Thread client = new Thread(Client.startClient);
        client.Start("127.0.0.1");
        Thread networkHandler = new Thread(NetworkHandler.threadNetworkHandler);
        networkHandler.Start();
        
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}