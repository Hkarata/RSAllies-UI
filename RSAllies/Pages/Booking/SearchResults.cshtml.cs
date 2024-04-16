using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Contracts;
using System.Text.Json;

namespace RSAllies.Pages
{
    public class SearchResultsModel : PageModel
    {
        public List<FilteredSessionDto>? Sessions { get; set; }
        public void OnGet()
        {
            var data = TempData["data"] as string;
            Sessions = JsonSerializer.Deserialize<List<FilteredSessionDto>>(data!);
        }
    }
}
