using Microsoft.Extensions.Caching.Memory;
using RSAllies.Data.Contracts;
using Wolverine;

namespace RSAllies.MarkingService;

public class UserResponseDtoHandler(ApiClient apiClient, IMessageBus bus, IMemoryCache cache, ILogger<UserResponseDtoHandler> logger)
{
    private async Task<List<AnswerDto>?> GetAnswers()
    {
        if (cache.TryGetValue("Answers", out List<AnswerDto>? answers)) return answers;
        var result = await apiClient.GetAnswers();
        answers = result!.Value;

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(2)); // Set cache to expire after 1 hour

        cache.Set("Answers", answers, cacheEntryOptions);

        return answers;
    }

    public async Task Handle(UserResponseDto userResponse)
    {
        var userScore = MarkingService.Mark(await GetAnswers(), userResponse.Responses);

        if (userScore >= 17)
        {
            await bus.SendAsync(new CreateCertificate { Name = userResponse.Name, UserId = userResponse.UserId });
        }

        var score = new ScoreDto
        {
            UserId = userResponse.UserId,
            ScoreValue = userScore
        };

        await apiClient.PostUserScore(score);
    }
}