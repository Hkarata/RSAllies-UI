using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Models.English;
using RSAllies.Models.Swahili;

namespace RSAllies.Pages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public UserInput? Input {get;set;}
    
    [BindProperty]
    public SUserInput? SInput { get; set; }
    
    public void OnGet()
    {
        
    }
}