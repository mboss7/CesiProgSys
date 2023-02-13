namespace XOREncryption;

public class DecryptFile
{
    
    public void DecryptXOR()
    { 
        //ask the origine path
        Console.WriteLine("Please enter file to encrypt path");
        string fileBrutName = Console.ReadLine();
        string fileName = "./"+fileBrutName+"";
        Console.WriteLine(fileName);
           
        //ask destination path 
        Console.WriteLine("Please enter encrypted file destination path");
        string encryptedBrutFileName = Console.ReadLine();
        string encryptedFileName = "./"+encryptedBrutFileName+"";
        Console.WriteLine(encryptedBrutFileName);
            
        //ask crypt key 
        Console.WriteLine("Please enter your key for encrypt");
        string key = Console.ReadLine();

          

    // Read the encrypted file into a byte array
    byte[] decryptedFile = File.ReadAllBytes(encryptedFileName);

    // Decrypt the file
    decryptedFile = XOREncrypt(decryptedFile, key);

    // Write the decrypted file
    File.WriteAllBytes("decrypted.txt", decryptedFile);

    Console.WriteLine("File encrypted and decrypted successfully.");
}

static byte[] XOREncrypt(byte[] data, string key)
{
    byte[] encryptedData = new byte[data.Length];

    for (int i = 0; i < data.Length; i++)
    {
        encryptedData[i] = (byte)(data[i] ^ key[i % key.Length]);
    }

    return encryptedData;
}
}