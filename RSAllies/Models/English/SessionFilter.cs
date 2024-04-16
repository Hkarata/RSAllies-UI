using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.English;

public class SessionFilter
{
	[Required(ErrorMessage = "Please select a region")]
	public string Region { get; set; } = string.Empty;

	[Required(ErrorMessage = "Please select a date")]
	public DateTime Date { get; set; }
}