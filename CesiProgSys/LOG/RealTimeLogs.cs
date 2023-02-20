using CesiProgSys.ToolsBox;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : Logs
    {
        private readonly Logs dlInstance;
        
        // builder for RealTimeLogs
        private RealTimeLogs()
        {
            SetInfo = new HashSet<Info>();
            wait = new ManualResetEventSlim(false);
            dlInstance = DailyLogs.Instance();
        }

        private static RealTimeLogs instance;

        public static RealTimeLogs Instance()
        {
            if (instance == null)
            {
                instance = new RealTimeLogs();
            }

            return instance;
        }
        
        public override void writeLogs()
        {
            List<string> Info = new List<string>(); 
            List<string> Error = new List<string>(); 
            foreach (Info inf in SetInfo) 
            {
                if (inf.State == State.SUCCESS) 
                { 
                    inf.State = State.END; 
                    dlInstance.SetInfo.Add(inf);
                    dlInstance.wait.Set();
                }
                // if (Config.TypeLogs.Equals("json"))
                // {
                //     if (b.LogType)
                //         Info.Add(JsonLog.stringToJson(inf));
                //     else
                //         Error.Add(JsonLog.stringToJson(inf));
                // }
                // else
                // {
                    if (inf.State == State.ERROR)
                        Error.Add(Xml.serialize(inf));
                    else
                        Info.Add(Xml.serialize(inf));
                // }
            }
                
            if(Info.Any()) 
                log(Info, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            if(Error.Any()) 
                log(Error, "./LOGS/RealTimeLogsInfo."+Config.TypeLogs);
            
        }
    }
}
