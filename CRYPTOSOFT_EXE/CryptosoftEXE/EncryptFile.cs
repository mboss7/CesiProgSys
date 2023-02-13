﻿using System;
using System.IO;

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

            // Read the original file into a byte array
            byte[] originalFile = File.ReadAllBytes(fileName);

            // Encrypt the file
            byte[] encryptedFile = XOREncrypt(originalFile, key);

            // Write the encrypted file
            File.WriteAllBytes(encryptedFileName, encryptedFile);
            
            Console.WriteLine("File encrypted successfully.");
 
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

