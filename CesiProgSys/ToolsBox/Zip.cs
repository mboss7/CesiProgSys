// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesiProgSys.ToolsBox
{
    // Class for Zip compression
    public class Zip
    {
        // Default constructor
        public Zip(){}

        // Method to compress a directory
        public void compressed(string location, string file)
        {
            // Compress the directory and save the compressed file
            ZipFile.CreateFromDirectory(location, file);
            
            // Check if the file exists
            string path = "C:\\Files\\file.txt";
            bool result = File.Exists(path);
            if (result == true)
            {
                // If file found, print message
                Console.WriteLine("File Found");
            }
            else
            {
                // If file not found, print message
                Console.WriteLine("File Not Found");
            }
        }
    }
}
