using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ViewAvalonia.Network;

public static class Client
{
    public static ConcurrentQueue<string> packets = new();
    public static ManualResetEventSlim wait = new(true);
    
    public static void startClient(object obj)
    {
        string ip = (string)obj;
        
        Socket client = Connect(ip);
        createServer();
        byte[] temp = "<|AOE|>"u8.ToArray();
        client.Send(temp);
        SendNetwork(client);
    }
    
    private static Socket Connect(string ip)
    {
        IPEndPoint ipEndPoint = new(IPAddress.Parse(ip), 9999);
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect(ipEndPoint);
        return s;
    }

    private static void createServer()
    {
        Thread t = new Thread(Server.startServer);
        t.Start();
    }
    
    private static void SendNetwork(Socket client)
    {
        while (true)
        {
            wait.Wait();
            string temp;
            bool dequeue = packets.TryDequeue(out temp);
            if (dequeue)
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(string.Concat(temp, "<|EOM|>"));

                client.Send(messageBytes, SocketFlags.None);
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int length = client.Receive(buffer, SocketFlags.None);
                    string response = Encoding.UTF8.GetString(buffer, 0, length);
                    if (response == "<|ACK|>")
                    {
                        break;
                    }
                }
            }
            else
            {
                wait.Reset();
            }
        }
    }
}