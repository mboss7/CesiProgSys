using CesiProgSys.ToolsBox;

namespace CesiProgSys.Network.Packets;

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