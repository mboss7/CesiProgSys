using System;

using CesiProgSys.ViewCli;

namespace CesiProgSys.Program;

public class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("\n -----Welcome to the application !----- \n");
        
        Console.ReadKey();
        
        Console.WriteLine("Choose your language:");
        Console.WriteLine("1. for English");
        Console.WriteLine("2. for French");
        
        Console.Write("Enter your choice : ");
        int language = Convert.ToInt32(Console.ReadLine());

        if (language == 1)
        {
            IViewCli objEn = new ViewCliEn();
            objEn.menu();
            objEn.configBackup();
            objEn.fullBackup();
            objEn.diffBackup();
            objEn.startBackup();
            objEn.startBackupValid();
            objEn.showConfig();
            objEn.showConfigValid();
            objEn.changeConfig();
            objEn.help();
        }
        else if (language == 2)
        {
            IViewCli objFr = new ViewCliFr();
            objFr.menu();
            objFr.configBackup();
            objFr.fullBackup();
            objFr.diffBackup();
            objFr.startBackup();
            objFr.startBackupValid();
            objFr.showConfig();
            objFr.showConfigValid();
            objFr.changeConfig();
            objFr.help();
        }
        else
        {
            Console.WriteLine("Invalid language selection");
        }

        
        
    }
}