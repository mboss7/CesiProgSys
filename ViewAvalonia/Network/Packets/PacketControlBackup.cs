namespace ViewAvalonia.Network.Packets;

public class PacketControlBackup : Packet
{
    public PacketControlBackup()
    {
        id = 1;
    }

    public string control; //start - stop - restart - kill
    public string name;
}