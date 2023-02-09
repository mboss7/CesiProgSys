using CesiProgSys.ToolsBox;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : Logs
    {
        public static List<Info>? listInfo;

        //Mutex for manage 
        public static Mutex mut = new Mutex();

        public static event EventHandler? writeLog;

        // builder for RealTimeLogs
        private RealTimeLogs()
        {
            listInfo = new List<Info>();
        }
        
        // start new thread when listInfo is not null  
        public static void startThread()
        {
            RealTimeLogs rtl = new RealTimeLogs();
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
            List<string> Info = new List<string>(); 
            List<string> Error = new List<string>(); 
            mut.WaitOne(); 
            foreach (Info inf in listInfo) 
            {
                if (inf.state == State.SUCCESS) 
                { 
                    inf.state = State.END; 
                    DailyLogs.listInfo.Add(inf);
                    DailyLogs.OnWriteLog();
                }
                if (Config.TypeLogs.Equals("json"))
                {
                    if (inf.LogType)
                        Info.Add(JsonLog.stringToJson(inf));
                    else
                        Error.Add(JsonLog.stringToJson(inf));
                }
                else
                {
                    if (inf.LogType)
                        Info.Add(Xml.serialize(inf));
                    else
                        Error.Add(Xml.serialize(inf));
                }
            }
            mut.ReleaseMutex();
                
            if(Info.Any()) 
                log(Info, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            if(Error.Any()) 
                log(Error, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            
        }

        public static void OnWriteLog()
        {
            writeLog?.Invoke(null, EventArgs.Empty);
        }
    }
}
