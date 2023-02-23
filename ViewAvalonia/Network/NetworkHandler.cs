using System.Collections.ObjectModel;
using System.ComponentModel;
using Avalonia.Data;
using ViewAvalonia.ToolBox;
using ViewAvalonia.Views;

namespace ViewAvalonia.Network;

public class NetworkHandler
{

    public event EventHandler stateBackup;
    
    public ManualResetEventSlim wait = new(true);

    private NetworkHandler()
    {
    }

    private static NetworkHandler instance;

    public static NetworkHandler Instance()
    {
        if (instance == null)
        {
            instance = new NetworkHandler();
        }

        return instance;
    }


    public static void threadNetworkHandler()
    {
        NetworkHandler n = Instance();
        string s;

        while (true)
        {
            n.wait.Wait();
            bool dequeue = Server.packets.TryDequeue(out s);


            if (dequeue)
            {
                string[] packet = s.Split("&");

                if (packet[0] == "3")
                {

                }

                if (packet[0] == "4")
                {
                    State state;
                    State.TryParse(packet[5], out state);

                    Backup b = new(packet[1], packet[2], packet[3], packet[6], Int32.Parse(packet[4]), state);

                    n.stateBackup.Invoke(b, EventArgs.Empty);
                }
            }
            else
            {
                n.wait.Reset();
            }
        }
    }
}