using System;
using CesiProgSys.ViewCli;

namespace CesiProgSys.Program;

public class Program
{
    
    static void Main(string[] args)
    {
        IViewCli option1 = new ViewCliFr();
        //IViewCli option2 = new Option2();
        option1.menu();
        
    }
}