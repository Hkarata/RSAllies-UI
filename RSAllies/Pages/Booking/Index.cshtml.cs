using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts;
using RSAllies.Models.English;
using RSAllies.Models.Swahili;
using System.Text.Json;

namespace RSAllies.Pages;

public class BookingModel(ApiClient apiClient) : PageModel
{
    public string StatusMessage { get; set; } = string.Empty;

    public List<VenueDto>? Venues { get; set; }

    [BindProperty]
    public SessionFilter? Filter { get; set; }

    [BindProperty]
    public SSessionFilter? SFilter { get; set; }
    public async Task OnGetAsync()
    {
        var result = await apiClient.GetVenuesAsync();
        Venues = result.Value;
    }


    public async Task<IActionResult> OnPostAsync()
    {
        var submittedForm = Request.Form["submittedForm"]; // Access form name
        if (submittedForm == "Swahili")
        {
            var result = await apiClient.GetFilteredSessionsAsync(SFilter!.Region, SFilter!.Date);
            TempData["data"] = JsonSerializer.Serialize(result!.Value);
        }
        else
        {
            var result = await apiClient.GetFilteredSessionsAsync(Filter!.Region, Filter!.Date);
            TempData["data"] = JsonSerializer.Serialize(result!.Value);
        }

        return RedirectToPage("/Booking/SearchResults");
    }
}