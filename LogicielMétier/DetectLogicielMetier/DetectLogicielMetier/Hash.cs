using System;
using System.Security.Cryptography;
using System.Text;

namespace DetectLogicielMetier
{
    public class Hash
    {
        
        string sSourceData;
        byte[] tmpSource;
        byte[] tmpHash;
        

        public Hash()
        {
            this.sSourceData = sSourceData;
            this.tmpSource = tmpSource;
            this.tmpHash = tmpHash;
        }

        public string HashFileGenerator(string pathFileToHash)
        {
            string hashFile;
            hashFile = null;

            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(pathFileToHash))
                {
                    var hashBytes = md5.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                }
            }
        }
        
        public string HashTextGenerator(string SourceHash)
        {
            sSourceData = SourceHash; 
            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            
            
            //Compute hash based on source data.
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            string hashRtn = (ByteArrayToString(tmpHash));
            Console.WriteLine(ByteArrayToString(tmpHash));
            static string ByteArrayToString(byte[] arrInput)
            {
                int i;
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (i=0;i < arrInput.Length; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }
                return sOutput.ToString();
            }

            return hashRtn;
        }

        
        
        public bool HashComparator(string hash1, string hash2)
        {

            bool hashCompareOK;
            if (hash1 == hash2)
            {
                Console.WriteLine("The backup is ok");
                return hashCompareOK = true;
            }
            else
            {
                Console.WriteLine("The backup is corrupt");
                return hashCompareOK = false;

            }
        }
    }
}

