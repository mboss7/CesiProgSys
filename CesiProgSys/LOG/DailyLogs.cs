using CesiProgSys.Backups;
using CesiProgSys.ToolsBox;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs : Logs
     {
         private string pathInfo;
         private string pathError;
         private DateTime date;
         public static List<Backup>? listInfo;

         public static event EventHandler? writeLog;

         private DailyLogs()
        {
            listInfo = new List<Backup>();
            setPath();
        }

         private void setPath()
         {
             date = DateTime.Now;
             string d = date.Year + "-" + date.Month + "-" + date.Day + "-" + date.Hour + "-" + date.Minute;
            
             pathInfo = "./LOGS/DailyLogsInfo-" + d + ".";
             pathError = "./LOGS/DailyLogsError-" + d + ".";
         }
         
        // start new thread when listInfo is not null  
        public static void startThread()
        {
            DailyLogs dl = new DailyLogs();
            dl.startLog();
        }

        //Start log management        
        protected override void startLog()
        {
            writeLog += writeLogs;
        }

        protected override void writeLogs(object? sender, EventArgs e)
        {
            List<string> Info = new List<string>();
            List<string> Error = new List<string>();
            // RealTimeLogs.mut.WaitOne();
            // foreach (Backup inf in listInfo)
            // {
            //     if (Config.TypeLogs.Equals("json"))
            //     {
            //         if (inf.LogType)
            //             Info.Add(JsonLog.stringToJson(inf));
            //         else
            //             Error.Add(JsonLog.stringToJson(inf));
            //     }
            //     else
            //     {
            //         if (inf.LogType)
            //             Info.Add(Xml.serialize(inf));
            //         else
            //             Error.Add(Xml.serialize(inf));
            //     }
            // }
            // RealTimeLogs.mut.ReleaseMutex();
            //     
            // if(Info.Any())
            //     log(Info,pathInfo + Config.TypeLogs);
            // if(Error.Any())
            //     log(Error,pathError + Config.TypeLogs);
        }

        public static void OnWriteLog()
        {
            writeLog?.Invoke(null, EventArgs.Empty);
        }
     }
}
