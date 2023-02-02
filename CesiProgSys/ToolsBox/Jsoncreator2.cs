using System;
using Newtonsoft.Json;

public class JsonLog
{
    public DateTime Timestamp { get; set; }
    public string BackupName { get; set; }
    public string SourceFileAddress { get; set; }
    public string DestinationFileAddress { get; set; }
    public long FileSize { get; set; }
    public long TransferTime { get; set; }

    public JsonLog(DateTime timestamp, string backupName, string sourceFileAddress, string destinationFileAddress, long fileSize, long transferTime)
    {
        Timestamp = timestamp;
        BackupName = backupName;
        SourceFileAddress = sourceFileAddress;
        DestinationFileAddress = destinationFileAddress;
        FileSize = fileSize;
        TransferTime = transferTime;
    }
}

class Program
{
    static void Jsonlog(string[] args)
    {
        JsonLog backup = new JsonLog(DateTime.Now, "Sample_log.pdf [pdf]", @"\\server\source\Sample_log.pdf", @"\\server\destination\Sample_log.pdf", 10000, 500);
        string json = JsonConvert.SerializeObject(backup);
        Console.WriteLine(json);
    }
}
