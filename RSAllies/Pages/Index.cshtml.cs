using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Models.English;

namespace RSAllies.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserInput? Input { get; set; }

        public void OnGet()
        {

        }

    }
}
