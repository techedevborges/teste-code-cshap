using Newtonsoft.Json;


public class Program
{
    public static void Main()
    {
        Run().GetAwaiter().GetResult(); // Executa o método async
    }

    public static async Task Run()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);
        Console.WriteLine("Team " + teamName + " scored " + totalGoals + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);
        Console.WriteLine("Team " + teamName + " scored " + totalGoals + " goals in " + year);
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        int totalGoals = 0;
        totalGoals += await GetGoalsAsync(team, year, "team1", "team1goals");
        totalGoals += await GetGoalsAsync(team, year, "team2", "team2goals");
        return totalGoals;
    }

    private static async Task<int> GetGoalsAsync(string team, int year, string teamParam, string goalField)
    {
        int total = 0;
        int page = 1;
        bool hasMore = true;

        using (HttpClient client = new HttpClient())
        {
            while (hasMore)
            {
                string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&{teamParam}={Uri.EscapeDataString(team)}&page={page}";
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<ApiResponse>(response);

                foreach (var match in data.data)
                {
                    total += int.Parse(match[goalField]);
                }

                page++;
                hasMore = page <= data.total_pages;
            }
        }

        return total;
    }

    // Classes para deserializar JSON
    public class ApiResponse
    {
        public int total_pages { get; set; }
        public Match[] data { get; set; }
    }

    public class Match : System.Collections.Generic.Dictionary<string, string> { }
}
