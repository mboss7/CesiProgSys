using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli
{
    public abstract class ViewCli
    {
        protected ViewModelCli vmCLI;

        protected string textMenu;
        protected string textConfigBackup;
        protected string textStartBackup;
        protected string textShowConfig;
        protected string textChangeConfig;
        protected string askChoice;
        protected string exit;
        protected string invalid;
        
        public void menu()
        {
            Console.Clear();
            Console.WriteLine(textMenu);

            Console.Write(askChoice);
            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }


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
                    Console.WriteLine(exit);
                    Environment.Exit(0);
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
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(invalid);
                    menu();
                    break;
            }
        }
        
        private void configBackup()
        {
            Console.Clear();
            Console.WriteLine(textConfigBackup);

            Console.Write(askChoice);
            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }
            
            switch (choiceBackup)
            {
                case 1:
                    fullBackup();
                    break;
                case 2:
                    diffBackup();
                    break;
                case 3:
                    menu();
                    break;
                case 4:
                    Console.WriteLine(exit);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(invalid);
                    configBackup();
                    break;
            }
        }
        
        private void startBackup()
        {
            Console.Clear();
            Console.WriteLine(textStartBackup);

            Console.Write(askChoice);

            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }

            switch (choiceBackup)
            {
                case 1:
                    startBackupValid();
                    break;
                case 2:
                    menu();
                    break;
                case 3:
                    Console.WriteLine(exit);
                    Environment.Exit(0);
                    break;
                case 4:
                    Console.WriteLine(invalid);
                    startBackup();
                    break;
            }
        }
        
        private void showConfig()
        {
            Console.Clear();
            Console.WriteLine(textShowConfig);

            Console.Write(askChoice);

            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }
            
            switch (choiceBackup)
            {
                case 1:
                    showConfigValid();
                    break;
                case 2:
                    menu();
                    break;
                case 3:
                    Console.WriteLine(exit);
                    Environment.Exit(0);
                    break;
                case 4:
                    Console.WriteLine(invalid);
                    showConfig();
                    break;
            }
        }
        
        private void changeConfig()
        {
            //code
            Console.Clear();
            Console.WriteLine(textChangeConfig);

            Console.Write(askChoice);
            int choiceConfig = 0;
            try
            {
                choiceConfig = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }


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
                    cleanRecentSaveSource();
                    break;
                case 5:
                    cleanRecentSaveTarget();
                    break;
                case 6:
                    menu();
                    break;
                case 7:
                    menu();
                    break;
                case 8:
                    menu();
                    break;
                case 9:
                    Console.WriteLine(exit);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(invalid);
                    changeConfig();
                    break;
            }
        }
        
        public void help()
        {
            //code
            Console.Clear();
            Console.WriteLine("Help : \n");
            Console.WriteLine(" .----------------.\n" +
                              "| .--------------. |\n" +
                              "| |    ______    | |\n" +
                              "| |   / _ __ `.  | |\n" +
                              "| |  |_/____) |  | |\n" +
                              "| |    /  ___.'  | |\n" +
                              "| |    |_|       | |\n" +
                              "| |    (_)       | |\n" +
                              "| |              | |\n" +
                              "| '--------------' |\n" +
                              "'----------------' \n");
            Console.WriteLine("To set up a full backup: Type 1. Then 1.");
            Console.WriteLine("To set up a differential backup: Type 1. Then 2.");
            Console.WriteLine("To start a backup: Type 2. Then press 1.");
            Console.WriteLine("To display the settings: Type 3. Then 1.");
            Console.WriteLine("To change the language: Type 4. Then 1.");
            Console.WriteLine("To change the default backup source: Type 4. Then 2. Then 1.");
            Console.WriteLine("To clean up the default backup source: Type 4. Then 2. Then 2.");
            Console.WriteLine("To change the default backup target: Type 4. Then 3. Then 1.");
            Console.WriteLine("To clean up the default backup target: Type 4. Then 3. Then 2.");
            Console.WriteLine("To clean up the recent source of backups: Type 4. Then 4. Then 1.");
            Console.WriteLine("To clean up the recent target of the backups: Type 4. Then 5. Then 1.");
            Console.WriteLine("To change the retention time: Type 4. Then 6. Then 1.");
            Console.WriteLine("To fully clean up the settings: Type 4. Then 7. Then 1. \n");

            Console.WriteLine("1. Return");
            Console.WriteLine("2. Exit");

            Console.Write("Enter your choice : ");
            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }
            
            if (choiceBackup == 1)
            {
                menu();
                return;
            }
            if (choiceBackup == 2)
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                help();
            }
        }
        
        public void showConfigValid()
        {
            //code
            Console.Clear();
            Console.WriteLine("Definitely starts the configuration display");
            // Config.writeConfig(@".\\CONF\conf.json");
            // Config.readConfig(@".\\CONF\conf.json");
            menu();
        }

        public void chooseLanguage()
        {
            //code
            Console.Clear();
            Console.WriteLine("1. Choose French");
            Console.WriteLine("2. Choose English");
            Console.WriteLine("3. Return");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice : ");
            int choiceLanguage = Convert.ToInt32(Console.ReadLine());

            if (choiceLanguage > 0 && choiceLanguage <= 3)
            {
                switch (choiceLanguage)
                {
                    case 1:
                        // Config.language = Language.French;
                        return;
                    case 2:
                        // Config.language = Language.English;
                        return;
                    case 3:
                        menu();
                        return;
                }
            }

            if (choiceLanguage == 4)
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                changeConfig();
            }
        }

        public void defaultSaveSource()
        {
            //code
        }

        public void changeDSS()
        {
            //code
        }

        public void cleanDSS()
        {
            //code
        }

        public void defaultSaveTarget()
        {
            //code
        }

        public void changeDST()
        {
            //code
        }

        public void cleanDST()
        {
            //code
        }

        public void cleanRecentSaveSource()
        {
            //code
        }

        public void cleanRecentSaveTarget()
        {
            //Code
        }
        
        public void fullBackup()
        {
            Console.Clear();
            string name = null;
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Choose a name for your fullbackup :");
                name = Console.ReadLine();
            }

            string sourceDir = null;
            while (string.IsNullOrEmpty(sourceDir))
            {
                Console.WriteLine("Choose a source directory :");
                sourceDir = Console.ReadLine();
            }
            
            string targetDir = null;
            while (string.IsNullOrEmpty(targetDir))
            {
                Console.WriteLine("Choose a target directory :");
                targetDir = Console.ReadLine();
            }

            vmCLI.instantiateBackup(name, sourceDir, targetDir, true);
            menu();
        }

        public void diffBackup()
        {
            Console.Clear();
            string name = null;
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Choose a name for your differential backup :");
                name = Console.ReadLine();
            }

            string sourceDir = null;
            while (string.IsNullOrEmpty(sourceDir))
            {
                Console.WriteLine("Choose a source directory :");
                sourceDir = Console.ReadLine();
            }
            
            string targetDir = null;
            while (string.IsNullOrEmpty(targetDir))
            {
                Console.WriteLine("Choose a target directory :");
                targetDir = Console.ReadLine();
            }

            vmCLI.instantiateBackup(name, sourceDir, targetDir, false);
            menu();
        }

        public void startBackupValid()
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
                Console.WriteLine("Wrong input");
                menu();
            }
            else
            {
                vmCLI.startBackup(backups[input][0]);
            }
            menu();
        }
    }  
}

