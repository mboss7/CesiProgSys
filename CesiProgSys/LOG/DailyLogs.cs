
using CesiProgSys.ToolsBox;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs //: ILogs
     {
        // create list of info object who trigg the thread methode  
        public static List<Info> listInfo;
        public static bool flagDl = true;

        public DailyLogs()
        {
            listInfo = new List<Info>();
        }

        // start new thread when listInfo is not null  
        public static void startThread()
        {
            DailyLogs dl = new DailyLogs();
            dl.startLog();
        }

        //Start log management        
        public async void  startLog()
        {
            while (flagDl)
            {
                List<string> jsonInfo = new List<string>();
                List<string> jsonError = new List<string>();
                
                RealTimeLogs.mut.WaitOne();
                foreach (Info inf in listInfo)
                {
                    if (inf.LogType)
                    {
                        jsonInfo.Add(JsonLog.stringToJson(inf));
                    }
                    else
                    {
                        jsonError.Add(JsonLog.stringToJson(inf));
                    }
                }
                RealTimeLogs.mut.ReleaseMutex();
                
                if(jsonInfo.Any())
                    await logInfo(jsonInfo);
                if(jsonError.Any())
                    await logError(jsonError);
            }
        }

        public async Task logInfo(List<string> toPrint)
        {
            if (File.Exists("./LOGS/DailyLogsInfo.json"))
                File.Delete("./LOGS/DailyLogsInfo.json");
            using StreamWriter file = new(@".\\LOGS\DailyLogsInfo.json", append: true);
            foreach (string s in toPrint)
            {
                await file.WriteLineAsync(s);
            }
        }
        
        public async Task logError(List<string> toPrint)
        {
            if (File.Exists("./LOGS/DailyLogsError.json"))
                File.Delete("./LOGS/DailyLogsError.json");
            using StreamWriter file = new(@".\\LOGS\DailyLogsError.json", append: true);
            foreach (string s in toPrint)
            {
                await file.WriteLineAsync(s);
            }
        }
     }
}
