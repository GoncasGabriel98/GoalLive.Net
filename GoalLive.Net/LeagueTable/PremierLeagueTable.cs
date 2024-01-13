using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GoalLive.Net.ListTodayGames;
using Newtonsoft.Json;

namespace GoalLive.Net.LeagueTable
{
    class PremierLeagueTable
    {
        public static async Task Main()
        {
            Console.Clear();
            string apiUrl = "https://api.sofascore.com/api/v1/unique-tournament/17/season/52186/standings/total";
        
            try
            {
                // Make the HTTP request
                string json = await GetJsonFromApi(apiUrl);

                // Deserialize the JSON and extract the desired fields
                var root = JsonConvert.DeserializeObject<JsonData>(json);

                if (root != null)
                {
                    //PrintHeader("Position", "Team", "Points", "Promotion");

                    foreach (var row in root.Standings[0].Rows)
                    {
                        var Position = row?.Position;
                        var Team = row?.Team?.Name;
                        var Points = row?.Points;
                        var Give = row?.Promotion?.Text;
                        var Matches = row?.Matches;

                        // Print row data
                        if (Give != null)
                            PrintRow(Position.ToString(), Team, Matches.ToString(), Points.ToString(), Give);
                        else
                            PrintRow(Position.ToString(), Team, Matches.ToString(), Points.ToString());
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

        /*static void PrintHeader(params string[] values)
        {
            int columnWidth = 10;

            // Imprime cada valor com o espaçamento apropriado
            foreach (var value in values)
            {
                Console.Write(value.PadRight(columnWidth));
            }

            // Move para a próxima linha para os dados
            Console.WriteLine();

            // Imprime uma linha separadora
            Console.WriteLine(new string('-', 100));
        }*/

        static void PrintRow(params string[] values)
        {
            int columnWidth = 5;
            int columnWidth1 = 25;
            int i = 0;
            // Print each value with appropriate spacing
            foreach (var value in values)
            {
                if (i != 1)
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
