using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.English;

public class Login
{
	[Required, Phone]
	public string Phone { get; set; } = string.Empty;

	[Required]
	public string Password { get; set; } = string.Empty;
}