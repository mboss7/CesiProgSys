using System;
using System.IO;

namespace XOREncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewCryptosoft vue = new ViewCryptosoft();

            EncryptPathFile pathEncrypt = new EncryptPathFile();
            
            
            
            // For make a enter like :  crypto.exe ./path  ./pathkey  -e    (or -d for decrypt)
            if (args.Length > 0)
            {
                string path = args[0];
                
                string pathkey = args[1];
                
                string arg = args[2];
                
                
                Console.WriteLine("Le chemin vers le fichier est et la clef: " + path + pathkey);


                if (arg == "-e")
                {
                    pathEncrypt.EncryptXOR(path, pathkey);
                }
                else if (arg == "-d")
                {
                    pathEncrypt.DecryptXOR(path, pathkey);
                }
                else
                {
                    Console.WriteLine("Please enter a valid arguments like : crypto.exe ./path  ./pathkey  -e    ( for encrypt or -d for decrypt) ");
                }
                
               
                
            }
            else
            {
                vue.ViewLogiciel();
            }
            
            
            
            // ADD EXIT CODE !!! 
        }
    }
}