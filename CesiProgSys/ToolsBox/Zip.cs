
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
            //string outputFile = @"F:\output;zip";
            //string fileToZip = @"F:\STAGE A4 19-20.xlsx";
            string outputFile = location;
            string fileToZip = file;
            //using (var archive = ZipFile.Open(outputFile, ZipArchiveMode.Create))
            //{
              //  archive.CreateEntryFromFile(fileToZip, Path.GetFileName(fileToZip));
            //}
            ZipFile.Open();
        }
    }
}