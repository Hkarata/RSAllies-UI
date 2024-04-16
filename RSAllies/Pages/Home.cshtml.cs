using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Contracts;

namespace RSAllies.Pages
{
	public class WelcomeModel : PageModel
	{
		public UserDto? UserData { get; set; }
		public string StatusMessage { get; set; } = string.Empty;

		public IActionResult OnGetAsync()
		{
			var session = HttpContext.Session.GetString("UserSession");
			if (string.IsNullOrEmpty(session))
			{
				return RedirectToPage("./Login");
			}
			UserData = JsonConvert.DeserializeObject<UserDto>(session!);

			StatusMessage = $"Welcome!, {UserData!.FirstName} {UserData!.LastName}";

			return Page();
		}

	}
}
