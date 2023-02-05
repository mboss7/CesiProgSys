using System.ComponentModel.Design;
using System.Data;
using System.Security.AccessControl;
using System.Security.Principal;
using CesiProgSys.Tools;

namespace CesiProgSys.Backup
{
    public class FullBackup : IBackup
    {
        
        //TODO penser à mettre en place des mutex, pour pouvoir controler le déroulement du thread
        private List<DirectoryInfo> authorizedDirectories;
        private List<string> unauthorizedDirectories;
        
        private List<FileInfo> authorizedFiles;
        private List<string> unauthorizedFiles;

        private Info inf;

        // private List<Tuple<DirectoryInfo, List<FileInfo>>> authorizedDirAndFiles;

        public static void startThread()
        {
            string directory = "C:/Program Files (x86)/Steam";
            string target = "C:/";

            FullBackup fb = new FullBackup();
            fb.InitBackup("", directory, target);
            fb.checkAutorizations(directory);
            
            // fb.startBackup(directory, target);
        }

        public void InitBackup(string name, string source, string target)
        {
            inf.date = DateTime.Now;
            inf.name = !string.IsNullOrEmpty(name) ? name : inf.date.Date.ToString();
            inf.dirsource = source;
            inf.dirtarget = target;
            inf.progression = 0;
            inf.state = State.INACTIVE;
        }
        
        //TODO ne pas oublier de mettre à jour l'objet Info ...
        
        public void startBackup(string target)
        {
            inf.state = State.ACTIVE;
            
            DirectoryInfo targetDirectory = new DirectoryInfo(target);

            if (targetDirectory.Exists)
            {
                throw new IOException("target directory already exist");
            }
            
            targetDirectory.Create();

            // foreach (Tuple<DirectoryInfo, List<FileInfo>> t in authorizedDirAndFiles)
            // {
            //     
            // }

            // foreach (FileInfo file in sourceDirectory.GetFiles())
            // {
            //     inf.currentSource = Path.Combine(source, file.Name);
            //     string targetFile = Path.Combine(target, file.Name);
            //     inf.currentDest = targetFile;
            //     file.CopyTo(targetFile, true);
            //     
            // }
            //
            // foreach(DirectoryInfo subDirectory in sourceDirectory.GetDirectories())
            // {
            //     string targetSubDirectory = Path.Combine(target, subDirectory.Name);
            //     startBackup(subDirectory.FullName, targetSubDirectory);
            // }
        }
        
        public FullBackup()
        {
            authorizedDirectories = new List<DirectoryInfo>();
            unauthorizedDirectories = new List<string>();
            authorizedFiles = new List<FileInfo>();
            unauthorizedFiles = new List<string>();
            
            inf = new Info();
        }
        
        
        //TODO Modifier la fonction pour que les fichiers/Dossiers soit ajouter dans des tuples avant d'êtres mis dans la liste
        //TODO ainsi, il y aura juste à parcourir cette liste pour copier les dossiers, plus besoin de les recheck dans la startbackup fonction
        //TODO réfléchit bien à la façon de faire ça parce que sinon tu vas rester blocké
        public void checkAutorizations(string directory)
        {
            inf.state = State.CHECKINGAUTH;

            IEnumerable<string> directories = Directory.EnumerateDirectories(directory);

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
                                authorizedDirectories.Add(dirInfo);
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
                                authorizedFiles.Add(fileInfo); 
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

    }
}