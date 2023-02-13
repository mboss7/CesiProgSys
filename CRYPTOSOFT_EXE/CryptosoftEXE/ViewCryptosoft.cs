namespace XOREncryption
{
    public class ViewCryptosoft
    {
        
        
        public void ViewLogiciel()
        {
            
            Console.Clear();
            Console.WriteLine("Enter [1] for encrypt, [2]  for decrypt, [3] for generate key in 64 bit or [4] for see key backup in a file");
            string Choice = Console.ReadLine();

            EncryptFile encryptFile = new EncryptFile();

            Key key64 = new Key();
            
            switch(Choice) 
            {
                case "1" :
                    encryptFile.EncryptXOR();
                    break;
                case "2":
                    encryptFile.DecryptXOR();
                    break;
                case "3":
                    key64.key64Generate();
                     break;
                case "4":
                    key64.keyVaultDecrypt();
                    break;
               default:
                    Console.WriteLine("Please only enter 1 or 2 ");
                    break;
            }
        }
    }
}

