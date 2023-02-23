using ViewAvalonia.ToolBox;

namespace ViewAvalonia.Network.Packets;

public class PacketChangeConfigs : Packet
{
    public PacketChangeConfigs()
    {
        id = 2;
    }

    public Language language;
    public string source;
    public string target;
    public string logs;
    public bool reset;
}