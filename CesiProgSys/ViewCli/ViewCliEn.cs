using System;

namespace CesiProgSys.ViewCli
{
    public class ViewCliEn : IViewCli
    {
        public void menu()
        {
            Console.WriteLine("1. Configure a backup");
            Console.WriteLine("2. Start a backup");
            Console.WriteLine("3. Show configurations");
            Console.WriteLine("4. Change les configurations");
            Console.WriteLine("5. Help");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice : ");
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
                Console.WriteLine("Exiting the program...");
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
            Console.WriteLine("1. Full backup");
            Console.WriteLine("2. Differential backup");
            Console.WriteLine("3. Return");
            Console.WriteLine("4. Exit");
        
            Console.Write("Enter your choice : ");
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
            Console.WriteLine("1. Validation of the start of a backup");
            Console.WriteLine("2. Return");
            Console.WriteLine("3. Exit");
            
            Console.Write("Enter your choice : ");
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
            Console.WriteLine("1. Validation of the display of configurations");
            Console.WriteLine("2. Return");
            Console.WriteLine("3. Exit");
            
            Console.Write("Enter your choice : ");
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
            Console.WriteLine("Change configurations");
        }

        public void help()
        {
            //code
            Console.WriteLine("5. Help");
        }

        public void fullBackup()
        {
            //code
            Console.WriteLine("Show full backup");
        }

        public void diffBackup()
        {
            //code
            Console.WriteLine("Show diff backup");
        }

        public void startBackupValid()
        {
            //code
        }

        public void showConfigValid()
        {
            //code
        }
    }
}




