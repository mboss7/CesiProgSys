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

        
        
        public void HashComparator(string hash1, string hash2)
        {
            
        }
    }
}

