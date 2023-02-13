using System.Security.AccessControl;
using System.Security.Principal;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backups
{
    public class FullBackup : Backup
    {
        
        private List<Tuple<string, List<FileInfo>>> authorizedDirAndFiles;

        public FullBackup(string name, string source, string target)
        {
            authorizedDirAndFiles = new List<Tuple<string, List<FileInfo>>>();
            Name = name;
            SourceDir = source;
            DestDir = target;
            Progression = 0;
            State = State.INACTIVE;
        }
        public FullBackup(){}
        
        protected override async void backup()
        {
            State = State.ACTIVE;

            DirectoryInfo targetDirectory = new DirectoryInfo(DestDir);

            if (!targetDirectory.Exists)
            {
                targetDirectory.Create();
            }
            for (int i = authorizedDirAndFiles.Count-1; i >= 0; i--)
            {
                string dir = authorizedDirAndFiles[i].Item1.Substring(SourceDir.Length-1);
                // dir = !string.IsNullOrEmpty(dir) ? dir : inf.Name;
                DirectoryInfo subDirectory = targetDirectory.CreateSubdirectory(dir);
                foreach (FileInfo sourceFile in authorizedDirAndFiles[i].Item2)
                {
                    string s = Path.Combine(subDirectory.FullName, sourceFile.Name);

                    CurrentSource = sourceFile.Name;
                    CurrentDest = s;
                    TimeLaps = DateTime.Now - Date;

                    sourceFile.CopyTo(s, true);
                    File.SetAttributes(sourceFile.FullName, File.GetAttributes(sourceFile.FullName) & ~FileAttributes.Archive);
                    
                    NbFilesLeftToDo--;
                }
            }
        }

        
        protected override void checkAuthorizations(string directory)
        {
            IEnumerable<string> directories = Directory.EnumerateDirectories(directory);
            List<FileInfo> f = new List<FileInfo>();
            Tuple<string, List<FileInfo>> tuple = new Tuple<string, List<FileInfo>>(directory, f);

            foreach (string currentDirectory in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentDirectory);
                if (!checkTypes(dirInfo.Attributes))
                {
                    try
                    {
                        AuthorizationRuleCollection acl = dirInfo.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
                        FileSystemAccessRule rule = (FileSystemAccessRule)acl[0];
                        
                        if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (checkRights(rule))
                            {
                                checkAuthorizations(currentDirectory);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            }
            
            IEnumerable<string> files = Directory.EnumerateFiles(directory);
            foreach (string currentFile in files)
            {
                FileInfo fileInfo = new FileInfo(currentFile);

                if (!checkTypes(fileInfo.Attributes))
                {
                    try
                    {
                        AuthorizationRuleCollection acl = fileInfo.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
                        FileSystemAccessRule rule = (FileSystemAccessRule)acl[0];

                        if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (checkRights(rule))
                            {
                                f.Add(fileInfo); 
                                TotalFilesSize += fileInfo.Length/1000;
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            }
            authorizedDirAndFiles.Add(tuple);

            TotalFilesToCopy += f.Count;
            NbFilesLeftToDo = TotalFilesToCopy;
        }
        private bool checkRights(FileSystemAccessRule rule)
        {
            bool toReturn = (rule.FileSystemRights & (FileSystemRights.FullControl | FileSystemRights.Modify | FileSystemRights.Read | FileSystemRights.ReadAndExecute)) != 0;
            if (toReturn)
                return toReturn;

            int[] array = new int[32];
            int number = (int)rule.FileSystemRights;
            for (int i = 0; i < 32; i++)
            {
                array[i] = number % 2;
                number /= 2;
            }

            if (array[31] == 1 || array[28] == 1)
                return true;

            return false;
        }
        private bool checkTypes(FileAttributes toCheck)
        {
            return (toCheck & (FileAttributes.System | FileAttributes.Offline | FileAttributes.Temporary)) != 0;
        }
    }
}