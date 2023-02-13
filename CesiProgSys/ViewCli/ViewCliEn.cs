using System.ComponentModel;
using CesiProgSys.Backups;
using CesiProgSys.ToolsBox;
using CesiProgSys.ViewModel;

namespace CesiProgSys.ViewCli
{
    public class ViewCliEn : IViewCli
    {
        private ViewModelCli vmCLI;

        public ViewCliEn()
        {
            vmCLI = new ViewModelCli();
            
        }

        public void menu()
        {
            Console.Clear();
            Console.WriteLine("1. Configure a backup");
            Console.WriteLine("2. Start a backup");
            Console.WriteLine("3. Show configurations");
            Console.WriteLine("4. Change configurations");
            Console.WriteLine("5. Help");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice : ");
            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException){}
            

            if (choice > 0 && choice <= 5)
            {
                switch (choice)
                {
                    case 1 :
                        configBackup();
                        return;
                    case 2 :
                        startBackup();
                        return;
                    case 3 :
                        showConfig();
                        return;
                    case 4 :
                        changeConfig();
                        return;
                    case 5 :
                        help();
                        return;
                }
            }
            if (choice == 6)
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            if (choice == 7)
            {
                Console.WriteLine("0xoddddooooooooollllllllllllllllllllllllllllllllllllllllllloooddxkO0KXXXXXXXXXXXXXXXXXXXXX\n"+
"Kx:',,,,,,''''................................................'',,;cldxOKXXXXXXXXXXXXXXXXX\n"+
"KKOl'.,,;,,,,''''.............................................''',,;;;:coxOKXXXXXXXXXXXXXX\n"+
"KKKKx,...',,,,,,''''........................'...................''',,;;::cldk0KXXXXXXXXXXX\n"+
"KKKKKOl......''','''''''.................';:,.....................'',,;;::cllxO0KXXXXXXXXX\n"+
"KKKKKKKk:.    ...........................cx:......,................'',cc:::ccok0KXXXXXXXXX\n"+
"KKKKKKKK0d;.                            ;oc' ..;lc,. .............'..';lddlc:cdKXXXXXXXXXX\n"+
"KKKKKKKKKK0d;.                         .ll'.'lkk:.  .',. .........,;,..'cx0OdclOXXXXXXXXXX\n"+
"KKKKKKKKKKKK0xc,..                     .od:lkKk;.  .::.      ......'c;...,oO0koxKKXXXXXXXX\n"+
"KOxkO0KKKKKKKKK0kdollcclllllllllllllllloOKKXXKl.  .:o'        ......,l;...'lO0OOKKXXXXKXXX\n"+
"KOl,,;:ccccccccc::::::::::::::::::;;;;;lkxokXK:.  'xl.           ....:c'...;xOxxOOKKXXKXXX\n"+
"KK0d,................................. .oc.c0Xx'  ,ko.              .;l,...:xkoldod0KKXXXX\n"+
"KKKKOc. ................................:ooclkKOo;:kk,    ..        .cd;.;lkOdlddccoOKXXXX\n"+
"KKKKKKx;.    ............................,ccllodkOO0Kk;.  .'.      .;xkddkkdolddl::coOKXXX\n"+
"KKKKKKK0d,.                                .':ccloodkK0x:..,;.    .ck0Oxolloool::::::o0KXK\n"+
"KKKKKKKKKOo,.                                 ..,;;:cclx0kodo' ..:xOkl::;:cc::;;::::::xKKK\n"+
"KKKKKK000KKOd:'..                                  .',..,lkKKkclk0k:..''..',;;;;;;;;;;lOKK\n"+
"KKKKKOl:::::::,............................... .....;;'....:xKXKKo'........,,;;;;,;;;;:xKK\n"+
"KKKKKKOo:'....................................... .,x0kocc::ldOKkllol;'.. .',,,,,,,,,,;dKK\n"+
"KKKKKKKK0kdc:,''....................................'lO0OOKXK00KKK0o;'..  .''''''''''',o0K\n"+
"KKKKKKKKKKKK0Okkxxxdl:,'.........................    ..,oKXXK00KXXKl..    ..'''''''''''l0K\n"+
"KKKKKKKKKKKKKKKKKOdc;,''''''................           .l0KX0ockKXXk,.    ............'o0K\n"+
"KKKKKKKKKKKKKKKOo:,,,,,,,,,,''.......                  ,oOKKK00KKKXKO:.  .............,dKK\n"+
"KKKKKKKKKKKKK0d;''',,,,,,,'....                       .cokXKKKKKKKXKK0d,..............;kKK\n"+
"KKKKKKKKKKKKkc'...''''''...                          .;olkKKK0koc:codxd,..............l0KK\n"+
"KKKKKKKKKK0x;...........                            .;kkcdKKKKKOo,. .................,xKKK\n"+
"KKKKKKKKK0d,.........                           ..':oOK0l:xKKKKKKx,     .............o0KKK\n"+
"KKKKKKKKKk,.........                         .':ok0KKKKKOc;d00000Ol.    ............:OKKKK\n"+
"KKKKKKKKOc........                 ......,;:lxOKKKKK00KKKOc,oOOOOOl.   ............;kKKKKK\n"+
"KKKKKKKKd'  .....      .';cllllloooddxxkO0KKKKKKKKKkxO000Kk;,oxxxxl.  ............,xKKKKKK\n"+
"KKKKKKK0c.   ..     .,cdOKKKK0OkxxOKKKKKKKKKKKKKKKxcd00000Oo';ddddc. ............,x0KKKKKK\n"+
"KKKKKKKO;.  ..     .;ddx0KKKK0KKOdcd0000000000000k;,xOOOOOOd''lool,.............;xKKKKKKKK\n"+
"KKKKKKKk, .....    .cloO000000000Ol,oOOOOOOOOOOOx;.cxkxkkxxl.'cl:'.............ckKKKKKKKKK\n"+
"KKKKKKKk,...... ...,,,dOOOOOOOOOOOo.,dkkkkkkkkko,.:odxddddl'.;:'.............,o0KKKKKKKKKK\n"+
"KKKKKKKO;.............okkkkkkkkkkxc..lddddddddo,.;ooooooc;..,c,.............ckKKKKKKKKKKKK\n"+
"KKKKKKK0l.......     .:xxxxxxxxxdc,.,looooooool,.;lllc;'...;:;............;d0KKKKKKKKKKKKK\n"+
"KKKKKKKKx,......     .;oddddddo:'.',:llllllllll;..:c:'...';,'...........;dOKKKKKKKKKKKKKKK\n"+
"KKKKKKKK0l.......    .;odddol:....;::;;,,,,,,,,,'.':;.',;'...........':dOKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKKOc.......  .'lddol;.. .','....        .''.,,,::,..........,cx0KKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKKKOc'..... .,odoc,....''..              .,'';::,........';ok0KKKKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKKKKOl,..'',cdo:'...''...                .,,';:;'....'';lxOKKKKKKKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKKKKKOo,,ldxxl'..;;'..                   .,;,::,..'';ldO0KKKKKKKKKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKK0KKK0xcokxc..,oko'.                    .;:;:;',:ldO0KKKKKKKKKKKKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKK0KK0K0kxxc..ck000kc.                  .':::ccoxO00K0KKKKKKKKKKKKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKKKK000000Oko,,oO000000x:.             ..:oolclk0000000KK0KKKKKKKKKKKKKKKKKKKKKKKKKKK\n"+
"00KKKKK0K000000kdc:x000000000Oo,.       ..';ok00dllx0000000000K00KKKKKKKKKKKKKKKKKKKKKKKKK\n"+
"KKKKKKK00000K0kdlok000000000000kl..  ..;okOO000OoldO000000000000000KK0KKKKKKKKKKKKKKKKKKKK\n"+
"0000000000000kdook000000000000000d;';lxO000000Oxllk00000000000000000000000000KKKKKKKKKKKKK\n"+
"KK0000000000OxdxO00000000OOOOOOOOOkxkkkkkkkkkkxdloxkkkkkkOOOOOOOOOO00000000000000000KKKKKK\n");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                menu();
            }
        }
        
        public void configBackup()
        {
            Console.Clear();
            Console.WriteLine("1. Full backup");
            Console.WriteLine("2. Differential backup");
            Console.WriteLine("3. Return");
            Console.WriteLine("4. Exit");
        
            Console.Write("Enter your choice : ");
            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException) {}

            if (choiceBackup > 0 && choiceBackup <= 3)
            {
                switch (choiceBackup)
                {
                    case 1 :
                        fullBackup();
                        return;
                    case 2 :
                        diffBackup();
                        break;
                    case 3 :
                        menu();
                        break;
                }
            }
            if (choiceBackup == 4)
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                configBackup();
            }
        }

        public void startBackup()
        {
            Console.Clear();
            Console.WriteLine("1. Validation of the start of a backup");
            Console.WriteLine("2. Return");
            Console.WriteLine("3. Exit");
            
            Console.Write("Enter your choice : ");

            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException){}

            if (choiceBackup > 0 && choiceBackup <= 2)
            {
                switch (choiceBackup)
                {
                    case 1 :
                        startBackupValid();
                        return;
                    case 2 :
                        menu();
                        break;
                }
            }
            if (choiceBackup == 3)
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                startBackup();
            }
        }

        public void showConfig()
        {
            Console.Clear();
            Console.WriteLine("1. Validation of the display of configurations");
            Console.WriteLine("2. Return");
            Console.WriteLine("3. Exit");
            
            Console.Write("Enter your choice : ");

            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException){}

            if (choiceBackup > 0 && choiceBackup <= 2)
            {
                switch (choiceBackup)
                {
                    case 1 :
                        showConfigValid();
                        return;
                    case 2 :
                        menu();
                        break;
                }
            }
            if (choiceBackup == 3)
            {
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
                showConfig();
            }
        }

        public void changeConfig()
        {
            //code
            Console.Clear();
            Console.WriteLine("1. Change langue");
            Console.WriteLine("2. Default save source");
            Console.WriteLine("3. Default save target");
            Console.WriteLine("4. Clean recent save source");
            Console.WriteLine("5. Clean recent save target");
            Console.WriteLine("6. Change retention time");
            Console.WriteLine("7. Reset config");
            Console.WriteLine("8. Return");
            Console.WriteLine("9. Exit");
            
            Console.Write("Enter your choice : ");
            int choiceConfig = 0;
            try
            {
                choiceConfig = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException){}

            if (choiceConfig > 0 && choiceConfig <= 8)
            {
                switch (choiceConfig)
                {
                    case 1 :
                        chooseLanguage();
                        return;
                    case 2 : 
                        defaultSaveSource();
                        break;
                    case 3 :
                        defaultSaveTarget();
                        return;
                    case 4 :
                        cleanRecentSaveSource();
                        break;
                    case 5 :
                        cleanRecentSaveTarget();
                        return;
                    case 6 :
                        menu();
                        break;
                    case 7 :
                        menu();
                        return;
                    case 8 :
                        menu();
                        break;
                }
            }
            if (choiceConfig == 9)
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

        public void help()
        {
            //code
            Console.Clear();
            Console.WriteLine("Help : \n");
            Console.WriteLine(" .----------------.\n"+ 
                              "| .--------------. |\n"+
                "| |    ______    | |\n"+
                "| |   / _ __ `.  | |\n"+
                "| |  |_/____) |  | |\n"+
                "| |    /  ___.'  | |\n"+
                "| |    |_|       | |\n"+
                "| |    (_)       | |\n"+
                "| |              | |\n"+
                "| '--------------' |\n"+
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
            int choiceBackup = Convert.ToInt32(Console.ReadLine());
                
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

        public void fullBackup()
        {
            Console.Clear();
            Console.WriteLine("Choose a name for your fullbackup :");
            vmCLI.name = Console.ReadLine();
            while (string.IsNullOrEmpty(vmCLI.sourceDir))
            {
                Console.WriteLine("Choose a source directory :");
                vmCLI.sourceDir = Console.ReadLine();
            }

            while (string.IsNullOrEmpty(vmCLI.targetDir))
            {
                Console.WriteLine("Choose a target directory :");
                vmCLI.targetDir = Console.ReadLine();            
            }

            vmCLI.instantiateFullBackup();
            menu();
        }

        public void diffBackup()
        {
            Console.Clear();
            Console.WriteLine("Choose a name for your differential backup :");
            vmCLI.name = Console.ReadLine();
            while (string.IsNullOrEmpty(vmCLI.sourceDir))
            {
                Console.WriteLine("Choose a source directory :");
                vmCLI.sourceDir = Console.ReadLine();
            }

            while (string.IsNullOrEmpty(vmCLI.targetDir))
            {
                Console.WriteLine("Choose a target directory :");
                vmCLI.targetDir = Console.ReadLine();            
            }

            vmCLI.instantiateDiffBackup();
            menu();
        }

        public void startBackupValid()
        {
            Console.Clear();
            List<Backup> backups = vmCLI.getBackups();

            for (int i = 0; i < backups.Count; i++)
            {
                Console.WriteLine("{0} {1}", i+1, backups[i]);
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
                vmCLI.startBackup(backups[input]);
            }
            
            // List<string> listNames = vmCLI.getThreadsNames();
            // for (int i = 0; i < listNames.Count; i++)
            // {
            // }
            //
            // int input = 0;
            // try
            // {
            //     input = Convert.ToInt32(Console.ReadLine()) - 1;
            // }
            // catch (FormatException)
            // {
            //     input = -1;
            // }
            //
            // if (input <= -1 || input >= listNames.Count)
            // {
            //     Console.WriteLine("Wrong input");
            //     menu();
            // }
            // else
            // {
            //     vmCLI.startBackup(listNames[input]);
            // }
            menu();

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
                    case 1 :
                        Config.language = Language.French;
                        return;
                    case 2 :
                        Config.language = Language.English;
                        return;
                    case 3 :
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
    }
}




