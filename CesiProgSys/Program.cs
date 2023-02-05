using System;

using CesiProgSys.ViewCli;

namespace CesiProgSys.Program;

public class Program
{
    
    static void Main(string[] args)
    {
        //Console.WriteLine("Bienvenue dans l'application !");
        //Console.ReadKey();
        

        IViewCli objFr = new ViewCliFr();
        objFr.menu();
        
        
    }
}