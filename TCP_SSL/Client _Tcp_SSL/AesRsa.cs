using System;
using System.Security.Cryptography;
using System.Text;

namespace Tcp_Ssl;


class AesRsaEncryption
{
    public void AesRsaRun()
    {
        // Créer une clé de chiffrement AES
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        aes.GenerateKey();
        byte[] aesKey = aes.Key;
        
        // Créer une clé publique / privée RSA
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        
        // Chiffrer la clé de chiffrement AES avec la clé publique RSA
        byte[] encryptedAesKey = rsa.Encrypt(aesKey, false);

        // Exporter la clé publique RSA pour envoyer au destinataire
        string publicKeyXml = rsa.ToXmlString(false);

        // Chiffrer les données avec AES
        byte[] plaintextData = Encoding.UTF8.GetBytes("Hello, world!");
        byte[] encryptedData = null;
        using (ICryptoTransform encryptor = aes.CreateEncryptor())
        {
            encryptedData = encryptor.TransformFinalBlock(plaintextData, 0, plaintextData.Length);
        }

/*
        // Envoyer la clé de chiffrement AES chiffrée et les données chiffrées au destinataire
        // ...

        // Le destinataire peut récupérer la clé privée RSA et déchiffrer la clé de chiffrement AES
        RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider();
        rsa2.FromXmlString(privateKeyXml);
        byte[] decryptedAesKey = rsa2.Decrypt(encryptedAesKey, false);

        // Le destinataire peut utiliser la clé de chiffrement AES pour déchiffrer les données
        AesCryptoServiceProvider aes2 = new AesCryptoServiceProvider();
        aes2.Key = decryptedAesKey;
        byte[] decryptedData = null;
        using (ICryptoTransform decryptor = aes2.CreateDecryptor())
        {
            decryptedData = decryptor.TransformFinalBlock(encryptedData, 0, encrypted
*/
    }
        
}