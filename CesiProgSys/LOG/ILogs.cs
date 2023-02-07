
namespace CesiProgSys.LOG
{
    //interface for Logs 
    public interface ILogs
    {
        public void startLog();
        public Task logInfo(List<string> toPrint);
        public Task logError(List<string> toPrint);
    }
    
}