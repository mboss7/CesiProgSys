
using System.Diagnostics;

namespace DetectLogicielMetier
{
    public class Program
    {
        public static void Main(string[] args)
        {

            DetectOS detectOs = new DetectOS();
            detectOs.TestOs();
            

        }
    }
}