namespace CesiProgSys.LOG
{
    //interface for Logs 
    public abstract class Logs
    { 
        protected abstract void startLog();

        protected void log(List<string> toPrint, string path)
        {
            using StreamWriter file = new(path, append: false);
            foreach (string s in toPrint)
            {
                file.WriteLine(s);
            }
        }

        protected abstract void writeLogs(object sender, EventArgs e);
    }
    
}