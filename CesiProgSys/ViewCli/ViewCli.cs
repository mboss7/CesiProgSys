using CesiProgSys.ToolsBox;
using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli
{
    /// <summary>
    /// Provides a base implementation of the CLI 
    /// </summary>
    public abstract class ViewCli
    {
        /// <summary>
        /// Holds a reference to the ViewModelCli object used to manage the view-model interaction.
        /// </summary>
        protected ViewModelCli vmCLI;

        /// <summary>
        /// A Dictionary object that is used to store strings.
        /// </summary>
        protected Dictionary<string, string> dico;

        /// <summary>
        /// Prompts the user to input a number and returns an integer value. If the user input is not a valid integer, it catches the FormatException and returns -1 instead.
        /// </summary>
        private int askNumber()
        {
            // Prompt the user to input a number.
            Console.Write(dico["askChoice"]);
            try
            {
                // Convert the user input to an integer and return it.
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                // Return -1 if the user input is not a valid integer.
                return -1;
            }
        }
        
        /// <summary>
        /// Shows the main menu of the application and prompts the user to select an option. Then it calls the appropriate method based on the user's selection.
        /// </summary>
        public void menu()
        {
            while (true)
            {
                // Clear the console and display the main menu.
                Console.Clear();
                Console.WriteLine(dico["textMenu"]);

                // Prompt the user to enter a number and store the result.
                int choice = askNumber();

                // Call the appropriate method based on the user's selection.
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
                        // If the user enters an invalid number, display an error message and wait for the user to press enter.
                        Console.WriteLine(dico["invalid"]);
                        Console.ReadLine();
                        break;
                }
            }
        }
        
        /// <summary>
        /// Displays the backup configuration menu.
        /// </summary>
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
        
        /// <summary>
        /// Displays the backup start menu.
        /// </summary>
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
        
        /// <summary>
        /// Shows the current backup configuration to the user.
        /// </summary>
        private void showConfig()
        {
            Console.Clear();
            // Declare and initialize a string array.
            // The value assigned to "s" is the result of "getConfig()" method call on an object named "vmCLI".
            string[] s = vmCLI.getConfig();
            // Display the current backup configuration to the user.
            Console.WriteLine(dico["textShowContentConfig"], s[0], s[1], s[2], s[3], s[4], s[5], s[6]);
            Console.ReadLine();
        }
        
        /// <summary>
        /// Prompts the user to modify the backup configuration and then executes the corresponding action.
        /// </summary>
        private void changeConfig()
        {
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
        
        /// <summary>
        /// Displays help information.
        /// </summary>
        private void help()
        {
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

        /// <summary>
        /// Prompts the user to choose a language.
        /// </summary>
        private void chooseLanguage()
        {
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

        /// <summary>
        /// This method is used to change the type of logs.
        /// </summary>
        private void changeTypeLogs()
        {
            Console.Clear();
            Console.WriteLine(dico["textChangeTypeLogs"]);

            string type = Console.ReadLine();
            // Check if the user input is "xml" or "json".
            if (type != "xml" && type != "json")
            {
                Console.WriteLine(dico["invalid"]);
                Console.ReadLine();
                return;
            }

            vmCLI.changeTypeLogs(type);
        }
        
        /// <summary>
        /// This method is used to change the default save source.
        /// </summary>
        private void defaultSaveSource()
        {
            Console.Clear();
            Console.WriteLine(dico["textChangeDefaultSaveSource"]);

            string path = Console.ReadLine();
            vmCLI.changeDefaultSaveSource(path);
        }

        /// <summary>
        /// This method is used to change the default save target.
        /// </summary>
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
        
        /// <summary>
        /// Reset the configuration settings.
        /// </summary>
        private void resetConfig()
        {
            vmCLI.resetConfig();
        }

        /// <summary>
        /// Retrieves recent save source paths.
        /// </summary>
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

        /// <summary>
        /// Retrieves recent save target paths.
        /// </summary>
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

        /// <summary>
        /// This method is used to make a full backup.
        /// </summary>
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

        /// <summary>
        /// This method is used to make a differential backup.
        /// </summary>
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

        /// <summary>
        /// Launch the backup definitively.
        /// </summary>
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

        /// <summary>
        /// Exit the application.
        /// </summary>
        private void leave()
        {
            Console.WriteLine(dico["exit"]);
            vmCLI.writeConfig();
            Environment.Exit(0);
        }
        
    }  
}

