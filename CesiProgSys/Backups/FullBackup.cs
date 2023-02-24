using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backups
{
    public class FullBackup : Backup
    {
        public FullBackup(string name, string source, string target)
        {
            this.name = name;
            this.source = source;
            this.target = target;
            this.typeBackup = "FullBackup";
            wait = new ManualResetEventSlim(false);
            stop = new ManualResetEventSlim(true);
            
            authorizedDirAndFiles = new List<Tuple<string, List<FileInfo>>>();
            
            rltInstance = RealTimeLogs.Instance();
            
            info = new Info();
            info.Name = name;
            info.SourceDir = source;
            info.DestDir = target;
            info.Progression = 0;
            info.State = State.INACTIVE;
            info.typeBackup = "FullBackup";
            rltInstance.SetInfo.Add(info);
            rltInstance.wait.Set();

            if (!Program.cli)
                SendPacket(typeBackup, 0, State.INACTIVE);

        }
        
        public override void backup()
        {
            info.State = State.ACTIVE;
            info.Date = DateTime.Now;
            rltInstance.wait.Set();
            if (!Program.cli)
                SendPacket(typeBackup, 0, State.ACTIVE);

            DirectoryInfo targetDirectory = new DirectoryInfo(target);

            if (!targetDirectory.Exists)
            {
                targetDirectory.Create();
            }
            for (int i = authorizedDirAndFiles.Count-1; i >= 0; i--)
            {
                stop.Wait();
                string dir = authorizedDirAndFiles[i].Item1.Substring(info.SourceDir.Length-1);
                DirectoryInfo subDirectory = targetDirectory.CreateSubdirectory(dir);
                foreach (FileInfo sourceFile in authorizedDirAndFiles[i].Item2)
                {
                    stop.Wait();
                    string s = Path.Combine(subDirectory.FullName, sourceFile.Name);

                    info.CurrentSource = sourceFile.Name;
                    info.CurrentDest = s;
                    info.TimeLaps = DateTime.Now - info.Date;
                    rltInstance.wait.Set();
                    
                    sourceFile.CopyTo(s, true);
                    File.SetAttributes(sourceFile.FullName, File.GetAttributes(sourceFile.FullName) & ~FileAttributes.Archive);
                    stop.Wait();
                    info.NbFilesLeftToDo--;
                    info.Progression = 100-info.NbFilesLeftToDo * 100 / info.TotalFilesToCopy;
                    if (!Program.cli)
                        SendPacket(typeBackup, info.Progression, State.ACTIVE);
                }
            }
            info.State = State.SUCCESS;
            rltInstance.wait.Set();
            if (!Program.cli)
                SendPacket(typeBackup, info.Progression, State.SUCCESS);
        }
    }
}