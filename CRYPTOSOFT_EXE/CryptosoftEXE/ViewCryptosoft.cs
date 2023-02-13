namespace XOREncryption
{
    public class ViewCryptosoft
    {
        
        
        public void ViewLogiciel()
        {
            
            
            Console.WriteLine("Enter 1 for encrypt or 2  for decrypt");
            string Choice = Console.ReadLine();

            EncryptFile encryptFile = new EncryptFile();
            
            switch(Choice) 
            {
                case "1" :
                    encryptFile.EncryptXOR();
                    break;
                case "2":
                    encryptFile.DecryptXOR();
                    break;
               default:
                    Console.WriteLine("Please only enter 1 or 2 ");
                    break;
            }
        }
    }
}

