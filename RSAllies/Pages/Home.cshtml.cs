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
        public IActionResult OnGet()
        {
            var session = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(session))
            {
                return RedirectToPage("./Login");
            }
            UserData = JsonConvert.DeserializeObject<UserDto>(session!);

            return Page();
        }
        
    }
}
