using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;

namespace RSAllies.Pages.Booking;

public class IndexModel(ApiClient apiClient) : PageModel
{
    public UserDto? UserData { get; set; }
    public string StatusMessage { get; set; } = string.Empty;

    public List<VenueDto>? Venues { get; set; }

    public List<FilteredSessionDto>? Sessions { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        var session = HttpContext.Session.GetString("UserSession");
        if (string.IsNullOrEmpty(session)) return RedirectToPage("/Login");
        UserData = JsonConvert.DeserializeObject<UserDto>(session!);
        var result = await apiClient.GetVenuesAsync();
        Venues = result.Value;
        return Page();
    }

}