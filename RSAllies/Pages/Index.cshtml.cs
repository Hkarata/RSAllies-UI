using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using RSAllies.Authentication;
using RSAllies.Models.English;

namespace RSAllies.Pages
{
    public class IndexModel(ILogger<IndexModel> logger) : PageModel
    {
        [BindProperty]
        public UserInput? Input { get; set;}

        public void OnGet()
        {

        }

    }
}
