using System.ComponentModel;
using System.Runtime.CompilerServices;
using CesiProgSys.Backups;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : Logs
    {
        public static HashSet<Backup>? SetBackup;

        public static event EventHandler? writeLog;

        // builder for RealTimeLogs
        private RealTimeLogs()
        {
            SetBackup = new HashSet<Backup>();
        }
        
        // start new thread when listInfo is not null  
        public static void startThread()
        {
            RealTimeLogs rtl = new RealTimeLogs();
            Thread.CurrentThread.
            rtl.startLog();
        }

        // Start Log for log generate
        protected override void startLog()
        {
            DirectoryInfo target = new DirectoryInfo("./LOGS/");
            if(!target.Exists)
                target.Create();

            writeLog += writeLogs;
        }

        protected override void writeLogs(object? sender, EventArgs e)
        {
            SetBackup.Add((Backup)sender);
            List<string> Info = new List<string>(); 
            List<string> Error = new List<string>(); 
            foreach (Backup b in SetBackup) 
            {
                if (b.State == State.SUCCESS) 
                { 
                    b.State = State.END; 
                    DailyLogs.listInfo.Add(b);
                    DailyLogs.OnWriteLog();
                }
                // if (Config.TypeLogs.Equals("json"))
                // {
                //     if (b.LogType)
                //         Info.Add(JsonLog.stringToJson(b));
                //     else
                //         Error.Add(JsonLog.stringToJson(b));
                // }
                // else
                // {
                    // if (b.LogType)
                        Info.Add(Xml.serialize(b));
                    // else
                        // Error.Add(Xml.serialize(b));
                // }
            }
                
            if(Info.Any()) 
                log(Info, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            if(Error.Any()) 
                log(Error, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            
        }

        public static void OnWriteLog(Backup backup)
        {
            writeLog?.Invoke(backup, EventArgs.Empty);
        }
    }
}
