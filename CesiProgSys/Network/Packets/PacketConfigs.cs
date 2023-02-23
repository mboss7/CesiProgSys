using CesiProgSys.ToolsBox;

namespace CesiProgSys.Network.Packets;

public class PacketConfigs : Packet
{
    public PacketConfigs()
    {
        id = 3;
    }

    public Language language;
    public string defaultSource;
    public string defautlTarget;
    public HashSet<string> recentSource;
    public HashSet<string> recentTarget;
    public string typeLogs;
}