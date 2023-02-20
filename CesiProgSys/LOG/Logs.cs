using CesiProgSys.ToolsBox;

namespace CesiProgSys.LOG
{
    //interface for Logs 
    public abstract class Logs
    { 
        public ManualResetEventSlim wait;
        public HashSet<Info> SetInfo;
        protected Config config;
        
        public void startLog()
        {
            DirectoryInfo target = new DirectoryInfo("./LOGS/");
            if(!target.Exists)
                target.Create();
        }
        protected void log(List<string> toPrint, string path)
        {
            using StreamWriter file = new(path, append: false);
            foreach (string s in toPrint)
            {
                file.WriteLine(s);
            }
        }

        public abstract void writeLogs();



    }
    
}