using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalLive.Net
{

    public class MainForm
    {
        public static void ShowMenu()
        {
            Console.WriteLine("1. API Check");
            Console.WriteLine("2. Other Option");
            Console.WriteLine("3. Exit");
        }

        public static void Main()
        {
            bool exit = false;

            do
            {
                Console.WriteLine("Hello Everyone!!");
                Console.WriteLine("I'm GoalLive.Net");
                Console.WriteLine(); // Add other other line to improve formating
                ShowMenu();
                Console.Write("Choose one option: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Chame o método desejado ou insira o código aqui
                        Console.WriteLine("Checking API...");
                        Program.Main().GetAwaiter().GetResult();
                        break;

                    case "2":
                        // Adicione mais opções conforme necessário
                        Console.WriteLine("Option 2.");
                        break;

                    case "3":
                        exit = true;
                        Console.WriteLine("Leaving the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        break;
                }

                Console.WriteLine(); // Add other other line to improve formating

            } while (!exit);
        }
    }
}