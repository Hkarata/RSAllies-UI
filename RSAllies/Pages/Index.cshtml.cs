using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Models;
using RSAllies.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using RSAllies.Authentication;

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
