using CesiProgSys.ToolsBox;


namespace CesiProgSys.LOG
{

    public class RealTimeLogs : Logs
    {
        // condition for loop while 
        public static bool flagRtl = true;
        
        public static List<Info> listInfo;

        //Mutex for manage 
        public static Mutex mut = new Mutex();

        // builder for RealTimeLogs
        public RealTimeLogs()
        
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
        public async override void startLog()
        {
            DirectoryInfo target = new DirectoryInfo("./LOGS/");
            if(!target.Exists)
                target.Create();
            while (flagRtl)
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
                        {
                            Info.Add(Xml.serialize(inf));
                        }
                        else
                        {
                            Error.Add(Xml.serialize(inf));
                        }
                    }
                    
                }
                mut.ReleaseMutex();
                
                if(Info.Any()) 
                    await log(Info, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
                if(Error.Any()) 
                    await log(Error, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            }
        }
    }
}
