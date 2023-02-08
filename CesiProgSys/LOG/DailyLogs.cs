
using System.Runtime.InteropServices.JavaScript;
using CesiProgSys.ToolsBox;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs : Logs
     {
         // condition for loop while 
         public static bool flagDl = true;

         public static List<Info> listInfo;

         private string pathInfo;
         private string pathError;

         public DailyLogs()
        {
            listInfo = new List<Info>();
            DateTime date = DateTime.Today;
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
        public async override void startLog()
        {
            while (flagDl)
            {
                List<string> Info = new List<string>();
                List<string> Error = new List<string>();
                
                RealTimeLogs.mut.WaitOne();
                foreach (Info inf in listInfo)
                {
                    if (Config.TypeLogs.Equals("json"))
                    {
                        if (inf.LogType)
                        {
                            Info.Add(JsonLog.stringToJson(inf));
                        }
                        else
                        {
                            Error.Add(JsonLog.stringToJson(inf));
                        }
                    }
                    else
                    {
                        if (inf.LogType)
                        {
                            Info.Add(Xml.serialize(inf));
                        }
                        else
                        {
                            Error.Add(Xml.serialize(inf));
                        }
                    }
                }
                RealTimeLogs.mut.ReleaseMutex();
                
                if(Info.Any())
                    await log(Info,pathInfo + Config.TypeLogs);
                if(Error.Any())
                    await log(Error,pathError + Config.TypeLogs);
            }
        }
     }
}
