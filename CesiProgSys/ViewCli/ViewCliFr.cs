using System;
using CesiProgSys.ToolsBox;


namespace CesiProgSys.ViewCli
{
    public class ViewCliFr : IViewCli
    {
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
            int choice = Convert.ToInt32(Console.ReadLine());

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
            int choiceBackup = Convert.ToInt32(Console.ReadLine());
            
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
            int choiceBackup = Convert.ToInt32(Console.ReadLine());
                
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
            int choiceBackup = Convert.ToInt32(Console.ReadLine());
                
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
            Console.WriteLine("Change les configurations");
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
            Console.WriteLine("Affichage de la sauvegarde complète");
        }

        public void diffBackup()
        {
            //code
            Console.Clear();
            Console.WriteLine("Affichage de la sauvegarde différentielle");
        }

        public void startBackupValid()
        {
            //code
            Console.Clear();
            Console.WriteLine("Lancement définitif de la sauvegarde");
            Environment.Exit(0);
        }

        public void showConfigValid()
        {
            //code
            Console.Clear();
            Console.WriteLine("Lancement définitif de l'affichage des configurations");
            Config.writeConfig(@".\\CONF\conf.json");
            Config.readConfig(@".\\CONF\conf.json");

        }
    }
}




