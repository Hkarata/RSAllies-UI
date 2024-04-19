namespace RSAllies.Contracts.Contracts;

public record UserResponseDto
{
    public Guid UserId { get; set; }
    public List<ResponseDto> Responses { get; set; }
}