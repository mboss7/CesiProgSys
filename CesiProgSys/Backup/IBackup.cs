namespace CesiProgSys.Backup
{
    public interface IBackup
    {
        void setFlagAuth();
        void setFlagStart();

        public void blockMutex();

        public void releaseMutex();
    }
}