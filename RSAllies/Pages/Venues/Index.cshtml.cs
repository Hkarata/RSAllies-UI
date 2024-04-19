using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;

namespace RSAllies.Pages.Venues;

public class IndexModel(ApiClient apiClient) : PageModel
{
    public UserDto? UserData { get; set; }
    public Guid? VenueId { get; private set; }

	public string? StatusMessage { get; set; }

	public List<SessionDto>? Sessions { get; set; }
	public async Task<IActionResult> OnGetAsync()
	{
        var session = HttpContext.Session.GetString("UserSession");
        UserData = JsonConvert.DeserializeObject<UserDto>(session!);
        if (string.IsNullOrEmpty(session)) return RedirectToPage("/Login");
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
        return Page();
    }
}