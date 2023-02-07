
using CesiProgSys.ToolsBox;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs 
         // : ILogs
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
                foreach (Info inf in listInfo)
                {
                    string json = JsonLog.stringToJson(inf);
                    //Console.WriteLine(json);

                    if (inf.LogType)
                    {
                        // logInfo(json);
                    }
                    else
                    {
                        // logError(json);
                    }
                }
            }
        }

        // public void logInfo(string toPrint)
        // {
        //     
        //             StreamWriter file = new(@".\\LOGS\DailyLogs.json", append: true);
        //             file.WriteLineAsync(toPrint);
        // }
        //
        //
        // public void logError(string toPrint)
        // {
        //             StreamWriter file = new(@".\\LOGS\DailyLogs.json", append: true);
        //             file.WriteLineAsync(toPrint);
        // }
     }
}
