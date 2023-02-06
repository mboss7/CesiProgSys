using System;

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
            Console.WriteLine("5. Aide");
        }

        public void fullBackup()
        {
            //code
            Console.Clear();
            Console.WriteLine("Affiche full backup");
        }

        public void diffBackup()
        {
            //code
            Console.Clear();
            Console.WriteLine("Affiche diff backup");
        }

        public void startBackupValid()
        {
            //code
            Console.Clear();
            Console.WriteLine("Lance définitivement la backup");
        }

        public void showConfigValid()
        {
            //code
            Console.Clear();
            Console.WriteLine("Lance définitivement l'affichage des configurations");
        }
    }
}




