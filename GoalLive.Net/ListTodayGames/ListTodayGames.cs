using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GoalLive.Net.ListTodayGames
{
    class ListTodayGames
    {
        public static async Task Main()
        {
            List<string> League = new List<string> { "Premier League", "LaLiga", "Serie A", "Ligue 1", "Liga Portugal Betclic" };


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

                        if (League.Any(s => s.Equals(uniqueTournamentName)))
                        {
                            var sportName = eventData.Tournament?.Category?.Sport?.Name;
                            var startTimestamp = eventData.StartTimestamp;
                            var homeTeamName = eventData.HomeTeam?.Name;
                            var homeScoreTeam = eventData.HomeScore?.Current;
                            var awayTeamName = eventData.AwayTeam?.Name;
                            var awayScoreTeam = eventData.AwayScore?.Current;

                            // Print the extracted fields
                            Console.WriteLine($"{uniqueTournamentName}");
                            Console.WriteLine($"{sportName}");

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