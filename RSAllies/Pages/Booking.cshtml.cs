using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts;

namespace RSAllies.Pages;

public class BookingModel(ApiClient apiClient) : PageModel
{
    public string StatusMessage { get; set; } = string.Empty;
    
    public List<VenueDto>? Venues { get; set; }

    private IQueryable<VenueDto>? filteredVenues;
    public async Task OnGetAsync()
    {
        var result = await apiClient.GetVenuesAsync();
        Venues = result.Value;
    }
}