using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GoalLive.Net.ListTodayGames;
using Newtonsoft.Json;

namespace GoalLive.Net.LeagueTable
{
    class LigaPortugalBetclicTable
    {
        public static async Task Main()
        {
            Console.Clear();
            string apiUrl = "https://api.sofascore.com/api/v1/tournament/52/season/52769/standings/total";
            try
            {
                // Make the HTTP request
                string json = await GetJsonFromApi(apiUrl);

                // Deserialize the JSON and extract the desired fields
                var root = JsonConvert.DeserializeObject<JsonData>(json);

                if (root != null)
                {
                    foreach (var row in root.Standings[0].Rows)
                    {
                        var Position = row?.Position;
                        var Team = row?.Team?.Name;
                        var Points = row?.Points;
                        var Give = row?.Promotion?.Text;

                        // Print row data
                        if(Give != null)
                            PrintRow(Position.ToString(), Team, Points.ToString(), Give);
                        else
                            PrintRow(Position.ToString(), Team, Points.ToString());
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

        static void PrintRow(params string[] values)
        {
            int columnWidth = 5;
            int columnWidth1 = 20;
            int i = 0;
            // Print each value with appropriate spacing
            foreach (var value in values)
            {
                if(i != 1)
                    Console.Write(value.PadRight(columnWidth));
                else
                    Console.Write(value.PadRight(columnWidth1));
                i++;
            }

            // Move to the next line for the next row
            Console.WriteLine();
        }
    }
}
