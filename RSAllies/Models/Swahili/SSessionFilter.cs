using System.ComponentModel.DataAnnotations;

namespace RSAllies.Models.Swahili;

public class SSessionFilter
{
	[Required(ErrorMessage = "Chagua mkoa wako")]
	public string Region { get; set; } = string.Empty;

	[Required(ErrorMessage = "Chagua tarehe")]
	public DateTime Date { get; set; }
}