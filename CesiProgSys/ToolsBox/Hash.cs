using System;
using System.IO;
using System.Security.Cryptography;

namespace FileIntegrityChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            // The file path to be checked
            string filePath = @"C:\path\to\file.txt";

            // Calculate the hash of the file before saving
            byte[] originalHash = CalculateHash(filePath);

            // Save the file
            // ...

            // Calculate the hash of the file after saving
            byte[] savedHash = CalculateHash(filePath);

            // Compare the two hashes
            if (CompareHashes(originalHash, savedHash))
            {
                Console.WriteLine("The files are identical.");
            }
            else
            {
                Console.WriteLine("The files are different.");
            }

            Console.ReadKey();
        }

        // Calculates the hash of a file using SHA256
        static byte[] CalculateHash(string filePath)
        {
            // Create an instance of SHA256
            using (var sha256 = SHA256.Create())
            {
                // Open the file
                using (var stream = File.OpenRead(filePath))
                {
                    // Compute the hash of the file contents
                    return sha256.ComputeHash(stream);
                }
            }
        }

        // Compares two hashes
        static bool CompareHashes(byte[] first, byte[] second)
        {
            // If the lengths of the two arrays are different, the hashes are different
            if (first.Length != second.Length)
            {
                return false;
            }

            // Compare the contents of the two arrays
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            // If all elements are equal, the hashes are equal
            return true;
        }
    }
}
