using RSAllies.Data.Contracts;
using Wolverine;

namespace RSAllies;

public class UserResponsePublisher(IMessageBus messageBus)
{
    public async Task PublishUserResponses(UserResponseDto userResponse)
    {
        await messageBus.SendAsync(userResponse);
    }
}