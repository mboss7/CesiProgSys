using ViewAvalonia.ToolBox;
namespace ViewAvalonia.Network.Packets;

public class PacketStateBackup : Packet
{
    public PacketStateBackup()
    {
        id = 4;
    }

    public string name;
    public int progression;
    public State state;
    public string source;
    public string target;
    public string type;
}