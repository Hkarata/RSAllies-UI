using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RSAllies.Contracts.Contracts;

namespace RSAllies.Pages.Test
{
    public class EnglishModel(ApiClient apiClient, UserResponsePublisher publisher) : PageModel
    {
        public UserDto? UserData { get; set; }
        
        public bool IsPosted;
        public List<QuestionDto>? Questions { get; set; }
        
        public async Task OnGet()
        {
            var result = await apiClient.GetQuestions();
            Questions = result?.Value;
            
            
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
                Responses = responses
            };

            await publisher.PublishUserResponses(userResponse);

        }


    }
}
