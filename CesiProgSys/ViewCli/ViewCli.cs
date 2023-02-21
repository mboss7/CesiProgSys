using CesiProgSys.ToolsBox;
using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli
{
    public abstract class ViewCli
    {
        protected ViewModelCli vmCLI;

        protected Dictionary<string, string> dico;

        private int askNumber()
        {
            Console.Write(dico["askChoice"]);
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return -1;
            }
        }
        
        public void menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(dico["textMenu"]);

                int choice = askNumber();

                switch (choice)
                {
                    case 1:
                        configBackup();
                        break;
                    case 2:
                        startBackup();
                        break;
                    case 3:
                        showConfig();
                        break;
                    case 4:
                        changeConfig();
                        break;
                    case 5:
                        help();
                        break;
                    case 6:
                        leave();
                        break;
                    case 7:
                        Console.WriteLine(
                            "0xoddddooooooooollllllllllllllllllllllllllllllllllllllllllloooddxkO0KXXXXXXXXXXXXXXXXXXXXX\n" +
                            "Kx:',,,,,,''''................................................'',,;cldxOKXXXXXXXXXXXXXXXXX\n" +
                            "KKOl'.,,;,,,,''''.............................................''',,;;;:coxOKXXXXXXXXXXXXXX\n" +
                            "KKKKx,...',,,,,,''''........................'...................''',,;;::cldk0KXXXXXXXXXXX\n" +
                            "KKKKKOl......''','''''''.................';:,.....................'',,;;::cllxO0KXXXXXXXXX\n" +
                            "KKKKKKKk:.    ...........................cx:......,................'',cc:::ccok0KXXXXXXXXX\n" +
                            "KKKKKKKK0d;.                            ;oc' ..;lc,. .............'..';lddlc:cdKXXXXXXXXXX\n" +
                            "KKKKKKKKKK0d;.                         .ll'.'lkk:.  .',. .........,;,..'cx0OdclOXXXXXXXXXX\n" +
                            "KKKKKKKKKKKK0xc,..                     .od:lkKk;.  .::.      ......'c;...,oO0koxKKXXXXXXXX\n" +
                            "KOxkO0KKKKKKKKK0kdollcclllllllllllllllloOKKXXKl.  .:o'        ......,l;...'lO0OOKKXXXXKXXX\n" +
                            "KOl,,;:ccccccccc::::::::::::::::::;;;;;lkxokXK:.  'xl.           ....:c'...;xOxxOOKKXXKXXX\n" +
                            "KK0d,................................. .oc.c0Xx'  ,ko.              .;l,...:xkoldod0KKXXXX\n" +
                            "KKKKOc. ................................:ooclkKOo;:kk,    ..        .cd;.;lkOdlddccoOKXXXX\n" +
                            "KKKKKKx;.    ............................,ccllodkOO0Kk;.  .'.      .;xkddkkdolddl::coOKXXX\n" +
                            "KKKKKKK0d,.                                .':ccloodkK0x:..,;.    .ck0Oxolloool::::::o0KXK\n" +
                            "KKKKKKKKKOo,.                                 ..,;;:cclx0kodo' ..:xOkl::;:cc::;;::::::xKKK\n" +
                            "KKKKKK000KKOd:'..                                  .',..,lkKKkclk0k:..''..',;;;;;;;;;;lOKK\n" +
                            "KKKKKOl:::::::,............................... .....;;'....:xKXKKo'........,,;;;;,;;;;:xKK\n" +
                            "KKKKKKOo:'....................................... .,x0kocc::ldOKkllol;'.. .',,,,,,,,,,;dKK\n" +
                            "KKKKKKKK0kdc:,''....................................'lO0OOKXK00KKK0o;'..  .''''''''''',o0K\n" +
                            "KKKKKKKKKKKK0Okkxxxdl:,'.........................    ..,oKXXK00KXXKl..    ..'''''''''''l0K\n" +
                            "KKKKKKKKKKKKKKKKKOdc;,''''''................           .l0KX0ockKXXk,.    ............'o0K\n" +
                            "KKKKKKKKKKKKKKKOo:,,,,,,,,,,''.......                  ,oOKKK00KKKXKO:.  .............,dKK\n" +
                            "KKKKKKKKKKKKK0d;''',,,,,,,'....                       .cokXKKKKKKKXKK0d,..............;kKK\n" +
                            "KKKKKKKKKKKKkc'...''''''...                          .;olkKKK0koc:codxd,..............l0KK\n" +
                            "KKKKKKKKKK0x;...........                            .;kkcdKKKKKOo,. .................,xKKK\n" +
                            "KKKKKKKKK0d,.........                           ..':oOK0l:xKKKKKKx,     .............o0KKK\n" +
                            "KKKKKKKKKk,.........                         .':ok0KKKKKOc;d00000Ol.    ............:OKKKK\n" +
                            "KKKKKKKKOc........                 ......,;:lxOKKKKK00KKKOc,oOOOOOl.   ............;kKKKKK\n" +
                            "KKKKKKKKd'  .....      .';cllllloooddxxkO0KKKKKKKKKkxO000Kk;,oxxxxl.  ............,xKKKKKK\n" +
                            "KKKKKKK0c.   ..     .,cdOKKKK0OkxxOKKKKKKKKKKKKKKKxcd00000Oo';ddddc. ............,x0KKKKKK\n" +
                            "KKKKKKKO;.  ..     .;ddx0KKKK0KKOdcd0000000000000k;,xOOOOOOd''lool,.............;xKKKKKKKK\n" +
                            "KKKKKKKk, .....    .cloO000000000Ol,oOOOOOOOOOOOx;.cxkxkkxxl.'cl:'.............ckKKKKKKKKK\n" +
                            "KKKKKKKk,...... ...,,,dOOOOOOOOOOOo.,dkkkkkkkkko,.:odxddddl'.;:'.............,o0KKKKKKKKKK\n" +
                            "KKKKKKKO;.............okkkkkkkkkkxc..lddddddddo,.;ooooooc;..,c,.............ckKKKKKKKKKKKK\n" +
                            "KKKKKKK0l.......     .:xxxxxxxxxdc,.,looooooool,.;lllc;'...;:;............;d0KKKKKKKKKKKKK\n" +
                            "KKKKKKKKx,......     .;oddddddo:'.',:llllllllll;..:c:'...';,'...........;dOKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKK0l.......    .;odddol:....;::;;,,,,,,,,,'.':;.',;'...........':dOKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKKOc.......  .'lddol;.. .','....        .''.,,,::,..........,cx0KKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKKKOc'..... .,odoc,....''..              .,'';::,........';ok0KKKKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKKKKOl,..'',cdo:'...''...                .,,';:;'....'';lxOKKKKKKKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKKKKKOo,,ldxxl'..;;'..                   .,;,::,..'';ldO0KKKKKKKKKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKK0KKK0xcokxc..,oko'.                    .;:;:;',:ldO0KKKKKKKKKKKKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKK0KK0K0kxxc..ck000kc.                  .':::ccoxO00K0KKKKKKKKKKKKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKKKK000000Oko,,oO000000x:.             ..:oolclk0000000KK0KKKKKKKKKKKKKKKKKKKKKKKKKKK\n" +
                            "00KKKKK0K000000kdc:x000000000Oo,.       ..';ok00dllx0000000000K00KKKKKKKKKKKKKKKKKKKKKKKKK\n" +
                            "KKKKKKK00000K0kdlok000000000000kl..  ..;okOO000OoldO000000000000000KK0KKKKKKKKKKKKKKKKKKKK\n" +
                            "0000000000000kdook000000000000000d;';lxO000000Oxllk00000000000000000000000000KKKKKKKKKKKKK\n" +
                            "KK0000000000OxdxO00000000OOOOOOOOOkxkkkkkkkkkkxdloxkkkkkkOOOOOOOOOO00000000000000000KKKKKK\n");
                        Console.ReadLine();
                        vmCLI.writeConfig();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(dico["invalid"]);
                        Console.ReadLine();
                        break;
                }
            }
        }
        
        private void configBackup()
        {
            Console.Clear();
            Console.WriteLine(dico["textConfigBackup"]);

            int choiceBackup = askNumber();

            switch (choiceBackup)
            {
                case 1:
                    fullBackup();
                    break;
                case 2:
                    diffBackup();
                    break;
                case 3:
                    break;
                case 4:
                    leave();
                    break;
                default:
                    Console.WriteLine(dico["invalid"]);
                    configBackup();
                    break;
            }
        }
        
        private void startBackup()
        {
            Console.Clear();
            Console.WriteLine(dico["textStartBackup"]);

            int choiceBackup = askNumber();

            switch (choiceBackup)
            {
                case 1:
                    startBackupValid();
                    break;
                case 2:
                    break;
                case 3:
                    leave();
                    break;
                case 4:
                    Console.WriteLine(dico["invalid"]);
                    startBackup();
                    break;
            }
        }
        
        private void showConfig()
        {
            Console.Clear();
            string[] s = vmCLI.getConfig();
            Console.WriteLine(dico["textShowContentConfig"], s[0], s[1], s[2], s[3], s[4], s[5], s[6]);
            Console.ReadLine();
        }
        
        private void changeConfig()
        {
            //code
            Console.Clear();
            Console.WriteLine(dico["textChangeConfig"]);

            int choiceConfig = askNumber();

            switch (choiceConfig)
            {
                case 1:
                    chooseLanguage();
                    break;
                case 2:
                    defaultSaveSource();
                    break;
                case 3:
                    defaultSaveTarget();
                    break;
                case 4:
                    resetConfig();
                    break;
                case 5:
                    retentionTime();
                    break;
                case 6 :
                    changeTypeLogs();
                    break;
                case 7:
                    break;
                case 8:
                    leave();
                    break;
                default:
                    Console.WriteLine(dico["invalid"]);
                    changeConfig();
                    break;
            }
        }
        
        private void help()
        {
            //code
            Console.Clear();
            Console.WriteLine(dico["textHelp"]);
            
            int choiceBackup = askNumber();

            if (choiceBackup == 1)
            {
            }
            if (choiceBackup == 2)
            {
                leave();
            }
            else
            {
                Console.WriteLine(dico["invalid"]);
                help();
            }
        }

        private void chooseLanguage()
        {
            //code
            Console.Clear();
            Console.WriteLine(dico["textChooseLanguage"]);
            
            int choiceLanguage = askNumber();

            switch (choiceLanguage)
            {
                case 1:
                    vmCLI.changeLanguage(Language.French);
                    break;
                case 2:
                    vmCLI.changeLanguage(Language.English);
                    break;
                case 3:
                    break;
                case 4:
                    leave();
                    break;
                default:
                    Console.WriteLine(dico["invalid"]);
                    changeConfig();
                    break;
            }
            Console.WriteLine(dico["textChangeLanguage"]);
            Console.ReadLine();
        }

        private void changeTypeLogs()
        {
            Console.Clear();
            Console.WriteLine(dico["textChangeTypeLogs"]);

            string type = Console.ReadLine();
            if (type != "xml" && type != "json")
            {
                Console.WriteLine(dico["invalid"]);
                Console.ReadLine();
                return;
            }

            vmCLI.changeTypeLogs(type);
        }
        
        private void defaultSaveSource()
        {
            Console.Clear();
            Console.WriteLine(dico["textChangeDefaultSaveSource"]);

            string path = Console.ReadLine();
            vmCLI.changeDefaultSaveSource(path);
        }

        private void defaultSaveTarget()
        {
            Console.Clear();
            Console.WriteLine(dico["textChangeDefaultSaveTarget"]);

            string path = Console.ReadLine();
            vmCLI.changeDefaultSaveTarget(path);
        }

        private void retentionTime()
        {
            Console.Clear();
            Console.WriteLine(dico["textRetentionTime"]);

            int i = askNumber();
            vmCLI.changeRetentionTime(i);
        }
        
        private void resetConfig()
        {
            vmCLI.resetConfig();
        }

        private string getRecentSource()
        {
            string[] s = vmCLI.getRecentSource();
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("{0} : {1}", i, s[i]);
            }

            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return null;
            }

            if (input > s.Length-1 || input < 0)
                return null;
            
            return s[input];

        }

        private string getRecentTarget()
        {
            string[] s = vmCLI.getRecentTarget(); 
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("{0} : {1}", i, s[i]);
            }
            
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                return null;
            }
            
            if (input > s.Length || input < 0)
                return null;
                        
            return s[input];
        }

        private void fullBackup()
        {
            Console.Clear();
            string name = null;
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine(dico["textChooseNameFullBackup"]);
                name = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine(dico["textSource"]);
            string sourceDir = Console.ReadLine();

            if (sourceDir == "1")
            {
                sourceDir = vmCLI.getDefaultSource();
            }
            else if (sourceDir == "2")
            {
                sourceDir = getRecentSource();
            }

            while (string.IsNullOrEmpty(sourceDir))
            {
                sourceDir = Console.ReadLine();
            }
            
            Console.Clear();
            Console.WriteLine(dico["textTarget"]);
            string targetDir = Console.ReadLine();
            if (targetDir == "1")
            {
                targetDir = vmCLI.getDefaultTarget();
            }
            else if (targetDir == "2")
            {
                targetDir = getRecentTarget();
            }
            while (string.IsNullOrEmpty(targetDir))
            {
                targetDir = Console.ReadLine();
            }
            

            vmCLI.instantiateBackup(name, sourceDir, targetDir, true);
        }

        private void diffBackup()
        {
            Console.Clear();
            string name = null;
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine(dico["textChooseNameFullBackup"]);
                name = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine(dico["textSource"]);
            string sourceDir = Console.ReadLine();

            if (sourceDir == "1")
            {
                sourceDir = vmCLI.getDefaultSource();
            }
            else if (sourceDir == "2")
            {
                sourceDir = getRecentSource();
            }

            while (string.IsNullOrEmpty(sourceDir))
            {
                sourceDir = Console.ReadLine();
            }
            
            Console.Clear();
            Console.WriteLine(dico["textTarget"]);
            string targetDir = Console.ReadLine();
            if (targetDir == "1")
            {
                targetDir = vmCLI.getDefaultTarget();
            }
            else if (targetDir == "2")
            {
                targetDir = getRecentTarget();
            }
            while (string.IsNullOrEmpty(targetDir))
            {
                targetDir = Console.ReadLine();
            }
            

            vmCLI.instantiateBackup(name, sourceDir, targetDir, false);
        }

        private void startBackupValid()
        {
            Console.Clear();
            List<string[]> backups = vmCLI.getBackups();

            for (int i = 0; i < backups.Count; i++)
            {
                Console.WriteLine("{0} {1} {2} {3}", i + 1, backups[i][0], backups[i][1], backups[i][2]);
            }

            int input = 0;

            try
            {
                input = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            catch (FormatException)
            {
                input = -1;
            }

            if (input <= -1 || input >= backups.Count)
            {
                Console.WriteLine(dico["invalid"]);
                menu();
            }
            else
            {
                vmCLI.startBackup(backups[input][0]);
            }
        }

        private void leave()
        {
            Console.WriteLine(dico["exit"]);
            vmCLI.writeConfig();
            Environment.Exit(0);
        }
        
    }  
}

