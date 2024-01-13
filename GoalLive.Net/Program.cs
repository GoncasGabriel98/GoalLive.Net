using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        Console.Clear();
        string baseUrl = "https://api.sofascore.com/api/v1/sport/football/scheduled-events/"; // SofaScore API

        // Get Date
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        // Join base url string and Date
        string apiUrl = $"{baseUrl}{date}";

        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("API is OK. Status Code: " + response.StatusCode);
                }
                else
                {
                    Console.WriteLine("API is not OK. Status Code: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}