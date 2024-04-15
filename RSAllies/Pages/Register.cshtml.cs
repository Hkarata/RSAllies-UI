using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts;
using RSAllies.Models.English;
using RSAllies.Models.Swahili;

namespace RSAllies.Pages;

public class RegisterModel(ApiClient apiClient) : PageModel
{
    [BindProperty]
    public UserInput? Input {get;set;}
    
    [BindProperty]
    public SUserInput? SInput { get; set; }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var submittedForm = Request.Form["submittedForm"]; // Access form name
        
        if (submittedForm == "English")
        {
            var result = await apiClient.CreateUserAsync(Input.Adapt<UserDto>());
        }
        else
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await apiClient.CreateUserAsync(SInput.Adapt<UserDto>());
        }
        
        return RedirectToPage("./Index");
    }
}