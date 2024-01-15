using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainForm
{
    // Display the main menu options
    public static void ShowMenu()
    {
        Console.WriteLine("1. API Check");
        Console.WriteLine("2. List Today Games");
        Console.WriteLine("3. List Today Games By League");
        Console.WriteLine("4. Table");
        Console.WriteLine("5. CAN");
        Console.WriteLine("6. UEFA Champions League");
        Console.WriteLine("7. Exit");
    }

    // Main method to execute the program
    public static void Main()
    {
        bool exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("Hello Everyone!!");
            Console.WriteLine("I'm GoalLive.Net");
            Console.WriteLine(); // Add another line to improve formatting
            ShowMenu();
            Console.Write("Choose one option: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Checking API...");
                    _ = Program.Main();
                    Console.Clear();
                    break;

                case "2":
                    Console.WriteLine("Option 2.");
                    _ = GoalLive.Net.ListTodayGames.ListTodayGames.Main();
                    Console.Clear();
                    break;

                case "3":
                    Console.WriteLine("Option 3.");
                    _ = GoalLive.Net.ListTodayGames.ListTodayGamesByLeague.Main();
                    Console.Clear();
                    break;

                case "4":
                    Console.WriteLine("Option 4.");
                    GoalLive.Net.LeagueTable.LeagueForm.MainForm();
                    Console.Clear();
                    break;

                case "5":
                    Console.WriteLine("Option 5.");
                    GoalLive.Net.CAN.CanForm.MainForm();
                    Console.Clear();
                    break;

                case "6":
                    Console.WriteLine("Option 6.");
                    GoalLive.Net.UEFAChampionsLeague.UCLForm.MainForm();
                    Console.Clear();
                    break;

                case "7":
                    exit = true;
                    Console.WriteLine("Leaving the program...");
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
