using System;
using System.IO;
using System.Security.Cryptography;

namespace FileIntegrityChecker
{
    class Program
    {
        static void Hash(string[] args)
        {
            // The path to the original file
            string originalFilePath = @"C:\path\to\original-file.txt";
            // The path to the saved file
            string savedFilePath = @"C:\path\to\saved-file.txt";

            // Calculate the hash of the original file
            byte[] originalHash = CalculateHash(originalFilePath);

            // Save the file
            File.Copy(originalFilePath, savedFilePath, true);

            // Calculate the hash of the saved file
            byte[] savedHash = CalculateHash(savedFilePath);

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

        // Calculates the hash of a file using MD5
        static byte[] CalculateHash(string filePath)
        {
            // Create an instance of MD5
            using (var md5 = MD5.Create())
            {
                // Open the file
                using (var stream = File.OpenRead(filePath))
                {
                    // Compute the hash of the file contents
                    return md5.ComputeHash(stream);
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
