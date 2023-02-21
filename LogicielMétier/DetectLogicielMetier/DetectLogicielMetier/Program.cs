
using System.Diagnostics;

namespace DetectLogicielMetier
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ExtensionPrioritaire extensionPrioritaire = new ExtensionPrioritaire();
            
            extensionPrioritaire.ListeMaker();
            
            extensionPrioritaire.ListeTri();
            
            extensionPrioritaire.ListReader();

        }
    }
}