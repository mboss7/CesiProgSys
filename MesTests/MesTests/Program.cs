using System;
using System.Runtime.CompilerServices;
using System.IO;

// https://waytolearnx.com/2017/04/programmation-en-c-linstruction-break.html
namespace MesTests
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            string A = "0"; 

            do
            {
                Console.WriteLine("Mon logiciel Test BckApp \n");

                Console.WriteLine("Pour afficher les infos du disk, taper 1\nPour afficher la liste des fichiers, taper 2\n Quit taper 9");
                A = Console.ReadLine();

                if (A == "1")
                {

                    Console.WriteLine("Information du Disk :\n");

                    DriveInfo[] drivesInfo = DriveInfo.GetDrives();
                    foreach (DriveInfo driveInfo in drivesInfo)
                    {
                        Console.WriteLine("Lecteur {0}", driveInfo.Name);
                        Console.WriteLine("  Type:{0}", driveInfo.DriveType);

                        if (driveInfo.IsReady == true)
                        {
                            Console.WriteLine("  Label:{0}", driveInfo.VolumeLabel);
                            Console.WriteLine("  Systeme de fichier:{0}", driveInfo.DriveFormat);
                            Console.WriteLine("  Espace disponible:{0} bytes", driveInfo.TotalFreeSpace);
                            Console.WriteLine("  Espace total:{0} bytes", driveInfo.TotalSize);
                        }
                    }

                }
                else if (A == "2")
                {
                    Console.WriteLine("\nListe des fichiers : \n");
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");

                        DirectoryInfo[] subDirectories = directoryInfo.GetDirectories("*");

                        foreach (DirectoryInfo subDirectory in subDirectories)
                        {
                            Console.WriteLine(subDirectory.Name);
                        }
                    }

                }
                else if (A == "3")
                {
                 
                }
                else;
                {

                }
            } while ( A != "9");

        }
    }
}

