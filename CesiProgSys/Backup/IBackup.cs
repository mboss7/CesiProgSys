namespace CesiProgSys.Backup
{
    public interface IBackup
    {
        public void blockMutex();

        public void releaseMutex();
    }
}