
namespace CesiProgSys.ToolsBox;
public class Info
{
    public bool LogType { get; set; }
    
    public DateTime Date { get; set; }
    public TimeSpan TimeLaps { get; set; }
    
    public string Name { get; set; }
    public string DirSource { get; set; }
    public string DirTarget { get; set; }
    public string CurrentSource { get; set; }
    public string CurrentDest { get; set; }
    public int TotalFilesToCopy { get; set; }
    public long TotalFilesSize { get; set; }
    public int NbFilesLeftToDo { get; set; }
    public State state { get; set; }
    public float progression { get; set; }
}
