using RSAllies.Contracts.Contracts;
using Wolverine;

namespace RSAllies;

public class UserResponsePublisher(IMessageBus messageBus)
{
    public async Task PublishUserResponses(UserResponseDto userResponse)
    {
        await messageBus.SendAsync(userResponse);
    }
}