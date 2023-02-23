using ViewAvalonia.Network.Packets;

namespace ViewAvalonia.Network;

public class NetworkHandler
{
    
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
        Packet p;

        while (true)
        {
            n.wait.Wait();
            bool dequeue = Server.packets.TryDequeue(out p);

            if (dequeue)
            {
                if (p.id == 3)
                {
                    PacketConfigs p1 = (PacketConfigs)p;
                }

                if (p.id == 4)
                {
                    PacketStateBackup p1 = (PacketStateBackup)p;
                }
            }
            else
            {
                n.wait.Reset();
            }
        }
    }
}