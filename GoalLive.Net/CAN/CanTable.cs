using GoalLive.Net.LeagueTable;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoalLive.Net.CAN
{
    class CanTable
    {
        public static async Task Main()
        {
            Console.Clear();
            string apiUrl = "https://api.sofascore.com/api/v1/unique-tournament/270/season/56021/standings/total";

            Console.WriteLine($"apiUrl: {apiUrl}");

            try
            {
                // Fazer a solicitação HTTP
                string json = await GetJsonFromApi(apiUrl);
                Console.WriteLine($"json: {json}");

                // Desserializar o JSON e extrair os campos desejados
                var root = JsonSerializer.Deserialize<JsonData>(json);

                if (root != null && root.Standings != null && root.Standings.Count > 0)
                {
                    // Imprimir cabeçalho
                    PrintHeader("Position", "Team", "Matches", "Wins", "Draws", "Losses", "GF", "GC", "Points", "Promotion");

                    foreach (var group in root.Standings)
                    {
                        foreach (var row in group.Rows)
                        {
                            var position = row?.Position;
                            var team = row?.Team?.Name;
                            var matches = row?.Matches;
                            var wins = row?.Wins;
                            var draws = row?.Draws;
                            var losses = row?.Losses;
                            var scoresFor = row?.ScoresFor;
                            var scoresAgainst = row?.ScoresAgainst;
                            var points = row?.Points;
                            var promotion = row?.Promotion?.Text;

                            // Imprimir dados da linha
                            PrintRow(position.ToString(), team, matches.ToString(), wins.ToString(), draws.ToString(), losses.ToString(), scoresFor.ToString(), scoresAgainst.ToString(), points.ToString(), promotion);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Falha na desserialização JSON.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static async Task<string> GetJsonFromApi(string apiUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Fazer a solicitação GET
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Verificar se a solicitação foi bem-sucedida
                response.EnsureSuccessStatusCode();

                // Ler e retornar o conteúdo JSON
                return await response.Content.ReadAsStringAsync();
            }
        }

        static void PrintHeader(params string[] values)
        {
            int columnWidth = 10;

            // Imprimir cada valor com o espaçamento apropriado
            foreach (var value in values)
            {
                Console.Write(value.PadRight(columnWidth));
            }

            // Mover para a próxima linha para os dados
            Console.WriteLine();

            // Imprimir uma linha separadora
            Console.WriteLine(new string('-', 100));
        }

        static void PrintRow(params string[] values)
        {
            int columnWidth = 10;

            // Imprimir cada valor com o espaçamento apropriado
            foreach (var value in values)
            {
                Console.Write(value.PadRight(columnWidth));
            }

            // Mover para a próxima linha para a próxima linha
            Console.WriteLine();
        }
    }
}
