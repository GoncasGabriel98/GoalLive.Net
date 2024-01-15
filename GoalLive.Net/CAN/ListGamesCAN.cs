using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalLive.Net.CAN
{
    class ListGamesCAN
    {
        public static async Task Main()
        {
            Console.Clear();
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
                        var uniqueTournamentName = eventData?.Tournament?.UniqueTournament?.Name;
                        var id = eventData?.Tournament?.Id.ToString();

                        if (id == "44545")
                        {
                            var sportName = eventData?.Tournament?.Category?.Sport?.Name;
                            var startTimestamp = eventData?.StartTimestamp;
                            var homeTeamName = eventData?.HomeTeam?.Name;
                            var homeScoreTeam = eventData?.HomeScore?.Current;
                            var awayTeamName = eventData?.AwayTeam?.Name;
                            var awayScoreTeam = eventData?.AwayScore?.Current;
                            var Round = eventData?.RoundInfo?.Round;
                            var GameStatus = eventData?.Status?.Description;

                            // Print the extracted fields
                            Console.WriteLine($"{uniqueTournamentName}");
                            Console.WriteLine($"{sportName}");

                            if (homeScoreTeam != null && awayScoreTeam != null)
                                Console.WriteLine($"{homeTeamName} {homeScoreTeam} VS {awayScoreTeam} {awayTeamName}");
                            else
                                Console.WriteLine($"{homeTeamName} VS {awayTeamName}");

                            Console.WriteLine($"Round {Round}");
                            Console.WriteLine($"Status {GameStatus}");

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
