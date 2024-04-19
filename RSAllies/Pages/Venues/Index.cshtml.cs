using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Contracts.Contracts;

namespace RSAllies.Pages.Venues;

public class IndexModel(ApiClient apiClient) : PageModel
{
    public UserDto? UserData { get; set; }
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
        var session = HttpContext.Session.GetString("UserSession");
        UserData = JsonConvert.DeserializeObject<UserDto>(session!);
    }
}