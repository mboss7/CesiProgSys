using System;
using System.IO;

namespace DetectLogicielMetier
{
    public class DroitFichierLinux
    {

        public void TestDroitFile()
        {
            // Chemin du fichier à vérifier
            string filePath = @".\fichier.txt";

            // Vérifie les droits d'accès du fichier
            if ((File.GetAttributes(filePath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                Console.WriteLine("L'utilisateur n'a pas les droits de modification sur le fichier.");
            }
            else
            {
                Console.WriteLine("L'utilisateur a les droits de modification sur le fichier.");
            }
        }
    
} 
}

