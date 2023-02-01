
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesiProgSys.ToolsBox
{
    public class Zip
    {
        public Zip(){}
        public void compressed(string location, string file)
        {
            
            ZipFile.CreateFromDirectory(location, file);
            
        }
    }
}