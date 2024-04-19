using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;
using RSAllies.Models.English;
using RSAllies.Models.Swahili;

namespace RSAllies.Pages.Booking
{
	public class SearchModel(ApiClient apiClient) : PageModel
	{
		public UserDto? UserData { get; set; }

		public string StatusMessage { get; set; } = string.Empty;

		[BindProperty]
		public SessionFilter? Filter { get; set; }

		[BindProperty]
		public SSessionFilter? SFilter { get; set; }
		public List<FilteredSessionDto>? Sessions { get; set; }

		public IActionResult OnGetAsync()
		{
			var session = HttpContext.Session.GetString("UserSession");
			if (string.IsNullOrEmpty(session))
			{
				return RedirectToPage("/Login");
			}
			UserData = JsonConvert.DeserializeObject<UserDto>(session!);

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
            var session = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(session))
            {
                return RedirectToPage("/Login");
            }
            UserData = JsonConvert.DeserializeObject<UserDto>(session!);

            var submittedForm = Request.Form["submittedForm"]; // Access form name
			if (submittedForm == "Swahili")
			{
				var result = await apiClient.GetFilteredSessionsAsync(SFilter!.Region, SFilter!.Date);
				if(result == null)
                {
                    StatusMessage = "There are no sessions found. Hamna nafasi";
                    return Page();
                }
				Sessions = result!.Value;
			}
			else
			{
				var result = await apiClient.GetFilteredSessionsAsync(Filter!.Region, Filter!.Date);
				Sessions = result!.Value;
			}

			return Page();

		}
	}
}
