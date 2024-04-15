using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RSAllies.Pages;

public class Booking : PageModel
{
    public string StatusMessage { get; set; } = string.Empty;
    
    public void OnGet()
    {
        
    }
}