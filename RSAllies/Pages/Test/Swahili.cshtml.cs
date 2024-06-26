using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Data.Contracts;

namespace RSAllies.Pages.Test
{
    public class SwahiliModel(ApiClient apiClient, UserResponsePublisher publisher) : PageModel
    {
        public UserDto? UserData { get; set; }

        public bool IsPosted;
        public List<QuestionDto>? Questions { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var session = HttpContext.Session.GetString("UserSession");
            if (string.IsNullOrEmpty(session)) return RedirectToPage("/Login");
            UserData = JsonConvert.DeserializeObject<UserDto>(session!);
            var result = await apiClient.GetSwahiliQuestions();
            Questions = result?.Value;
            return Page();
        }


        public async Task OnPost()
        {
            IsPosted = true;

            var form = Request.Form;
            var responses = new List<ResponseDto>();

            foreach (var key in form.Keys)
            {
                var value = form[key];
                if (!Guid.TryParse(key, out Guid questionId) ||
                    !Guid.TryParse(value, out Guid selectedChoiceId)) continue;
                var response = new ResponseDto
                {
                    QuestionId = questionId,
                    SelectedChoiceId = selectedChoiceId
                };
                responses.Add(response);
            }

            var session = HttpContext.Session.GetString("UserSession");
            UserData = JsonConvert.DeserializeObject<UserDto>(session!);

            var userResponse = new UserResponseDto
            {
                UserId = UserData!.Id,
                Name = $"{UserData.FirstName} {UserData.LastName}",
                Responses = responses
            };

            await publisher.PublishUserResponses(userResponse);

        }
    }
}
