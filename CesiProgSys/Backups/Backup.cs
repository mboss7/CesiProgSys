﻿using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Xml.Serialization;
using CesiProgSys.LOG;
using CesiProgSys.Network;
using CesiProgSys.Network;
using CesiProgSys.ToolsBox;

namespace CesiProgSys.Backups
{
    public abstract class Backup
    {
        protected List<Tuple<string, List<FileInfo>>> unauthorizedDirAndFiles;
        
        // protected Tuple<string, List<FileInfo>> fileListInfo; // add for file catch

        // protected Tuple<string, List<FileInfo>> dirListInfo; // add for directory catch

        
        protected List<Tuple<string, List<FileInfo>>> authorizedDirAndFiles;
        public Info info;
        protected Logs rltInstance;
        
        public ManualResetEventSlim wait;
        public string name;
        public string source;
        public string target;
        public string typeBackup;

        protected void SendPacket(string ty, int pr, State st)
        {
            // Packet p = new Packet(this.name, pr, st, this.source, this.target, ty);
            string s = "4&" + this.name+"&" + this.source+"&" + this.target+"&" + pr+"&" + st+"&" + ty;
            
            Client.packets.Enqueue(s);
            Client.wait.Set();
        }
        
        public abstract void backup();

        public void startCheckAuthorizations()
        {
            checkAuthorizations(source);
            info.State = State.INACTIVE;
            if (!Program.cli)
                SendPacket(typeBackup, 0, State.INACTIVE);
        }

        private void checkAuthorizations(string directory)
        {
            info.State = State.CHECKINGAUTH;
            rltInstance.wait.Set();
            if (!Program.cli)
                SendPacket(typeBackup, 0, State.CHECKINGAUTH);

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
                        
                        // add dans tuple error
                        // unauthorizedDirAndFiles.Add(dirListInfo);
                        info.State = State.ERROR;
                        if (!Program.cli)
                            SendPacket(typeBackup, 0, State.ERROR);
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
                    catch (UnauthorizedAccessException e)
                    {

                        
                        // Add file to the list unauthorize and state de inf en error
                      
                        
                        // unauthorizedDirAndFiles.Add(fileListInfo);
                        info.State = State.ERROR;
                        if (!Program.cli)
                            SendPacket(typeBackup, 0, State.ERROR);
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