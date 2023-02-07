using CesiProgSys.ToolsBox;


namespace CesiProgSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        //create List for log informations
        public static List<Info> listInfo;
        
        // condition for loop while 
        public static bool flagRtl = true;

        
        //Mutex for manage 
        public static Mutex mut = new Mutex();
        
        // start new thread when listInfo is not null  
        public static void startThread()
        {

            RealTimeLogs rtl = new RealTimeLogs();
            rtl.startLog();


        }
        // builder for RealTimeLogs
        public RealTimeLogs()
        {
            listInfo = new List<Info>();
        }
        // Start Log for log generate
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

        // Log type info 
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

        // Log type error 
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
