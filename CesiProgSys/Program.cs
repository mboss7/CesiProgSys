
using CesiProgSys.ToolsBox;

namespace CesiProgSys
{
    class Program
    {
        static void Main(string[] args)
        {
            Zip z = new Zip();
            z.compressed(args[0], args[1]);
            JsonLog test = new JsonLog();
            
        }
        
    }
}