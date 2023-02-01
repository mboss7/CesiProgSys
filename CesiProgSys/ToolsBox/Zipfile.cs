
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesiProgSys.ToolsBox
{
    public class Zipfile
    {
        public static void Main()
        {
            string outputFile = "";
            string fileToZip = "";
            using (var archive = ZipFile.Open(outputFile, ZipArchiveMode.Create)) 
            {
                archive.CreateEntryFromFile(fileToZip, Path.GetFileName(fileToZip));
            }

        }
    }
}