namespace RSAllies.Contracts.Contracts;

public record AuthenticateDto
{
	public string Phone { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}