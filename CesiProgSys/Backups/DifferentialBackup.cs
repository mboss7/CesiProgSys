using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backups
{
    public class DifferentialBackup : Backup
    {
        public DifferentialBackup(string name, string source, string target)
        {
            this.name = name;
            this.source = source;
            this.target = target;
            
            wait = new ManualResetEventSlim(false);
            
            authorizedDirAndFiles = new List<Tuple<string, List<FileInfo>>>();
            
            rltInstance = RealTimeLogs.Instance();
            
            info = new Info();
            info.Name = name;
            info.SourceDir = source;
            info.DestDir = target;
            info.Progression = 0;
            info.State = State.INACTIVE;
            info.typeBackup = "DiffBackup";
            rltInstance.SetInfo.Add(info);
            rltInstance.wait.Set();
        }
        
         public override void backup()
         {
             info.State = State.ACTIVE;
             info.Date = DateTime.Now;
             rltInstance.wait.Set();

             DirectoryInfo targetDirectory = new DirectoryInfo(target);

             if (!targetDirectory.Exists)
             {
                 targetDirectory.Create();
             }
             for (int i = authorizedDirAndFiles.Count-1; i >= 0; i--)
             {
                 string dir = authorizedDirAndFiles[i].Item1.Substring(source.Length-1);
                 DirectoryInfo subDirectory = targetDirectory.CreateSubdirectory(dir);
                 foreach (FileInfo sourceFile in authorizedDirAndFiles[i].Item2)
                 {
                     string s = Path.Combine(subDirectory.FullName, sourceFile.Name);
                     
                     info.CurrentSource = sourceFile.Name;
                     info.CurrentDest = s;
                     info.TimeLaps = DateTime.Now - info.Date;
                     rltInstance.wait.Set();

                     if ((File.GetAttributes(sourceFile.FullName) & FileAttributes.Archive) != 0)
                     {
                         sourceFile.CopyTo(s, true);
                         File.SetAttributes(sourceFile.FullName,
                             File.GetAttributes(sourceFile.FullName) & ~FileAttributes.Archive);
                     }
                     info.NbFilesLeftToDo--;

                 }
             }
             info.State = State.SUCCESS;
             rltInstance.wait.Set();
         }
    }
}