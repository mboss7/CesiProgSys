using CesiProgSys.ToolsBox;


namespace CesiProgSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        public static List<Info> listInfo;

        public static bool flagRtl = true;

        public static Mutex mut = new Mutex();
            // start new thread when listInfo is not null  
        public static void startThread()
        {

            RealTimeLogs rtl = new RealTimeLogs();
            rtl.startLog();


        }

        public RealTimeLogs()
        {
            listInfo = new List<Info>();
        }

        public async void startLog()
        {
            DirectoryInfo target = new DirectoryInfo("./LOGS/");
            if(!target.Exists)
                target.Create();
            while (flagRtl)
            {
                Thread.Sleep(500);
                List<string> jsonInfo = new List<string>();
                List<string> jsonError = new List<string>();
                mut.WaitOne();
                foreach (Info inf in listInfo)
                {
                    if (inf.LogType)
                        jsonInfo.Add(JsonLog.stringToJson(inf));
                    else
                        jsonError.Add(JsonLog.stringToJson(inf));
                }
                mut.ReleaseMutex();
                
                if(jsonInfo.Any())
                    await logInfo(jsonInfo);
                if(jsonError.Any())
                    await logError(jsonError);
                
            }
        }


        public async Task logInfo(List<string> toPrint)
        {
            if (File.Exists("./LOGS/RealTimeLogsInfo.json"))
                File.Delete("./LOGS/RealTimeLogsInfo.json");
            using StreamWriter file = new(@".\\LOGS\RealTimeLogsInfo.json", append: true);
            foreach (string s in toPrint)
            {
                await file.WriteLineAsync(s);
            }
        }


        public async Task logError(List<string> toPrint)
        {
            if (File.Exists("./LOGS/RealTimeLogsError.json"))
                File.Delete("./LOGS/RealTimeLogsError.json");
            using StreamWriter file = new(@".\\LOGS\RealTimeLogsError.json", append: true);
            foreach (string s in toPrint)
            {
                await file.WriteLineAsync(s);
            }
        }
        
    }
}
