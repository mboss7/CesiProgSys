using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ViewAvalonia.ToolBox;
using ViewAvalonia.Network.Packets;

namespace ViewAvalonia.Network;

public static class Server
{

    public static ConcurrentQueue<Packet> packets = new();
    public static void startServer()
    {
        Socket server = Connect();
        Socket client = Accept(server);
        ListenNetwork(client);
    }
    
    private static Socket Connect()
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 9998);
        s.Bind(localEndPoint);
        return s;
    }

    private static Socket Accept(Socket socket)
    {
        socket.Listen();
        return socket.Accept();
    }

    private static void ListenNetwork(Socket client)
    {
        string eom = "<|EOM|>";
        byte[] ack = "<|ACK|>"u8.ToArray();

        while (true)
        {
            byte[] buffer = new byte[1024];
            int length = client.Receive(buffer, SocketFlags.None);
            string response = Encoding.UTF8.GetString(buffer, 0, length);

            if (response.IndexOf(eom, StringComparison.Ordinal) > -1)
            {
                packets.Enqueue(Json.JsonToPacket(response));
                Console.WriteLine("Server received from Client: "  + response.Replace(eom, ""));
                client.Send(ack, 0);
            }
        }
    }
}