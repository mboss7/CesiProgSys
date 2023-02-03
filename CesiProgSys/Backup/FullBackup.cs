using System.Data;
using System.Security.AccessControl;
using System.Security.Principal;

namespace CesiProgSys.Backup
{
    public class FullBackup : IBackup
    {
        private List<string> authorizedDirectories;
        private List<string> unauthorizedDirectories;
        private List<string> authorizedFiles;
        private List<string> unauthorizedFiles;
        
        public static void startThread()
        {
            Console.Write("FullBackup, Backgound : {0} Thread Pool  : {1} Thread ID : {2} \n", Thread.CurrentThread.IsBackground, Thread.CurrentThread.IsThreadPoolThread, Thread.CurrentThread.ManagedThreadId);
            
            DateTime d = DateTime.Now;

            string directory = "C:/Users/Tanguy/Downloads";
            
            FullBackup fb = new FullBackup();
            fb.checkAutorizations(directory);
            Console.WriteLine("VOICI TOUS LES DOSSIERS");

            Console.WriteLine(fb.authorizedDirectories.Count);
            Console.WriteLine(fb.authorizedFiles.Count);

            DateTime d2 = DateTime.Now;
            
            Console.WriteLine("Verifications des fichiers effectué en {0} secondes", (d2-d));
            
            // fb.startBackup(directory, "C:/Users/Tanguy/Documents/Workshop3");
        }

        public void startBackup(string directory, string destination)
        {
            // if (!Directory.Exists(destination))
            // {
            //     Directory.CreateDirectory(destination); 
            // }
            //
            // foreach (string file in authorizedFiles)
            // {
            //     string temp = file.Substring(directory.Length);
            //     string[] temp2 = temp.Split("/");
            //     Console.WriteLine(temp);
            //     Console.WriteLine(temp2);
            //     for (int i = 0; i < temp2.Length - 1; i++)
            //     {
            //         Directory.CreateDirectory(temp2[i]);
            //     }
            //     if(!File.Exists(destination+temp))
            //         File.Copy(file, destination+temp);
            // }
            
            
        }
        
        public FullBackup()
        {
            authorizedDirectories = new List<string>();
            unauthorizedDirectories = new List<string>();
            authorizedFiles = new List<string>();
            unauthorizedFiles = new List<string>();
        }
        
        public void checkAutorizations(string directory)
        {
            // try
            // {
            //     IEnumerable<string> directories = Directory.EnumerateDirectories(directory);
            //     authorizedDirectories.Add(directory);
            //     IEnumerable<string> files = Directory.EnumerateFiles(directory);
            //     authorizedFiles.AddRange(files);
            //     foreach (string d in directories)
            //     {
            //         checkAutorizations(d);
            //     }
            // }
            // catch (UnauthorizedAccessException e)
            // {
            //     unauthorizedDirectories.Add(directory);
            // }

            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            IEnumerable<string> directories = Directory.EnumerateDirectories(directory); //ta oublié d'intégré le tout premier dossier imbécile
            
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