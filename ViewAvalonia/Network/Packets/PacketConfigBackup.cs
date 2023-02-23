namespace ViewAvalonia.Network.Packets;

public class PacketConfigBackup : Packet
{

    public PacketConfigBackup()
    {
        id = 0;
    }
    
    public bool typeBackup;
    public string name;
    public string source;
    public string target;
}