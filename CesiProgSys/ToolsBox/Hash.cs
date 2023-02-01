using System.Security.Cryptography;

namespace CesiProgSys.ToolsBox;

// Method to get file name and hash combined of a file
public string GetFileNameAndMD5Hash(FileInfo file)
{
    using (var md5 = MD5.Create())
    {
        using (var stream = File.OpenRead(file.FullName))
        {
            var hash = md5.ComputeHash(stream);
            return (file.Name+BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());
        }
    }
}