namespace ViewAvalonia.ToolBox;

public class Backup : ViewModel
{
    public Backup(string name, string source, string target, string type)
    {
        Name = name;
        Source = source;
        Target = target;
        Type = type;
        Progression = 0;
        Etat = State.INACTIVE;
    }
    
    public Backup(string name, string source, string target, string type, int prog, State etat)
    {
        Name = name;
        Source = source;
        Target = target;
        Type = type;
        Progression = prog;
        Etat = etat;
    }
    
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        } 
    }
    private string _source;
    public string Source
    {
        get => _source;
        set
        {
            _source = value;
            OnPropertyChanged();
        } 
    }    
    
    private string _target;
    public string Target
    {
        get => _target;
        set
        {
            _target = value;
            OnPropertyChanged();
        } 
    }    
    
    private string _type;
    public string Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged();
        } 
    }
    
    private State _etat;
    public State Etat
    {
        get => _etat;
        set
        {
            _etat = value;
            OnPropertyChanged();
        } 
    }

    private int _progression;

    public int Progression
    {
        get => _progression;
        set
        {
            _progression = value;
            OnPropertyChanged();
        }
    }
}