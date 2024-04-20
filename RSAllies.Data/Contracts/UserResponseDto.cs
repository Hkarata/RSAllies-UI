namespace RSAllies.Data.Contracts;

public record UserResponseDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public List<ResponseDto> Responses { get; set; }
}