using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalLive.Net.UEFAChampionsLeague
{

    public class UCLForm
    {
        // Display the main menu options
        public static void ShowMenu()
        {
            Console.WriteLine("1. List Today Games");
            Console.WriteLine("2. Table");
            Console.WriteLine("3. Exit");
        }

        // Main method to execute the program
        public static void MainForm()
        {
            bool exit = false;

            do
            {
                Console.Clear();
                ShowMenu();
                Console.Write("Choose one option: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Option 1.");
                        _ = GoalLive.Net.UEFAChampionsLeague.ListGamesUCL.Main();
                        Console.Clear();
                        break;

                    /*case "2":
                        Console.WriteLine("Option 2.");
                        _ = GoalLive.Net.UEFAChampionsLeague.UCLTable.Main();
                        Console.Clear();
                        break;*/

                    case "3":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid Option. Try Again.");
                        break;
                }
                Console.WriteLine(); // Add another line to improve formatting
                Console.ReadLine(); // Pause before clearing the screen
                Console.Clear(); // Clear the screen after the switch

            } while (!exit);
        }
    }
}

