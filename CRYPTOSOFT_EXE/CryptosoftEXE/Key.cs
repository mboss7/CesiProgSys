using System;
using System.Security.Cryptography;
using System.Text;
using Sodium;
using System.Linq;
using System.IO;
using System.Text;


namespace XOREncryption
{
    public class Key
    {
        public void key64Generate()
        {
            byte[] key64generating = new byte[8]; // 8 octets = 64 bits
            
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key64generating);
            }

           
            string theKey = BitConverter.ToString(key64generating);
            Console.WriteLine(theKey);
            
           this.keyVault(theKey);
           
           Console.WriteLine("Clef sauvegardé dans Vault");
        }

        public void keyVault(string theKey)
        {
            string keyToEncrypt = theKey;
            byte[] encryptedKey = ProtectedData.Protect(Encoding.UTF8.GetBytes(keyToEncrypt), null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(@"key.txt", encryptedKey);

        }

        public void keyVaultDecrypt()
        {
    
            Console.WriteLine("Entrer le chemin de la clef :");
            string keyPathRead =  Console.ReadLine();
            byte[] encryptedKey = File.ReadAllBytes(keyPathRead);
            byte[] decryptedKey = ProtectedData.Unprotect(encryptedKey, null, DataProtectionScope.CurrentUser);
            string key = Encoding.UTF8.GetString(decryptedKey);

            Console.WriteLine(key);
        }
    }
}

