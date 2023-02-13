using System;
using System.IO;
using System.Diagnostics;



namespace XOREncryption
{
    public class EncryptPathFile
{
    
        private string path;
        
        private string pathkey;

        public EncryptPathFile()
        {
            path = "test.txt";
         
            pathkey = "test2.txt";
        }
        
        
        // for crypt a file who has path provide in CLI
        public void EncryptXOR(string path, string pathkey)
        {
           
            string encryptedFileName = "./"+path+"";
            
            try
            {   
                var stopwatch = Stopwatch.StartNew();
                
                string key = File.ReadAllText(pathkey);

                // Read the original file into a byte array
                byte[] originalFile = File.ReadAllBytes(encryptedFileName);

                // Encrypt the file
                byte[] encryptedFile = XOREncrypt(originalFile, key);

                // Write the encrypted file
                File.WriteAllBytes(encryptedFileName, encryptedFile);
                
                stopwatch.Stop();
            
                Console.WriteLine("File encrypted successfully.");
                Console.WriteLine("Encryption time: " + stopwatch.Elapsed);
                Console.ReadLine();
                
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("échec");
                throw;
            }
            
        }
        
        
        
        
        
        // For decrypt file in original path
        
        public void DecryptXOR(string path, string pathkey)
        {
            
            ViewCryptosoft vueRtn = new ViewCryptosoft();
           
            try
            {
               
                string encryptedFileName = "./"+path+"";
                
                var stopwatch = Stopwatch.StartNew();
                
                 
                string key = File.ReadAllText(pathkey);

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

