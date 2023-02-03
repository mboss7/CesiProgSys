using System.ComponentModel.Design;
using System.Data;
using System.Security.AccessControl;
using System.Security.Principal;
using CesiProgSys.Tools;

namespace CesiProgSys.Backup
{
    public class FullBackup : IBackup
    {
        private List<string> authorizedDirectories;
        private List<string> unauthorizedDirectories;
        private List<string> authorizedFiles;
        private List<string> unauthorizedFiles;

        private Info inf;
        
        public static void startThread()
        {
            Console.Write("FullBackup, Backgound : {0} Thread Pool  : {1} Thread ID : {2} \n", Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.ManagedThreadId);
            
            DateTime d = DateTime.Now;

            string directory = "C:/Users/Tanguy/Documents/Workshop2";
            
            FullBackup fb = new FullBackup();
            fb.checkAutorizations(directory);
            Console.WriteLine("VOICI TOUS LES DOSSIERS");

            Console.WriteLine(fb.authorizedDirectories.Count);
            Console.WriteLine(fb.authorizedFiles.Count);

            DateTime d2 = DateTime.Now;
            
            Console.WriteLine("Verifications des fichiers effectué en {0} secondes", (d2-d));

            fb.startBackup(directory, "C:/Users/Tanguy/Documents/Workshop3");
        }

        public void InitBackup(string name, string source, string target,)
        {
            inf.date = DateTime.Now;
            inf.name = !string.IsNullOrEmpty(name) ? name : inf.date.Date.ToString();
            inf.dirsource = source;
            inf.dirtarget = target;
            

        }
        
        public void startBackup(string source, string target)
        {

            // inf.state = "active";
            // inf.date = DateTime.Now;
            // inf.filesource = source;
            // inf.filedest = target;
            // inf.totalFilesToCopy = authorizedFiles.Count;
            // inf.nbFilesLeftToDo = authorizedFiles.Count;
            //hmmm bof ça va se retrouver dans la récurs et ça va foutre la merde.
            
            DirectoryInfo sourceDirectory = new DirectoryInfo(source);
            DirectoryInfo targetDirectory = new DirectoryInfo(target);

            if (!sourceDirectory.Exists)
            {
                throw new DirectoryNotFoundException("Source directory doesn't exist");
            }

            if (targetDirectory.Exists)
            {
                throw new IOException("target directory already exist");
            }
            
            targetDirectory.Create();

            foreach (FileInfo file in sourceDirectory.GetFiles())
            {
                
                string targetFile = Path.Combine(target, file.Name);
                file.CopyTo(targetFile, true);
                
            }
            
            foreach(DirectoryInfo subDirectory in sourceDirectory.GetDirectories())
            {
                string targetSubDirectory = Path.Combine(target, subDirectory.Name);
                startBackup(subDirectory.FullName, targetSubDirectory);
            }
        }
        
        public FullBackup()
        {
            authorizedDirectories = new List<string>();
            unauthorizedDirectories = new List<string>();
            authorizedFiles = new List<string>();
            unauthorizedFiles = new List<string>();

            inf = new Info();
        }
        
        public void checkAutorizations(string directory)
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            IEnumerable<string> directories = Directory.EnumerateDirectories(directory); //ta oublié d'intégrer le tout premier dossier imbécile
            
            
            
            foreach (string currentDirectory in directories)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(currentDirectory);
                AuthorizationRuleCollection acl = dirInfo.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
                
                for (int i = 0; i < acl.Count; i++)
                {
                    FileSystemAccessRule rule = (FileSystemAccessRule)acl[i];
            
                    if (wi.User.Equals(rule.IdentityReference) || wi.Groups.Equals(rule.IdentityReference))
                    {
                        if (AccessControlType.Deny.Equals(rule.AccessControlType))
                        {
                            if (contains(FileSystemRights.FullControl, rule))
                            {
                                unauthorizedDirectories.Add(currentDirectory);
                            }
                        }
                        else if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (contains(FileSystemRights.FullControl, (FileSystemAccessRule)acl[i]))
                            {
                                authorizedDirectories.Add(currentDirectory);
                                checkAutorizations(currentDirectory); 
                            }
                        }
                    }
                }
            }
            
            IEnumerable<string> files = Directory.EnumerateFiles(directory);
            foreach (string currentFile in files)
            {
                FileInfo fileInfo = new FileInfo(currentFile);
                AuthorizationRuleCollection acl = fileInfo.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
            
                for (int i = 0; i < acl.Count; i++)
                {
                    FileSystemAccessRule rule = (FileSystemAccessRule)acl[i];
            
                    if (wi.User.Equals(rule.IdentityReference) || wi.Groups.Equals(rule.IdentityReference))
                    {
                        if (AccessControlType.Deny.Equals(rule.AccessControlType))
                        {
                            if (contains(FileSystemRights.FullControl, rule))
                            {
                                unauthorizedFiles.Add(currentFile);
                            }
                        }
                        else if (AccessControlType.Allow.Equals(rule.AccessControlType))
                        {
                            if (contains(FileSystemRights.FullControl, (FileSystemAccessRule)acl[i]))
                            {
                                authorizedFiles.Add(currentFile);
                            }
                        }
                    }
                }
            }
        }

        public bool contains(FileSystemRights right, FileSystemAccessRule rule)
        {
            return (((int)right & (int)rule.FileSystemRights) == (int)right);
            
        }

    }
}