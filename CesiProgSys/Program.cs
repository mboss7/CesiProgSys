using CesiprogSys.LOG;


namespace Programm
{
    public class Program
    {
        public static void Main()
        {
            //Console.Write("{0}\n", Thread.CurrentThread.ManagedThreadId);
            LogsManager l = new LogsManager();
            l.instantiate();
            Thread.Sleep(10000);
            l.finish();
            //Console.Write("La fin du premier thread{0}\n", Thread.CurrentThread.ManagedThreadId);
        }
    }
}


