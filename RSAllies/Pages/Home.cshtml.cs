using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Contracts.Contracts;

namespace RSAllies.Pages
{
	public class HomeModel(ApiClient apiClient) : PageModel
	{
		public UserDto? UserData { get; set; }
		public string StatusMessage { get; set; } = string.Empty;

		public BookingDto? CurrentBooking { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			var session = HttpContext.Session.GetString("UserSession");
			if (string.IsNullOrEmpty(session))
			{
				return RedirectToPage("./Login");
			}

			UserData = JsonConvert.DeserializeObject<UserDto>(session);

			StatusMessage = $"Welcome!, {UserData?.FirstName} {UserData?.LastName}";

			var result = await apiClient.GetCurrentUserBooking(UserData!.Id).ConfigureAwait(false);

			if (result != null)
			{
				CurrentBooking = result.Value;
			}

			return Page();
		}


	}
}
