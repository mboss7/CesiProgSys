using System;

namespace CesiProgSys.ViewCli
{
    public class ViewCliFr : IViewCli
    {
        public void menu()
        {
            while (true)
            {
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
                            break;
                        case 2 :
                            startBackup();
                            break;
                        case 3 :
                            showConfig();
                            break;
                        case 4 :
                            changeConfig();
                            break;
                        case 5 :
                            help();
                            break;
                    }
                }
                if (choice == 6)
                {
                    Console.WriteLine("Sortie du programme...");
                    return;
                }
                else
                {
                    Console.WriteLine("Choix invalide. Essayez à nouveau.");
                }
            }
        }
        
        public void configBackup()
        {
            //code
            Console.WriteLine("1. Configurer une sauvegarde");
        }

        public void startBackup()
        {
            //code
            Console.WriteLine("2. Lancer une sauvegarde");
        }

        public void showConfig()
        {
            //code
            Console.WriteLine("3. Afficher les configurations");
        }

        public void changeConfig()
        {
            //code
            Console.WriteLine("4. Changer les configurations");
        }

        public void help()
        {
            //code
            Console.WriteLine("5. Aide");
        }
    }
}




