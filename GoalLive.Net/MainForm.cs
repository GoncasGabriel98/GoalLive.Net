using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainForm
{
    public static void ShowMenu()
    {
        Console.WriteLine("1. API Check");
        Console.WriteLine("2. List Today Games");
        Console.WriteLine("3. List Today Games By League");
        Console.WriteLine("4. Exit");
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
                    Console.WriteLine("Checking API...");
                    Program.Main().GetAwaiter().GetResult();
                    Console.Clear();
                    break;

                case "2":
                    Console.WriteLine("Option 2.");
                    GoalLive.Net.ListTodayGames.ListTodayGames.Main();
                    Console.Clear();
                    break;

                case "3":
                    Console.WriteLine("Option 3.");
                    GoalLive.Net.ListTodayGames.ListTodayGamesByLeague.Main();
                    Console.Clear();
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Leaving the program...");
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again.");
                    Console.Clear();
                    break;
            }

            Console.WriteLine(); // Add other other line to improve formating

        } while (!exit);
    }
}