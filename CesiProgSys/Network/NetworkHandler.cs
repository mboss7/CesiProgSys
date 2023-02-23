using CesiProgSys.Backups;
using CesiProgSys.Network;
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
        string s;

        while (true)
        {
            n.wait.Wait();
            bool dequeue = Server.packets.TryDequeue(out s);

            if (dequeue)
            {
                string[] packet = s.Split("&");

                if (packet[0] == "0")
                {
                    if(packet[1] == "FullBackup")
                        n.instantiateBackup(packet[2], packet[3], packet[4], true);
                    else
                        n.instantiateBackup(packet[2], packet[3], packet[4], false);
                }
                if ( packet[0] == "1")
                {
                    if(packet[1] == "start")
                        n.startBackup(packet[2]);
                    if(packet[1] == "stop")
                        n.stopBackup(packet[2]);
                    if(packet[1] == "restart")
                        n.restartBackup(packet[2]);
                    if(packet[1] == "kill")
                        n.killBackup(packet[2]);
                }
                // if (packet[0] == "2")
                // {
                //     if (p.language != null)
                //     {
                //         n.changeLanguage(p.language);
                //     }
                //     if (p.source != null)
                //     {
                //         n.changeDefaultSaveSource(p.source);
                //     }
                //     if (p.target != null)
                //     {
                //         n.changeDefaultSaveTarget(p.target);
                //     }
                //     if (p.logs != null)
                //     {
                //         n.changeTypeLogs(p.logs);
                //     }
                //     if (p.reset)
                //     {
                //         n.resetConfig();
                //     }
                // }
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