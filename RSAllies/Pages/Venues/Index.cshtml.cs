using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts;

namespace RSAllies.Pages.Venues;

public class IndexModel(ApiClient apiClient) : PageModel
{
    public Guid? VenueId { get; private set; }

    public string? StatusMessage { get; set; }

    public List<SessionDto>? Sessions { get; set; }
    public async Task OnGetAsync()
    {
        var encodedId = Request.Query["value1"];
        var result = await apiClient.GetVenueSessionsAsync(encodedId!);
        if (result is null)
        {
            StatusMessage = "There are no sessions for this venue.";
        }
        else
        {
            Sessions = result.Value;
        }
    }
}