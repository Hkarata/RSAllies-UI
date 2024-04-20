using Newtonsoft.Json;
using RSAllies.Data.Contracts;
using RSAllies.Data.HelperTypes;

namespace RSAllies.MarkingService;

public class ApiClient(HttpClient httpClient)
{
    public async Task<Result<List<AnswerDto>>?> GetAnswers()
    {
        var response = await httpClient.GetAsync("/api/answers");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Result<List<AnswerDto>>>(content)!;
        return result;
    }

    public async Task PostUserScore(ScoreDto score)
    {
        await httpClient.PostAsJsonAsync<ScoreDto>("/api/score", score);
    }
}