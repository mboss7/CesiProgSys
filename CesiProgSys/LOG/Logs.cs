
using CesiProgSys.ToolsBox;

namespace CesiProgSys.LOG
{
    //interface for Logs 
    public abstract class Logs
    { 
        public abstract void startLog();

        public async Task log(List<string> toPrint, string path)
        {
            using StreamWriter file = new(path, append: false);
            foreach (string s in toPrint)
            {
                await file.WriteLineAsync(s);
            }
        }
    }
    
}