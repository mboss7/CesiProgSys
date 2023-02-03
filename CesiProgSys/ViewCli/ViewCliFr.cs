using System;

namespace CesiProgSys.ViewCli
{
    public class ViewCliFr : IViewCli
    {
        delegate void OptionDelegate();
        /*public void startProgram()
        {
            // Code pour la méthode 
        }*/
        public void menu()
        {
            
            OptionDelegate[] options = new OptionDelegate[] {
                new OptionDelegate(ViewCliFr.menu),
                //new OptionDelegate(option2.Execute)
            };

            while (true)
            {
                Console.WriteLine("1. Option 1");
                //Console.WriteLine("2. Option 2");
                Console.WriteLine("3. Quit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 3)
                {
                    Console.WriteLine("Exiting the program...");
                    return;
                }

                if (choice > 0 && choice <= options.Length)
                {
                    options[choice - 1]();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
        /*public void help()
        {
            // Code pour la méthode 
        }
        public string read()
        {
            // Code pour la méthode 
        }
        public void showConfig()
        {
            // Code pour la méthode 
        }
    }  */
    }
}

