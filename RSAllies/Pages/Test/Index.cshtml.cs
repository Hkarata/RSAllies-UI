using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;

namespace RSAllies.Pages.Test
{
    public class IndexModel : PageModel
    {
        public UserDto? UserData { get; set; }
        public IActionResult OnGet()
        {
            var session = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(session)) return RedirectToPage("/Login");
            UserData = JsonConvert.DeserializeObject<UserDto>(session!);
            return Page();
        }
    }
}
