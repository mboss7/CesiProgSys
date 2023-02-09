using System;
using CesiProgSys.ToolsBox;
using CesiProgSys.ViewModel;


namespace CesiProgSys.ViewCli
{
    public class ViewCliFr : IViewCli
    {
        private ViewModelCli vmCLI;

        public ViewCliFr()
        {
            vmCLI = new ViewModelCli();
        }
        public void menu()
        {
            Console.Clear();
            Console.WriteLine("1. Configurer une sauvegarde");
            Console.WriteLine("2. Lancer une sauvegarde");
            Console.WriteLine("3. Afficher les configurations");
            Console.WriteLine("4. Changer les configurations");
            Console.WriteLine("5. Aide");
            Console.WriteLine("6. Quitter");

            Console.Write("Entrer votre choix : ");
            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }

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
                Console.WriteLine("Sortie du programme...");
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
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                menu();
            }
        }
        
        public void configBackup()
        {
            Console.Clear();
            Console.WriteLine("1. Sauvegarde complète");
            Console.WriteLine("2. Sauvegarde différentielle");
            Console.WriteLine("3. Retour");
            Console.WriteLine("4. Quitter");
        
            Console.Write("Entrer votre choix : ");
            int choiceBackup = 0;
            try
            {
                choiceBackup = Convert.ToInt32(Console.ReadLine());
            }catch(FormatException){}

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
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                configBackup();
            }
        }

        public void startBackup()
        {
            Console.Clear();
            Console.WriteLine("1. Validation du lancement d'une sauvegarde");
            Console.WriteLine("2. Retour");
            Console.WriteLine("3. Quitter");
            
            Console.Write("Entrer votre choix : ");
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
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                startBackup();
            }
        }

        public void showConfig()
        {
            Console.Clear();
            Console.WriteLine("1. Validation de l'affichage des configurations");
            Console.WriteLine("2. Retour");
            Console.WriteLine("3. Quitter");
            
            Console.Write("Entrer votre choix : ");
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
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                showConfig();
            }
        }

        public void changeConfig()
        {
            //code
            Console.Clear();
            Console.WriteLine("1. Changer la langue");
            Console.WriteLine("2. Changer la source par defaut de sauvegarde");
            Console.WriteLine("3. Changer la cible par defaut de sauvegarde");
            Console.WriteLine("4. Nettoyer la source récente de suavegarde");
            Console.WriteLine("5. Nettoyer la cible récente de suavegarde");
            Console.WriteLine("6. Changer le temps de rétention");
            Console.WriteLine("7. Réinitiliser les configurations");
            Console.WriteLine("8. Retour");
            Console.WriteLine("9. Quitter");
            
            Console.Write("Entrer votre choix : ");
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
                        menu();
                        break;
                    case 5 :
                        menu();
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
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                changeConfig();
            }
        }

        public void help()
        {
            //code
            Console.Clear();
            Console.WriteLine("Aide : \n");
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
            Console.WriteLine("Pour configurer une sauvegarde complète : Taper 1. Puis 1.");
            Console.WriteLine("Pour configurer une sauvegarde différentielle : Taper 1. Puis 2.");
            Console.WriteLine("Pour lancer une sauvegarde : Taper 2. Puis 1.");
            Console.WriteLine("Pour afficher les configurations : Taper 3. Puis 1.");
            Console.WriteLine("Pour changer la langue : Taper 4. Puis 1. Puis ....");
            Console.WriteLine("Pour modifier la source des sauvegardes par défaut : Taper 4. Puis 2. Puis 1.");
            Console.WriteLine("Pour nettoyer la source des sauvegardes par défaut : Taper 4. Puis 2. Puis 2.");
            Console.WriteLine("Pour modifier la cible des sauvegardes par défaut : Taper 4. Puis 3. Puis 1.");
            Console.WriteLine("Pour nettoyer la cible des sauvegardes par défaut : Taper 4. Puis 3. Puis 2.");
            Console.WriteLine("Pour nettoyer la source récente des sauvegardes : Taper 4. Puis 4. Puis 1.");
            Console.WriteLine("Pour nettoyer la cible récente des sauvegardes : Taper 4. Puis 5. Puis 1.");
            Console.WriteLine("Pour modifier le temps de conservation : Taper 4. Puis 6. Puis 1.");
            Console.WriteLine("Pour nettoyer entièrement les configurations : Taper 4. Puis 7. Puis 1. \n");
            
            Console.WriteLine("1. Retour");
            Console.WriteLine("2. Quitter");
            
            Console.Write("Entrer votre choix : ");
            int choiceBackup = Convert.ToInt32(Console.ReadLine());
                
            if (choiceBackup == 1)
            {
                menu();
                return;
            }
            if (choiceBackup == 2)
            {
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                help();
            }
        }

        public void fullBackup()
        {
            //code
            Console.Clear();
            Console.WriteLine("Choisissez un nom pour la sauvegarde complète :");
            vmCLI.name = Console.ReadLine();
            while (string.IsNullOrEmpty(vmCLI.sourceDir))
            {
                Console.WriteLine("Choisissez une source :");
                vmCLI.sourceDir = Console.ReadLine();
            }

            while (string.IsNullOrEmpty(vmCLI.targetDir))
            {
                Console.WriteLine("Choisissez une cible :");
                vmCLI.targetDir = Console.ReadLine();            
            }

            vmCLI.instantiateFullBackup();
            menu();        }

        public void diffBackup()
        {
            Console.Clear();
            Console.WriteLine("Choisissez un nom pour la sauvegarde différentiel :");
            vmCLI.name = Console.ReadLine();
            while (string.IsNullOrEmpty(vmCLI.sourceDir))
            {
                Console.WriteLine("Choisissez une source :");
                vmCLI.sourceDir = Console.ReadLine();
            }

            while (string.IsNullOrEmpty(vmCLI.targetDir))
            {
                Console.WriteLine("Choisissez une cible :");
                vmCLI.targetDir = Console.ReadLine();            
            }

            vmCLI.instantiateDiffBackup();
            menu();
        }

        public void startBackupValid()
        {
            Console.Clear();
            List<string> listNames = vmCLI.getThreadsNames();
            for (int i = 0; i < listNames.Count; i++)
            {
                Console.WriteLine("{0} {1}", i+1, listNames[i]);
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

            if (input <= -1 || input >= listNames.Count)
            {
                Console.WriteLine("Mauvais input");
                menu();
            }
            else
            {
                vmCLI.startBackup(listNames[input]);
            }
            menu();
        }

        public void showConfigValid()
        {
            //code
            Console.Clear();
            Console.WriteLine("Lancement définitif de l'affichage des configurations");
            // Config.writeConfig(@".\\CONF\conf.json");
            // Config.readConfig(@".\\CONF\conf.json");
            menu();
        }
        
        public void chooseLanguage()
        {
            //code
            Console.Clear();
            Console.WriteLine("1. Choisir Français");
            Console.WriteLine("2. Choisir Anglais");
            Console.WriteLine("3. Retour");
            Console.WriteLine("4. Quitter");
            
            Console.Write("Entrer votre choix : ");
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
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                changeConfig();
            }
        }

        public void defaultSaveSource()
        {
            //code
            Console.Clear();
            Console.WriteLine("1. Modifier");
            Console.WriteLine("2. Nettoyer");
            Console.WriteLine("3. Retour");
            Console.WriteLine("4. Quitter");
            
            Console.Write("Entrer votre choix : ");
            int choiceActionDSS = Convert.ToInt32(Console.ReadLine());

            if (choiceActionDSS > 0 && choiceActionDSS <= 3)
            {
                switch (choiceActionDSS)
                {
                    case 1 :
                        changeDSS();
                        return;
                    case 2 :
                        cleanDSS();
                        return;
                    case 3 :
                        menu();
                        return;
                }
            }
            if (choiceActionDSS == 4)
            {
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                changeConfig();
            }
            
        }
        
        public void changeDSS()
        {
            Console.Clear();
            Console.WriteLine("Entrez la nouvelle source de sauvegarde par défaut : ");
            string newDSS = Console.ReadLine();

            Config.writeConfig("config.json",newDSS);
            Console.WriteLine("La nouvelle source de sauvegarde par defaut a été enregistrée dans le fichier de configuration.");
        }

        public void cleanDSS()
        {
            Console.Clear();
            Config.writeConfig("config.json", @"\\BACKUP\test");
            Console.WriteLine("La source de sauvegarde par défaut a été nettoyée avec succès.");
        }

        public void defaultSaveTarget()
        {
            //code
            Console.Clear();
            Console.WriteLine("1. Modifier");
            Console.WriteLine("2. Nettoyer");
            Console.WriteLine("3. Retour");
            Console.WriteLine("4. Quitter");
            
            Console.Write("Entrer votre choix : ");
            int choiceActionDSS = Convert.ToInt32(Console.ReadLine());

            if (choiceActionDSS > 0 && choiceActionDSS <= 3)
            {
                switch (choiceActionDSS)
                {
                    case 1 :
                        changeDST();
                        return;
                    case 2 :
                        cleanDST();
                        return;
                    case 3 :
                        menu();
                        return;
                }
            }
            if (choiceActionDSS == 4)
            {
                Console.WriteLine("Sortie du programme...");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Choix invalide. Essayez à nouveau.");
                changeConfig();
            }
        }

        public void changeDST()
        {
            Console.Clear();
            Console.WriteLine("Entrez la nouvelle cible de sauvegarde par défaut : ");
            string newDST = Console.ReadLine();

            Config.writeConfig("config.json",newDST);
            Console.WriteLine("La nouvelle cible de sauvegarde par defaut a été enregistrée dans le fichier de configuration.");
        }

        public void cleanDST()
        {
            Console.Clear();
            Config.writeConfig("config.json", @"\\BACKUP\bck");
            Console.WriteLine("La cible de sauvegarde par défaut a été nettoyée avec succès.");
        }
    }
}




