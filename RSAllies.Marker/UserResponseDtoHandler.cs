using RSAllies.Contracts.Contracts;

namespace RSAllies.Marker;

public class UserResponseDtoHandler(ILogger<UserResponseDtoHandler> logger)
{
    public async Task Handle(UserResponseDto userResponse)
    {
        logger.LogInformation(userResponse.ToString());
    }
}