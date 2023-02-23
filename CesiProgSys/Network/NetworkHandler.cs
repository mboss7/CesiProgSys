using CesiProgSys.Backups;
using CesiProgSys.Network.Packets;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Network;

public class NetworkHandler
{
    private BackupManager bManager;
    private List<Backup> backups;
    private Config config;

    public ManualResetEventSlim wait = new(true);
    
    private NetworkHandler()
    {
        bManager = BackupManager.Instance();
        backups = bManager.listBackupReady;
        config = Config.Instance();
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
                if (p.id == 0)
                {
                    PacketConfigBackup p1 = (PacketConfigBackup)p;
                    n.instantiateBackup(p1.name, p1.source, p1.target, p1.typeBackup);
                }
                if (p.id == 1)
                {
                    PacketControlBackup p1 = (PacketControlBackup)p;
                    if(p1.control == "start")
                        n.startBackup(p1.name);
                    if(p1.control == "stop")
                        n.stopBackup(p1.name);
                    if(p1.control == "restart")
                        n.restartBackup(p1.name);
                    if(p1.control == "kill")
                        n.killBackup(p1.name);
                }
                if (p.id == 2)
                {
                    PacketChangeConfigs p1 = (PacketChangeConfigs)p;
                    if (p1.language != null)
                    {
                        n.changeLanguage(p1.language);
                    }
                    if (p1.source != null)
                    {
                        n.changeDefaultSaveSource(p1.source);
                    }
                    if (p1.target != null)
                    {
                        n.changeDefaultSaveTarget(p1.target);
                    }
                    if (p1.logs != null)
                    {
                        n.changeTypeLogs(p1.logs);
                    }
                    if (p1.reset)
                    {
                        n.resetConfig();
                    }
                }
            }
            else
            {
                n.wait.Reset();
            }
        }
    }
    
    
    
    public void instantiateBackup(string name, string sourceDir, string targetDir, bool type)
    {
        bManager.instantiate(name, sourceDir, targetDir, type);
        config.addToSet(sourceDir, config.recentSaveSource);
        config.addToSet(targetDir, config.recentSaveTarget);
    }



    public void startBackup(string name)
    {
        bManager.startBackup(backups.Find(backup => backup.name == name));
    }

    public void stopBackup(string name)
    {
    }

    public void restartBackup(string name)
    {
    }

    public void killBackup(string name)
    {
    }


    public void changeLanguage(Language l)
    {
        config.language = l;
    }

    public void changeDefaultSaveSource(string s)
    {
        config.defaultSaveSource = s;
    }

    public void changeDefaultSaveTarget(string s)
    {
        config.defaultSaveTarget = s;
    }

    public void resetConfig()
    {
        config.resetConfig();
    }

    public void changeTypeLogs(string s)
    {
        if(!(s != "xml" && s != "json"))
            config.typeLogs = s;
    }
}