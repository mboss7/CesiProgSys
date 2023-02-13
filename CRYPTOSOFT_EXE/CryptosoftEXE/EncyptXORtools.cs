namespace XOREncryption;

public class EncyptXORtools
{
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