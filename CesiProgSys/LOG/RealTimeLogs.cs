using System;
using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using CesiProgSys.ToolsBox;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CesiProgSys.LOG
{

    public class RealTimeLogs : ILogs
    {
        public static List<Info> listInfo;

        public static bool flagRtl = true;
       
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
                foreach (Info inf in listInfo)
                {
                    string json = JsonLog.stringToJson(inf);
                    // Console.WriteLine(json);

                    if (inf.LogType)
                    {
                        await logInfo(json);
                    }
                    else
                    {
                        await logError(json);
                    }

                    if (inf.state == State.SUCCESS)
                    {
                        inf.state = State.END;
                        DailyLogs.listInfo.Add(inf);
                    }

                }
            }
        }


        public async Task logInfo(string toPrint)
        {
            using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
            await file.WriteLineAsync(toPrint);

        }



        public async Task logError(string toPrint)
        {
            using StreamWriter file = new(@".\\LOGS\RealTimeLogs.json", append: true);
            await file.WriteLineAsync(toPrint);

        }
    }
}
