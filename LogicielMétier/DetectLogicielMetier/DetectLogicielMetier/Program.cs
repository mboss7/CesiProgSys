
using System.Diagnostics;

namespace DetectLogicielMetier
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Hash hash = new Hash();

            string hash1 = hash.HashFileGenerator(@"fichier.txt");
            Console.WriteLine(hash1);

        }
    }
}