using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;

namespace RSAllies.Pages.Scores
{
    public class IndexModel(ApiClient apiClient) : PageModel
    {
        public UserDto? UserData { get; set; }
        public ScoreDto? UserScore { get; set; }
        public string StatusMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGet()
        {
            var session = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(session))
            {
                return RedirectToPage("/Login");
            }

            UserData = JsonConvert.DeserializeObject<UserDto>(session);

            var score = await apiClient.GetUserScoreAsync(UserData!.Id);
            if (score != null && score!.IsSuccess)
            {
                UserScore = score.Value;
            }
            else
            {
                StatusMessage = "You exam is yet to be marked. Endelea kusubiri matokeo yako";
            }


            return Page();
        }

    }
}
