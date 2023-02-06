using System.Security.AccessControl;
using System.Security.Principal;
using CesiProgSys.LOG;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backup
{
    public class FullBackup : IBackup
    {
        private static int a = 0;
        //TODO penser à mettre en place des mutex, pour pouvoir controler le déroulement du thread
        private List<string> unauthorizedDirectories;
        
        private List<string> unauthorizedFiles;

        private Info inf;

        private List<Tuple<string, List<FileInfo>>> authorizedDirAndFiles;

        public FullBackup()
        {
            unauthorizedDirectories = new List<string>();
            unauthorizedFiles = new List<string>();
            authorizedDirAndFiles = new List<Tuple<string, List<FileInfo>>>();
            
            inf = new Info();
        }
        public void InitBackup(string name, string source, string target)
        {
            string date = dateToString(DateTime.Now);
            inf.Name = !string.IsNullOrEmpty(name) ? name : date;
            inf.DirSource = source;
            inf.DirTarget = target;
            inf.progression = 0;
            inf.state = State.INACTIVE;

            RealTimeLogs.mut.WaitOne();
            RealTimeLogs.listInfo.Add(inf);
            RealTimeLogs.mut.ReleaseMutex();
        }
        public void startBackup(string source, string target)
        {
            RealTimeLogs.mut.WaitOne();
            inf.state = State.ACTIVE;
            RealTimeLogs.mut.ReleaseMutex();

            DirectoryInfo targetDirectory = new DirectoryInfo(target);

            if (!targetDirectory.Exists)
            {
                targetDirectory.Create();
            }
            for (int i = authorizedDirAndFiles.Count-1; i >= 0; i--)
            {
                string dir = authorizedDirAndFiles[i].Item1.Substring(source.Length-1);
                dir = !string.IsNullOrEmpty(dir) ? dir : inf.Name;
                DirectoryInfo subDirectory = targetDirectory.CreateSubdirectory(dir);
                foreach (FileInfo sourceFile in authorizedDirAndFiles[i].Item2)
                {
                    sourceFile.CopyTo(Path.Combine(subDirectory.FullName, sourceFile.Name), true);
                }
            }
        }
        
        public void checkAutorizations(string directory)
        {
            RealTimeLogs.mut.WaitOne();
            inf.state = State.CHECKINGAUTH;
            RealTimeLogs.mut.ReleaseMutex();

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
                        
                        if (AccessControlType.Deny.Equals(rule.AccessControlType))
                        {
                            unauthorizedDirectories.Add(currentDirectory);
                        }
                        else if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (checkRights(rule))
                            {
                                checkAutorizations(currentDirectory);
                            }
                            else
                            {
                                unauthorizedDirectories.Add(currentDirectory);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        unauthorizedDirectories.Add(currentDirectory);
                    }
                }
                else
                {
                    unauthorizedDirectories.Add(currentDirectory);
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
                        AuthorizationRuleCollection acl = fileInfo.GetAccessControl()
                            .GetAccessRules(true, true, typeof(SecurityIdentifier));
                        FileSystemAccessRule rule = (FileSystemAccessRule)acl[0];

                        if (AccessControlType.Deny.Equals(rule.AccessControlType))
                        {
                            unauthorizedFiles.Add(currentFile);
                        }
                        else if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (checkRights(rule))
                            {
                                f.Add(fileInfo);
                            }
                            else
                            {
                                unauthorizedFiles.Add(currentFile);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        unauthorizedFiles.Add(currentFile);
                    }
                }
                else
                {
                    unauthorizedFiles.Add(currentFile);
                }
            }
            authorizedDirAndFiles.Add(tuple);
        }
        public bool checkRights(FileSystemAccessRule rule)
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
        public bool checkTypes(FileAttributes toCheck)
        {
            return (toCheck & (FileAttributes.System | FileAttributes.Offline | FileAttributes.Temporary)) != 0;
        }
        string dateToString(DateTime date)
        {
            string toReturn = date.ToString();
            
            toReturn = toReturn.Replace("/", "-");
            toReturn = toReturn.Replace(" ", "-");
            toReturn = toReturn.Replace(":", "-");

            return toReturn;
        }

        public static void startThread()
        {

            FullBackup fb = new FullBackup();

            if (a == 0)
            {
                a++;
                fb.InitBackup("premiere backup", "C:/Users/Tanguy/Documents/Workshop2", "C:/Users/Tanguy/Documents/Workshop3");
                fb.checkAutorizations("C:/Users/Tanguy/Documents/Workshop2");

                fb.startBackup("C:/Users/Tanguy/Documents/Workshop2", "C:/Users/Tanguy/Documents/Workshop3");
            }
            else
            {
                fb.InitBackup("premiere backup", "C:/Users/Tanguy/Documents/Workshop1", "C:/Users/Tanguy/Documents/Workshop4");
                fb.checkAutorizations("C:/Users/Tanguy/Documents/Workshop1");

                fb.startBackup("C:/Users/Tanguy/Documents/Workshop1", "C:/Users/Tanguy/Documents/Workshop4");
            }
            RealTimeLogs.mut.WaitOne();
            fb.inf.state = State.SUCCESS;
            RealTimeLogs.mut.ReleaseMutex();
        }
    }
}