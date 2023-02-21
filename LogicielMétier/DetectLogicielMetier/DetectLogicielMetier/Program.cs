
using System.Diagnostics;

namespace DetectLogicielMetier
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Hash hash = new Hash();

            string hash1= hash.HashTextGenerator("Hello");

            string hash2 = hash.HashTextGenerator("Hello2");
            
            hash.HashComparator(hash1, hash2);


        }
    }
}