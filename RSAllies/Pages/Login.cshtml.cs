using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Models.English;
using RSAllies.Models.Swahili;

namespace RSAllies.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public Login? Login { get; set; }
    
    [BindProperty]
    public SLogin? SLogin { get; set; }
    public void OnGet()
    {
        
    }
}