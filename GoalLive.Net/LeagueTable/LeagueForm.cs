using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalLive.Net.LeagueTable
{
    public class LeagueForm
    {
        // Display the main menu options
        public static void ShowMenu()
        {
            Console.WriteLine("1. Premier League");
            Console.WriteLine("2. Liga Portugal Betclic");
            Console.WriteLine("5. Exit");
        }

        // Main method to execute the program
        public static void MainForm()
        {
            {
                bool exit = false;

                do
                {
                    Console.Clear();
                    Console.WriteLine(); // Add another line to improve formatting
                    ShowMenu();
                    Console.Write("Choose one league: ");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            _ = PremierLeagueTable.Main();
                            Console.Clear();
                            break;

                        case "2":
                            _ = LigaPortugalBetclicTable.Main();
                            Console.Clear();
                            break;

                        case "3":
                            return;

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
}