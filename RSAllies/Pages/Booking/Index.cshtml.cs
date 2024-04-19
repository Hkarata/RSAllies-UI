using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts.Contracts;

namespace RSAllies.Pages.Booking;

public class IndexModel(ApiClient apiClient) : PageModel
{
	public string StatusMessage { get; set; } = string.Empty;

	public List<VenueDto>? Venues { get; set; }

	public List<FilteredSessionDto>? Sessions { get; set; }
	public async Task OnGetAsync()
	{
		var result = await apiClient.GetVenuesAsync();
		Venues = result.Value;
	}

}