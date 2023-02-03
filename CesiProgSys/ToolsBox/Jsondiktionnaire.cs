namespace CesiProgSys.ToolsBox;

public class Jsondiktionnaire
{
    
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class BackupInfo
{
    public DateTime Timestamp { get; set; }
    public string BackupName { get; set; }
    public string SourceFileAddress { get; set; }
    public string DestinationFileAddress { get; set; }
    public long FileSize { get; set; }
    public long TransferTime { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, object> backupDict = new Dictionary<string, object>
        {
            { "Timestamp", DateTime.Now },
            { "BackupName", "Sample_log.pdf [pdf]" },
            { "SourceFileAddress", @"\\server\source\Sample_log.pdf" },
            { "DestinationFileAddress", @"\\server\destination\Sample_log.pdf" },
            { "FileSize", 10000 },
            { "TransferTime", 500 }
        };

        string json = JsonConvert.SerializeObject(backupDict);
        Console.WriteLine("JSON: " + json);

        BackupInfo backup = JsonConvert.DeserializeObject<BackupInfo>(json);
        Console.WriteLine("Timestamp: " + backup.Timestamp);
        Console.WriteLine("BackupName: " + backup.BackupName);
        Console.WriteLine("SourceFileAddress: " + backup.SourceFileAddress);
        Console.WriteLine("DestinationFileAddress: " + backup.DestinationFileAddress);
        Console.WriteLine("FileSize: " + backup.FileSize);
        Console.WriteLine("TransferTime: " + backup.TransferTime);
    }
}
