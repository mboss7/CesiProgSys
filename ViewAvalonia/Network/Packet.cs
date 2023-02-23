using ViewAvalonia.ToolBox;

namespace ViewAvalonia.Network;

public class Packet     // ConfigBackup : 0, ControlBackup : 1,  ChangeConfigs : 2, Configs : 3, StateBackup : 4
{
    public Packet()
    {
        
    }
    
    public Packet(string typeBackup, string name, string source, string target)
    {
        id = 0;
        this.typeBackup = typeBackup;
        this.name = name;
        this.source = source;
        this.target = target;
    }
    
    public Packet(string control, string name)
    {
        id = 1;
        this.control = control;
        this.name = name;
    }
    
    public Packet(Language l, string source, string target, string logs, bool reset)
    {
        id = 2;
        language = l;
        this.source = source;
        this.target = target;
        this.logs = logs;
        this.reset = reset;
    }
    
    public Packet(Language l, string defaultSource, string defautlTarget, string typeLogs, HashSet<string> recentSource, HashSet<string> recentTarget)
    {
        id = 3;
        language = l;
        this.source = defaultSource;
        this.target = defautlTarget;
        this.logs = typeLogs;
        this.recentSource = recentSource;
        this.recentTarget = recentTarget;
    }
    
    public Packet(string name, int progression, State state, string source, string target, string type)
    {
        id = 4;
        this.name = name;
        this.progression = progression;
        this.state = state;
        this.source = source;
        this.target = target;
        this.typeBackup = type;
    }
    
    public int id;
    public Language language;   //2, 3
    public string source;       //0, 2, 3, 4
    public string target;       //0, 2, 3, 4
    public string logs;         //2, 3
    public bool reset;          //2
    public string typeBackup;     //0, 4
    public string name;         //0, 1, 4
    public State state;         //4
    public int progression;     //4
    public string control;      //1
    public HashSet<string> recentSource;    //3
    public HashSet<string> recentTarget;    //3
}