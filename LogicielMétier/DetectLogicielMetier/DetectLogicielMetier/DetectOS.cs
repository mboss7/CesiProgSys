using System;


namespace DetectLogicielMetier
{
    
    public class DetectOS
    {
        public string TestOs()
        {

            string osDetected;
            var os = Environment.OSVersion;
            
            osDetected = $"Operating system: {os.Platform} {os.Version}";
            
             Console.WriteLine($"Operating system: {os.Platform} {os.Version}");

            return osDetected;
        }
    }
}

