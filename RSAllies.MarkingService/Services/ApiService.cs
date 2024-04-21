using System.Net.Http.Json;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;
using RSAllies.Data.HelperTypes;

namespace RSAllies.MarkingService.Services;

public class ApiService
{
    private static readonly HttpClient HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

    public static async Task PostUserScore(ScoreDto score)
    {
        await HttpClient.PostAsJsonAsync<ScoreDto>("/api/score", score);
    }
}