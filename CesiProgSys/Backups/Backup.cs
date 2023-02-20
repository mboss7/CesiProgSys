using System.Security.AccessControl;
using System.Security.Principal;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backups
{
    public abstract class Backup
    {
        private List<Tuple<string, List<FileInfo>>> unauthorizedDirAndFiles;
        
        protected List<Tuple<string, List<FileInfo>>> authorizedDirAndFiles;
        protected Info info;
        protected Logs rltInstance;
        
        public ManualResetEventSlim wait;
        public string name;
        public string source;
        public string target;

        public abstract void backup();

        public void startCheckAuthorizations()
        {
            checkAuthorizations(info.SourceDir);
        }
        private void checkAuthorizations(string directory)
        {
            info.State = State.CHECKINGAUTH;
            rltInstance.wait.Set();

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
                                info.TotalFilesSize += fileInfo.Length/1000;
                                rltInstance.wait.Set();
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            }
            authorizedDirAndFiles.Add(tuple);

            info.TotalFilesToCopy += f.Count;
            info.NbFilesLeftToDo = info.TotalFilesToCopy;
            rltInstance.wait.Set();
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