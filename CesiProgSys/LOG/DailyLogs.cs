using CesiProgSys.ToolsBox;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs : Logs
     {
         private string pathInfo;
         private string pathError;
         
         private DailyLogs()
        {
            SetInfo = new HashSet<Info>();
            wait = new ManualResetEventSlim(false);
            setPath();
        }
         private static DailyLogs instance;

         public static DailyLogs Instance()
         {
             if (instance == null)
             {
                 instance = new DailyLogs();
             }

             return instance;
         }

         private void setPath()
         {
             DateTime date = DateTime.Now;
             string d = date.Year + "-" + date.Month + "-" + date.Day + "-" + date.Hour;
            
             pathInfo = "./LOGS/DailyLogsInfo-" + d + ".";
             pathError = "./LOGS/DailyLogsError-" + d + ".";
         }

         public override void writeLogs()
        {
            setPath();
            List<string> Info = new List<string>();
            List<string> Error = new List<string>();
            foreach (Info inf in SetInfo)
            {
            //     if (Config.TypeLogs.Equals("json"))
            //     {
            //         if (inf.LogType)
            //             Info.Add(JsonLog.stringToJson(inf));
            //         else
            //             Error.Add(JsonLog.stringToJson(inf));
            //     }
            //     else
            //     {
            if (inf.State == State.ERROR)
                Error.Add(Xml.serialize(inf));
            else
                Info.Add(Xml.serialize(inf));
            //     }
            }
                 
            if(Info.Any())
                log(Info,pathInfo + Config.TypeLogs);
            if(Error.Any())
                log(Error,pathError + Config.TypeLogs);
        }
     }
}
