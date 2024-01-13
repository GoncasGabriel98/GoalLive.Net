using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoalLive.Net.ListTodayGames
{
    class ListTodayGamesByLeague
    {
        public static void ShowMenu()
        {
            Console.WriteLine("1. Premier League");
            Console.WriteLine("2. LaLiga");
            Console.WriteLine("3. Serie A");
            Console.WriteLine("4. Ligue 1");
            Console.WriteLine("5. Liga Portugal Betclic");
            Console.WriteLine("6. Exit");
        }

        public static async Task Main()
        {
            Console.WriteLine("Choose the league you want:");
            Console.WriteLine(); // Add other other line to improve formating
            ShowMenu();
            Console.Write("Choose one option: ");
            string League = Console.ReadLine();

            string leagueConvert;

            if (League != null)
                leagueConvert = ConvertLeague(League);
            else
                return;

            if (leagueConvert == "Error")
                return;
          
            // Base URl
            string baseUrl = "https://api.sofascore.com/api/v1/sport/football/scheduled-events/";

            // Get Date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            // Join base url string and Date
            string apiUrl = $"{baseUrl}{date}";

            try
            {
                // Make the HTTP request
                string json = await GetJsonFromApi(apiUrl);

                // Deserialize the JSON and extract the desired fields
                var events = JsonConvert.DeserializeObject<RootObject>(json)?.Events;

                if (events != null)
                {
                    foreach (var eventData in events)
                    {
                        // Extract the desired fields
                        var uniqueTournamentName = eventData.Tournament?.UniqueTournament?.Name;

                        if (leagueConvert == uniqueTournamentName)
                        {
                            var sportName = eventData.Tournament?.Category?.Sport?.Name;
                            var startTimestamp = eventData.StartTimestamp;
                            var homeTeamName = eventData.HomeTeam?.Name;
                            var homeScoreTeam = eventData.HomeScore?.Current;
                            var awayTeamName = eventData.AwayTeam?.Name;
                            var awayScoreTeam = eventData.AwayScore?.Current;

                            // Print the extracted fields
                            Console.WriteLine($"{uniqueTournamentName}");

                            if (homeScoreTeam != null && awayScoreTeam != null)
                                Console.WriteLine($"{homeTeamName} {homeScoreTeam} VS {awayScoreTeam} {awayTeamName}");
                            else
                                Console.WriteLine($"{homeTeamName} VS {awayTeamName}");

                            Console.WriteLine();
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Failed to deserialize JSON.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string ConvertLeague(string League)
        {
            string leagueconvert;

            switch (League)
            {
                case "1":
                    leagueconvert = "Premier League";
                    break;

                case "2":
                    leagueconvert = "LaLiga";
                    break;

                case "3":
                    leagueconvert = "Serie A";
                    break;

                case "4":
                    leagueconvert = "Ligue 1";
                    break;
                case "5":
                    leagueconvert = "Liga Portugal Betclic";
                    break;

                default:
                    leagueconvert = "Error";
                    Console.Clear();
                    break;
            }

            return leagueconvert;
        }

        static async Task<string> GetJsonFromApi(string apiUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Make the GET request
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the JSON content
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
