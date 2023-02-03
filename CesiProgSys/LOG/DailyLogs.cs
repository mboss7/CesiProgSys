 using System;
 using System;
 using System.IO;
 using System.Text.Json.Nodes;
 using System.Threading;

 namespace CesiProgSys.LOG
 {
     public class DailyLogs : ILogs
     {
         public static bool flagDl = true;
       // start new thread
         public static void startThread()
         {
             // print current thread ID 
             Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
         
             // Loop who write DailyLogs file. 
             while (flagDl)
             {
                if(true) 
                {
                     //Pass the filepath and filename to the StreamWriter Constructor
                     StreamWriter sw = new StreamWriter(@".\\DailyLogs.txt");  // change in Json file (when it will be ok). 
                     //Write a line of text
                     sw.WriteLine("Daily Logs File");
                     //Write a second line of text
                     sw.WriteLine("DailyLogs Run : OK");
                     //Close the file
                     sw.Close();
                }
             }
         }

         // Create new start log info 
         public void startLog()
         {
             //create log file
            // write start Log info in Json log file. 


             //Pass the filepath and filename to the StreamWriter Constructor
            // StreamWriter sw = new StreamWriter(@".\\DailyLogs.txt");  // change in Json file (when it will be ok). 
                                                                          //Write a line of text
            // sw.WriteLine("Hello World!!");
             //Write a second line of text
           //  sw.WriteLine("From the StreamWriter class");
             //Close the file
           //  sw.Close();

         }
         // write new logs infos 
         public void logInfo()
         {
             // write log info in Json Log file
         }
         // write new logs errors 
         public void logError()
         {
             // write log error in Json Log file
         }
     }
 }