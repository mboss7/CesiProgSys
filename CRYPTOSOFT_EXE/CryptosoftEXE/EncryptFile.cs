using System;
using System.IO;
using System.Diagnostics;

namespace XOREncryption
{
    public class EncryptFile
    {
        private string fileNameBrut;
        private string fileName;

        public EncryptFile()
        {
            fileNameBrut = "";
            fileName = "";
        }
        
        
        
        public void EncryptXOR()
        {
               ViewCryptosoft vueRtn = new ViewCryptosoft();
            
           
            
               //ask the origine path
               Console.WriteLine("Please enter file to encrypt path");
               string fileBrutName = Console.ReadLine();
               string fileName = "./"+fileBrutName+"";
               Console.WriteLine(fileName);

            
                //ask destination path 
                Console.WriteLine("Please enter encrypted file destination path");
                string encryptedBrutFileName = Console.ReadLine();
                string encryptedFileName = "./"+encryptedBrutFileName+"";
                Console.WriteLine(encryptedBrutFileName);
            
                //ask crypt key 
                Console.WriteLine("Please enter your key for encrypt");
                string key = Console.ReadLine();
                
            try
            {   
                var stopwatch = Stopwatch.StartNew();

                // Read the original file into a byte array
                byte[] originalFile = File.ReadAllBytes(fileName);

                // Encrypt the file
                byte[] encryptedFile = XOREncrypt(originalFile, key);

                // Write the encrypted file
                File.WriteAllBytes(encryptedFileName, encryptedFile);
                
                stopwatch.Stop();
            
                Console.WriteLine("File encrypted successfully.");
                Console.WriteLine("Encryption time: " + stopwatch.Elapsed);
                Console.ReadLine();
                
                vueRtn.ViewLogiciel();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("échec");
                throw;
            }
            
        }
        
        
        
        
        
        // For decrypt file in original path
        
        public void DecryptXOR()
        {
            
            ViewCryptosoft vueRtn = new ViewCryptosoft();
           
            try
            {
                //ask the origine path
                Console.WriteLine("Please enter file to decrypt path");
                string encryptedBrutFileName = Console.ReadLine();
                string encryptedFileName = "./"+encryptedBrutFileName+"";
                
                //ask destination path 
                //Console.WriteLine("Please enter decrypted file destination path");
               // string fileBrutName = Console.ReadLine();
               // string fileName = "./"+fileBrutName+"";
                //Console.WriteLine(fileName);
            
                //ask crypt key 
                Console.WriteLine("Please enter your key for decrypt");
                string key = Console.ReadLine();

          
                var stopwatch = Stopwatch.StartNew();

                // Read the encrypted file into a byte array
                byte[] decryptedFile = File.ReadAllBytes(encryptedFileName);

                // Decrypt the file
                decryptedFile = XOREncrypt(decryptedFile, key);

                // Write the decrypted file
                File.WriteAllBytes(encryptedFileName, decryptedFile);
                
                stopwatch.Stop();

                Console.WriteLine("File decrypted successfully.");
                Console.WriteLine("Encryption time: " + stopwatch.Elapsed);
                Console.ReadLine();
                
                vueRtn.ViewLogiciel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        static byte[] XOREncrypt(byte[] data, string key)
        {
            byte[] encryptedData = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = (byte)(data[i] ^ key[i % key.Length]);
            }

            return encryptedData;
        }

    }
    
}

