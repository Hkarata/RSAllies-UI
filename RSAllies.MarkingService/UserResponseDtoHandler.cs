using Microsoft.Extensions.Logging;
using RSAllies.Data.Contracts;
using Wolverine;

namespace RSAllies.MarkingService;

public class UserResponseDtoHandler(IMessageBus bus, ILogger<UserResponseDtoHandler> logger)
{
    public async Task Handle(UserResponseDto userResponse)
    {
        logger.LogInformation("Received responses for user with {UserId}",userResponse.UserId);
        var userScore = Services.MarkingService.Mark(userResponse.Responses);

        if (userScore <= 17)
        {
            await bus.SendAsync(new CreateCertificate { Name = userResponse.Name, UserId = userResponse.UserId });
        }

        var score = new ScoreDto
        {
            UserId = userResponse.UserId,
            ScoreValue = userScore
        };

        await Services.ApiService.PostUserScore(score);

    }

}