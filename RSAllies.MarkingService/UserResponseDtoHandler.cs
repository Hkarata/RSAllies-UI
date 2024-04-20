using RSAllies.Data.Contracts;

namespace RSAllies.MarkingService;

public class UserResponseDtoHandler(ApiClient apiClient)
{
    private List<AnswerDto>? Answers { get; set; }

    public async Task Handle(UserResponseDto userResponse)
    {
        if (Answers?.Count == 0)
        {
            var result = await apiClient.GetAnswers();
            Answers = result!.Value;
        }

        var userScore = MarkingService.Mark(Answers!, userResponse.Responses);

        var score = new ScoreDto
        {
            UserId = userResponse.UserId,
            ScoreValue = userScore
        };

        await apiClient.PostUserScore(score);

    }
}